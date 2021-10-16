using FlowrSpotPovio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserViewModel> Login(string email, string password);
        Task<UserViewModel> Register(RegisterUserViewModel user, string password);
        Task<UserViewModel> GetCurrentUser();
    }
}
