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
    public class RestorentController : ControllerBase
    {
        private readonly IRestorentService _service;
        public RestorentController(IRestorentService service)
        {
            _service = service;
        }

        // POST: api/Restorent
        [HttpPost]
        public async void AddRestorents([FromBody] Restorents restorent)
        {
            await _service.RestorentCreateAsync(restorent);

        }
        // POST: api/Restorent
        [HttpPost]
        public async void PlaceOrder([FromBody] FoodItems fooditems)
        {
            await _service.FooditemCreateAsync(fooditems);
        }

    }
}
