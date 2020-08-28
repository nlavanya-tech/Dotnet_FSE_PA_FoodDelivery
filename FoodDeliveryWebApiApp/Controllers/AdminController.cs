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
    public class AdminController : ControllerBase
    {
        private readonly IRestorentService _service;
        public AdminController(IRestorentService service)
        {
            _service = service;
        }
        // GET: api/Admin
        [HttpGet]
        public async Task<IEnumerable<FoodItems>> GetFoodItems()
        {
            var fooditems =await _service.FoodIteamReadAsync();
            return fooditems;
        }
        // GET: api/Admin
        [HttpGet]
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            var orders = await _service.GetAllOrders();
            return orders;
        }
        // GET: api/Admin
        [HttpGet]
        public async Task<IEnumerable<Restorents>> GetRestorentDetailes()
        {
            var restorentdetails = await _service.GetAllRestorentdetails();
            return restorentdetails;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void CancelOrder(string orderid)
        {
            await _service.CancelOrders(orderid);
        }
    }
}
