using FoodDeliveryWebApiApp.BusinessLayer.Integration;
using FoodDeliveryWebApiApp.BusinessLayer.Services;
using FoodDeliveryWebApiApp.BusinessLayer.Services.Repository;
using FoodDeliveryWebApiApp.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace FoodDeliveryWebApiApp.Test.TestCases
{
    public class Exceptional
    {
        private IUserService _userservices;
        public readonly Mock<IUserRepository> userservice = new Mock<IUserRepository>();
        static Exceptional()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        public Exceptional()
        {
            _userservices = new UserService(userservice.Object);
        }
        [Fact]
        public async void Test_validateUserSignUp()
        {
            //assigning value
            bool finalresult = false;
            var signup = new SignUp()
            {
                FirstName = "N",
                LastName = "lava",
                EmailId = "Nlavanya@gmail.com",
                PhoneNumber = "12335",
                NewPassword = "lava@123",
            };
            //setup
            userservice.Setup(repo => repo.UserSignUpCreateAsync(signup));
            var result = await _userservices.UserSignUpCreateAsync(signup);
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_exception_revised.txt", "Test_validateUserSignUp=" + finalresult + "\n");

            Assert.NotNull(result);

        }
    }
}
