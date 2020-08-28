using FoodDeliveryWebApiApp.BusinessLayer.Integration;
using FoodDeliveryWebApiApp.BusinessLayer.Services.Repository;
using FoodDeliveryWebApiApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryWebApiApp.BusinessLayer.Services
{
   public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> UserloginReadAsync(string userid)
        {
            var user = await _repository.UserloginReadAsync(userid);
            return userid;
        }
        public async Task<SignUp> UserSignUpCreateAsync(SignUp signup)
        {
            var userdetails = await _repository.UserSignUpCreateAsync(signup);
            return signup;

        }
    }
}
