using FoodDeliveryWebApiApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryWebApiApp.BusinessLayer.Services.Repository
{
   public interface IUserRepository
    {
        Task<string> UserloginReadAsync(string userid);
        Task<SignUp> UserSignUpCreateAsync(SignUp signup);
    }
}
