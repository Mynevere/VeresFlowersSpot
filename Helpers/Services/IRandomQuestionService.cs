using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowrSpotPovio.Helpers.Services
{
    public interface IRandomQuestionService
    {
        Task<string> GenerateRandomQuestion(); 
    }
}
