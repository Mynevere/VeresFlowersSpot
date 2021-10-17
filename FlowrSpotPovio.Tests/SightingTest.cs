using FlowrSpotPovio.Controllers;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Tests
{
    [TestClass]
    public class SightingTest
    {
        private Mock<ISightingRepository> sightingRepository;

        [TestInitialize]
        public void InitializeTest() 
        {
            sightingRepository = new Mock<ISightingRepository>();
        }

        [TestMethod]
        public void GetSightingByFlowerIdTest()
        {
            sightingRepository = new Mock<ISightingRepository>();
            var controller = new SightingController(sightingRepository.Object);

            Task<IActionResult> actionResult = controller.GetSightingByFlowerId(Guid.Parse("08d98f52-bcc8-4d78-8d0d-b57342e811eb"));
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
        }

        [TestMethod]
        public void CreateSightingTest() 
        {
            sightingRepository = new Mock<ISightingRepository>();
            var controller = new SightingController(sightingRepository.Object);

            SightingViewModel model = new()
            {
                Latitude = 10,
                Longitude = 10,
                FlowerId = Guid.Parse("08d98f52-bccb-4446-87dd-cedfbbd6c668")
            };

            IFormFile file = null;

            Task<IActionResult> actionResult = controller.CreateSighting(model, file);
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
        }

        [TestMethod]
        public void DestroySightingTest()
        {
            sightingRepository = new Mock<ISightingRepository>();
            var controller = new SightingController(sightingRepository.Object);

            Task<IActionResult> actionResult = controller.DestroySighting(Guid.Parse("08d990be-2036-438e-8755-f64f9811ade0"));
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
        }
    }
}
