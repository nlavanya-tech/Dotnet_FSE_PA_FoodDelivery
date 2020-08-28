using FoodDeliveryWebApiApp.DataLayer.Context;
using FoodDeliveryWebApiApp.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryWebApiApp.BusinessLayer.Services.Repository
{
   public class RestorentRepository : IRestorentRepository
    {
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Restorents> _dbrestorentsCollection;
        private IMongoCollection<FoodItems> _dbfooditemspCollection;
        private IMongoCollection<Orders> _dbodersCollection;

        public RestorentRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbrestorentsCollection = _mongoContext.GetCollection<Restorents>(typeof(Restorents).Name);
            _dbfooditemspCollection = _mongoContext.GetCollection<FoodItems>(typeof(FoodItems).Name);
            _dbodersCollection = _mongoContext.GetCollection<Orders>(typeof(Orders).Name);
        }
        public async Task<Restorents> RestorentCreateAsync(Restorents restorent)
        {
            _dbrestorentsCollection = _mongoContext.GetCollection<Restorents>(typeof(Restorents).Name);
            await _dbrestorentsCollection.InsertOneAsync(restorent);
            return restorent;
        }
        public async Task<FoodItems> FooditemCreateAsync(FoodItems fooditem)
        {
            _dbfooditemspCollection = _mongoContext.GetCollection<FoodItems>(typeof(FoodItems).Name);
            await _dbfooditemspCollection.InsertOneAsync(fooditem);

            return fooditem;
        }
        public async Task<IEnumerable<FoodItems>> FoodIteamReadAsync()
        {
            var list = _mongoContext.GetCollection<FoodItems>("FoodItems")
                .Find(Builders<FoodItems>.Filter.Empty, null);
            return await list.ToListAsync();
        }
        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            var list = _mongoContext.GetCollection<Orders>("Orders")
                .Find(Builders<Orders>.Filter.Empty, null);
            return await list.ToListAsync();

        }
        public async Task<IEnumerable<Restorents>> GetAllRestorentdetails()
        {
            var list = _mongoContext.GetCollection<Restorents>("Restorents")
               .Find(Builders<Restorents>.Filter.Empty, null);
            return await list.ToListAsync();

        }
        public async Task<bool> CancelOrders(string orderid)
        {
            var objectId = new ObjectId(orderid);
            FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq("OderId", objectId);
            var result = await _dbodersCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;

        }
    }
}
