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
    public class Functional
    {
        private IUserService _userservices;
        private IRestorentService _services;
        public readonly Mock<IUserRepository> userservice = new Mock<IUserRepository>();
        public readonly Mock<IRestorentRepository> service = new Mock<IRestorentRepository>();
        static Functional()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        public Functional()
        {
            _userservices = new UserService(userservice.Object);
            _services = new RestorentService(service.Object);
        }
        Random random = new Random();
        [Fact]
        public async void Test_getUserlogin()
        {
            //assigning value
            bool finalresult = false;
            var login = new Login()
            {
                UserId = "lavanya2@gmail.com",
                Password = "lava@123",
            };
            //setup
            userservice.Setup(repo => repo.UserloginReadAsync(login.UserId));
            var result = await _userservices.UserloginReadAsync(login.UserId);
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_getUserlogin=" + finalresult + "\n");

            Assert.NotNull(result);

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
            File.AppendAllText("../../../../output_revised.txt", "Test_validateUserSignUp=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_UserSignUp()
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
            if (result == signup) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_UserSignUp=" + finalresult + "\n");

            Assert.Equal(result, signup);

        }
        [Fact]
        public async void Test_RestorentCreate()
        {
            //assigning value
            bool finalresult = false;
            var restorent = new Restorents()
            {
                RestorentName = "vishnu bhavan",
                Address = "chittor",
                Reviews = "4",
            };
            //setup
            service.Setup(repo => repo.RestorentCreateAsync(restorent));
            var result = await _services.RestorentCreateAsync(restorent);
            if (result == restorent) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_RestorentCreate=" + finalresult + "\n");

            Assert.Equal(result, restorent);

        }
        [Fact]
        public async void Test_validatingAddRestorent()
        {
            //assigning value
            bool finalresult = false;
            var restorent = new Restorents()
            {
                RestorentName = "vishnu bhavan",
                Address = "chittor",
                Reviews = "4",
            };
            //setup
            service.Setup(repo => repo.RestorentCreateAsync(restorent));
            var result = await _services.RestorentCreateAsync(restorent);
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_validatingAddRestorent=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_validatingFooditemCreate()
        {
            //assigning value
            bool finalresult = false;
            var fooditems = new FoodItems()
            {
                RestorentName = "vishnu bhavan",
                FoodItem = "dosa",
                Cost = 4,
                Address = "chittor"
            };
            //setup
            service.Setup(repo => repo.FooditemCreateAsync(fooditems));
            var result = await _services.FooditemCreateAsync(fooditems);
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_validatingFooditemCreate=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_FooditemCreate()
        {
            //assigning value
            bool finalresult = false;
            var fooditems = new FoodItems()
            {
                RestorentName = "vishnu bhavan",
                FoodItem = "dosa",
                Cost = 4,
                Address = "chittor"
            };
            //setup
            service.Setup(repo => repo.FooditemCreateAsync(fooditems));
            var result = await _services.FooditemCreateAsync(fooditems);
            if (result == fooditems) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_validatingFooditemCreate=" + finalresult + "\n");

            Assert.Equal(result, fooditems);

        }

        [Fact]
        public async void Test_GetAllFoodIteam()
        {
            //assigning value
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.FoodIteamReadAsync());
            var result = await _services.FoodIteamReadAsync();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllFoodIteam=" + finalresult + "\n");

            Assert.NotNull(result);
        }
        [Fact]
        public async void Test_GetAllOrders()
        {
            //assigning value
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.GetAllOrders());
            var result = await _services.GetAllOrders();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllOrders=" + finalresult + "\n");

            Assert.NotNull(result);
        }
        [Fact]
        public async void Test_GetAllRestorentdetails()
        {
            //assigning value
            bool finalresult = false;

            //setup
            service.Setup(repo => repo.GetAllRestorentdetails());
            var result = await _services.GetAllRestorentdetails();
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_GetAllRestorentdetails=" + finalresult + "\n");

            Assert.NotNull(result);
        }
        [Fact]
        public async void Test_CancelOrders()
        {
            //assigning value
            bool finalresult = false;
            var Orders = new Orders()
            {
                OrderId = "345",
                FoodItem = "dosa",
                Cost = 4,
                Address = "chittor"
            };
            //setup
            service.Setup(repo => repo.CancelOrders(Orders.OrderId));
            var result = await _services.CancelOrders(Orders.OrderId);
            if (result != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_revised.txt", "Test_CancelOrders=" + finalresult + "\n");

            Assert.NotNull(result);
        }
    }
}
