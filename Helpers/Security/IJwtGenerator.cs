using FlowrSpotPovio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Helpers.Security
{
    public interface IJwtGenerator
    {
        string CreateToken(User user);
    }
}
