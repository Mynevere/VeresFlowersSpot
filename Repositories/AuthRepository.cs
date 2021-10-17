using FlowrSpotPovio.Context;
using FlowrSpotPovio.Helpers.Errors;
using FlowrSpotPovio.Helpers.Security;
using FlowrSpotPovio.Interfaces;
using FlowrSpotPovio.Models;
using FlowrSpotPovio.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IJwtGenerator jwtGenerator;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthRepository(UserManager<User> userManager, 
                                SignInManager<User> signInManager,
                                IJwtGenerator jwtGenerator, 
                                IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtGenerator = jwtGenerator;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserViewModel> Register(RegisterUserViewModel registerUser, string password)
        {
            if (await userManager.FindByEmailAsync(registerUser.Email) != null)
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });
            if (await userManager.FindByNameAsync(registerUser.UserName) != null)
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });


            var user = new User
            {
                Email = registerUser.Email,
                UserName = registerUser.UserName,
            };
                
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                var userViewModel = new UserViewModel
                {
                    UserName = user.UserName,
                    TokenString = jwtGenerator.CreateToken(user),
                    Email = user.Email
                }; 

                return userViewModel;
            }
            throw new RestException(HttpStatusCode.NotFound, "Problem creating user");
        }

        public async Task<UserViewModel> Login(string email, string password) 
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
                throw new RestException(HttpStatusCode.BadRequest);

            var result = await signInManager
                .CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                return new UserViewModel
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    TokenString = jwtGenerator.CreateToken(user)
                };
            }

            throw new RestException(HttpStatusCode.BadRequest);
        }

        public async Task<UserViewModel> GetCurrentUser()
        {
            var username = httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await userManager.FindByNameAsync(username);

            return new UserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                TokenString = jwtGenerator.CreateToken(user),
            };
        }
    }
}
