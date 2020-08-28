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
   public class UserRepository : IUserRepository
    {
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Login> _dbloginCollection;
        private IMongoCollection<SignUp> _dbsignupCollection;
        public UserRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbloginCollection = _mongoContext.GetCollection<Login>(typeof(Login).Name);
            _dbsignupCollection = _mongoContext.GetCollection<SignUp>(typeof(SignUp).Name);
        }
        public async Task<string> UserloginReadAsync(string userid)
        {
            var objectId = new ObjectId(userid);
            FilterDefinition<SignUp> filter = Builders<SignUp>.Filter.Eq("EmailId", objectId);
            _dbsignupCollection = _mongoContext.GetCollection<SignUp>(typeof(SignUp).Name);
            var userdetails = await _dbsignupCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            Login login = new Login();
            login.UserId = userdetails.EmailId;
            login.Password = userdetails.NewPassword;
            return userid;
        }
    
        public async Task<SignUp> UserSignUpCreateAsync(SignUp signup)
        {
            _dbsignupCollection = _mongoContext.GetCollection<SignUp>(typeof(SignUp).Name);
            await _dbsignupCollection.InsertOneAsync(signup);
            return signup;
        }

    }
}
