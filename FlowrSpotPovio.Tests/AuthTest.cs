using FlowrSpotPovio.Controllers;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.Repositories;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using System.Net;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Tests
{
    [TestClass]
    public class AuthTest
    {
        private Mock<IAuthRepository> authRepository;

        [TestInitialize]
        public void InitializeTest() 
        {
            authRepository = new Mock<IAuthRepository>();
        }

        [TestMethod]
        public void RegisterTest()
        {

            RegisterUserViewModel user = new()
            {
                UserName = "Test1",
                Email = "test1@gmail.com"
            };

            authRepository.Setup(service => service.Register(user, "Pa$$w0rd"))
            .ReturnsAsync(new UserViewModel { UserName = user.UserName, Email = user.Email});
            var controller = new AuthController(authRepository.Object);

            Task<IActionResult> actionResult = controller.Register(user, "Pa$$w0rd");
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
            Assert.AreNotEqual(createdResult.Value, "Email already exists");
            Assert.AreNotEqual(createdResult.Value, "Username already exists");
            Assert.AreNotEqual(createdResult.Value, "Problem creating user");
        }

        [TestMethod]
        public void LoginTest()
        {
            var controller = new AuthController(authRepository.Object);

            Task<IActionResult> actionResult = controller.Login("myneverehyseni@gmail.com", "Pa$$w0rd");
            var createdResult = actionResult.Result as OkObjectResult;
             
            Assert.IsNotNull(createdResult);
            Assert.AreNotEqual(createdResult.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
