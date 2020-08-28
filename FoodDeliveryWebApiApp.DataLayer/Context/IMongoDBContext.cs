using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodDeliveryWebApiApp.DataLayer.Context
{
  public interface IMongoDBContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
