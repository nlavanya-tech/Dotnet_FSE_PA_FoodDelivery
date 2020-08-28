using FoodDeliveryWebApiApp.BusinessLayer.Integration;
using FoodDeliveryWebApiApp.BusinessLayer.Services.Repository;
using FoodDeliveryWebApiApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryWebApiApp.BusinessLayer.Services
{
   public class RestorentService : IRestorentService
    {
        private readonly IRestorentRepository _repository;

        public RestorentService(IRestorentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Restorents> RestorentCreateAsync(Restorents restorent)
        {
            var userdetails = await _repository.RestorentCreateAsync(restorent);
            return restorent;

        }
        public async Task<FoodItems> FooditemCreateAsync(FoodItems fooditem)
        {
            var userdetails = await _repository.FooditemCreateAsync(fooditem);
            return fooditem;

        }
        public async Task<IEnumerable<FoodItems>> FoodIteamReadAsync()
        {
            var fooditems = await _repository.FoodIteamReadAsync();
            return fooditems;

        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            var orders = await _repository.GetAllOrders();
            return orders;

        }
        public async Task<IEnumerable<Restorents>> GetAllRestorentdetails()
        {
            var restorents = await _repository.GetAllRestorentdetails();
            return restorents;

        }
        public async Task<bool> CancelOrders(string orderid)
        {
            bool deleteditem = await _repository.CancelOrders(orderid);
            return deleteditem;

        }

    }
}
