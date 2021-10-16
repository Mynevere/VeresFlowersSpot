using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthRepository authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserViewModel registerUser, string password)
        {
            try
            {
                var result = await authRepository.Register(registerUser, password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            try { 
                var result = await authRepository.Login(email, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(await authRepository.GetCurrentUser());
        }
    }
}
