using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiNinject.Filters;
using WebApiNinject.Services;

namespace WebApiNinject.Controllers
{
    public class UserController : ApiController
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ParamsFilter]
        public string Get()
        {
            return _userService.GetName();
        }
    }
}
