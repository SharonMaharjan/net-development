
using Shop.DALPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.APIPractice.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
