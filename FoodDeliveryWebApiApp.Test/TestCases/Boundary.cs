using FoodDeliveryWebApiApp.BusinessLayer.Integration;
using FoodDeliveryWebApiApp.BusinessLayer.Services;
using FoodDeliveryWebApiApp.BusinessLayer.Services.Repository;
using FoodDeliveryWebApiApp.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace FoodDeliveryWebApiApp.Test.TestCases
{
    public class Boundary
    {
        private IUserService _userservices;
        private IRestorentService _services;
        public readonly Mock<IUserRepository> userservice = new Mock<IUserRepository>();
        public readonly Mock<IRestorentRepository> service = new Mock<IRestorentRepository>();
        static Boundary()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        public Boundary()
        {
            _userservices = new UserService(userservice.Object);
            _services = new RestorentService(service.Object);
        }
        Random random = new Random();
        [Fact]
        public void Test_ValidateUserId()
        {

            //Assigning values
            bool finalvalue = false;
            var login = new Login()
            {
                UserId = "lavanya2@gmail.com",
                Password = "lava@123",
            };

            //setup

            finalvalue = Regex.IsMatch(login.UserId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(finalvalue);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateUserId=" + finalvalue + "\n");

        }
        [Fact]
        public async void Test_ValidatePassword()
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

            //Assert
            Assert.NotNull(result);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatePassword=" + finalresult + "\n");

        }
        [Fact]
        public async void Test_ValidateSignupNewPassword()
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
            if (result.NewPassword != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateSignupNewPassword=" + finalresult + "\n");

        }
        [Fact]
        public void Test_ValidateSignupEmailId()
        {

            //Assigning values
            bool finalvalue = false;
            var signup = new SignUp()
            {
                FirstName = "N",
                LastName = "lava",
                EmailId = "Nlavanya@gmail.com",
                PhoneNumber = "12335",
                NewPassword = "lava@123",
            };

            //setup

            finalvalue = Regex.IsMatch(signup.EmailId, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            //Assert
            Assert.True(finalvalue);

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateSignupEmailId=" + finalvalue + "\n");

        }
        [Fact]
        public async void Test_ValidateSignupphoneNum()
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
            if (result.PhoneNumber != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidateSignupphoneNum=" + finalresult + "\n");

        }
        [Fact]
        public async void Test_ValidatingNullRestorentName()
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
            if (result.RestorentName != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatingNullRestorentName=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_ValidatingNullAddress()
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
            if (result.Address != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatingNullAddress=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_ValidatingNullreviews()
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
            if (result.Reviews != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatingNullreviews=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_ValidatingNullfooditemsCost()
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
            if (result.Cost != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatingNullfooditemsCost=" + finalresult + "\n");

            Assert.NotNull(result);

        }
        [Fact]
        public async void Test_ValidatingNullfooditems()
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
            if (result.FoodItem != null) { finalresult = true; }

            //finalresult displaying in text file
            File.AppendAllText("../../../../output_boundary_revised.txt", "Test_ValidatingNullfooditems=" + finalresult + "\n");

            Assert.NotNull(result);

        }

    }
}
