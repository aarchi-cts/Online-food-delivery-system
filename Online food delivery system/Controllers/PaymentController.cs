﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // Get: api/Payment
        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }
        [HttpGet("{id}/search")]
        public async Task<IActionResult> GetPaymenttByOrderId(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound("Payment not found");
            return Ok(payment);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                return BadRequest("Status cannot be null or empty");

            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound("Payment not found");

            payment.Status = status;
            //if status is "completed"  then assign the delivery id
            if (status.ToLower() == "completed")
            {
                var delivery = payment.Order?.Delivery;
                if (delivery == null)
                {
                    return BadRequest("Delivery not found for the associated order.");
                }

                // Check for an available agent
                var availableAgent = await _paymentService.GetAvailableAgentAsync();
                if (availableAgent == null)
                {
                    return BadRequest("No available agents to assign.");
                }
                delivery.AgentID = availableAgent.AgentID;
                delivery.Agent = availableAgent;
                delivery.Status = "Assigned";

                // Update the agent's availability to false
                availableAgent.IsAvailable = false;

                // Update the delivery and agent in the database
                await _paymentService.UpdateDeliveryAsync(delivery);
                await _paymentService.UpdateAgentAsync(availableAgent);
            }
            await _paymentService.UpdatePaymentAsync(payment);

            return Ok("Payment status updated successfully and agent assigned");
        }



        //// Post: api/Payment
        //[HttpPost]
        //public async Task<IActionResult> AddPayment([FromBody] Payment payment)
        //{
        //    if (payment == null) return BadRequest("Payment cannot be null");
        //    await _paymentService.AddPaymentAsync(payment);
        //    return CreatedAtAction(nameof(GetPaymentById), new { id = payment.PaymentID }, payment);
        //}

        // Put: api/Payment/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePayment(int id, [FromBody] Payment payment)
        {
            if (id != payment.PaymentID) return BadRequest("Payment ID mismatch");
            await _paymentService.UpdatePaymentAsync(payment);
            return NoContent();
        }

        // Delete: api/Payment/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePayment(int id)
        //{
        //    await _paymentService.DeletePaymentAsync(id);
        //    return NoContent();
        //}

        //// Post: api/Payment/Process
        //[HttpPost("Process")]
        //public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        //{
        //    if (payment == null) return BadRequest("Payment cannot be null");
        //    var processedPayment = await _paymentService.ProcessPaymentAsync(payment);
        //    return Ok(processedPayment);
        //}
    }
}
