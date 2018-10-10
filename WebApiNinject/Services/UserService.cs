using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiNinject.Services
{
    public class UserService : IUserService
    {
        public string GetName()
        {
            return "Test";
        }
    }
}
