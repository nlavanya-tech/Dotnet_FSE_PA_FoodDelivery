using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDeliveryWebApiApp.BusinessLayer.Integration;
using FoodDeliveryWebApiApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodDeliveryWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<string> GetUserLogin(string id)
        {
             var users = await _service.UserloginReadAsync(id);
            return users;
        }
        // POST: api/User
        [HttpPost]
        public async void SignUp([FromBody] SignUp signup)
        {
            await _service.UserSignUpCreateAsync(signup);
        }

        
    }
}
