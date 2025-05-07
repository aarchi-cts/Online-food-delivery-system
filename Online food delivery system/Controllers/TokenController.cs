using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_food_delivery_system.Interface;
using Online_food_delivery_system.Models;

namespace Online_food_delivery_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly FoodDbContext _con;
        private readonly ITokenGenerate _tokenService;
        public TokenController(FoodDbContext con, ITokenGenerate tokenService)
        {
            _con = con;
            _tokenService = tokenService;
        }
        [HttpPost]      
        public async Task<IActionResult> Post(User user)
        {
            if(user!= null && !string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                var token = await GetUser(user.Email, user.Password, user.Role);
                if (user != null)
                {
                    var userToken = _tokenService.GenerateToken(user);
                    return Ok(new { userToken });
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }
            }
            else
            {
                return BadRequest("Please enter a valid email and password");
            }
        }
        private async Task<User> GetUser(string email, string password, string role)
        {
            return await _con.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Role == role) ?? new Models.User();
        }
    }
}
