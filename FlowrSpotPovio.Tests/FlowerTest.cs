using FlowrSpotPovio.Controllers;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Tests
{
    [TestClass]
    public class FlowerTest
    {
        private Mock<IFlowerRepository> flowerRepository;

        [TestInitialize]
        public void InitializeTest() 
        {
            flowerRepository = new Mock<IFlowerRepository>();
        }

        [TestMethod]
        public void GetFlowers() 
        {
            flowerRepository = new Mock<IFlowerRepository>();

            var controller = new FlowerController(flowerRepository.Object);

            var response = controller.GetAllFlowers();
            var createdResult = response.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
            Assert.AreNotEqual(createdResult.StatusCode, HttpStatusCode.BadRequest);
            Assert.AreNotEqual(createdResult.Value, "There are no flowers!");

        }
    }
}
