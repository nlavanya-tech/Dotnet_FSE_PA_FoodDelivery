using FoodDeliveryWebApiApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryWebApiApp.BusinessLayer.Services.Repository
{
   public interface IRestorentRepository
    {
        Task<Restorents> RestorentCreateAsync(Restorents restorent);
        Task<FoodItems> FooditemCreateAsync(FoodItems fooditem);
        Task<IEnumerable<FoodItems>> FoodIteamReadAsync();
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<IEnumerable<Restorents>> GetAllRestorentdetails();
        Task<bool> CancelOrders(string orderid);

    }
}
