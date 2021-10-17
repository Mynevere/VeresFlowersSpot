using FlowrSpotPovio.Controllers;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
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
    public class LikeTest
    {
        private Mock<ILikeRepository> likeRepository;

        [TestInitialize]
        public void InitializeTest() 
        {
            likeRepository = new Mock<ILikeRepository>();
        }

        [TestMethod]
        public void LikeSightingTest()
        {
            likeRepository = new Mock<ILikeRepository>();
            var controller = new LikeController(likeRepository.Object);

            Task<IActionResult> actionResult = controller.LikeSighting(Guid.Parse("08d990ca-b7a7-4bba-8326-d6a3d9a3920d"));
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
            Assert.AreNotEqual(createdResult, HttpStatusCode.BadRequest);
            Assert.AreNotEqual(createdResult, "Liked");
        }

        [TestMethod]
        public void DestroyLikeTest() 
        {
            likeRepository = new Mock<ILikeRepository>();
            var controller = new LikeController(likeRepository.Object);

            Task<IActionResult> actionResult = controller.DestroyLike(Guid.Parse("08d990be-2036-438e-8755-f64f9811ade0"));
            var createdResult = actionResult.Result as OkObjectResult;

            Assert.IsNotNull(createdResult);
            Assert.AreNotEqual(createdResult, HttpStatusCode.BadRequest);
            Assert.AreNotEqual(createdResult, "You can't destory it!");
        }
    }
}
