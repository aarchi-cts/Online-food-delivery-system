using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_food_delivery_system.Models;
using Online_food_delivery_system.Service;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AgentService _agentService;

        public AgentController(AgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        //[Authorize(Roles = "admin,agent")]
        public async Task<IActionResult> GetAllAgents()
        {
            var agents = await _agentService.GetAllAgentsAsync();
            return Ok(agents);
        }

        [HttpPost]
        //[Authorize(Roles = "agent,admin")]
        public async Task<IActionResult> AddAgent([FromBody] Agent agent)
        {
            await _agentService.AddAgentAsync(agent);
            return CreatedAtAction(nameof(GetAllAgents), new { id = agent.AgentID }, agent);
        }
    }
}
