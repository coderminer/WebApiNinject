using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiNinject.Services;

namespace WebApiNinject.Filters
{
    public class ParamsFilterAttribute : ActionFilterAttribute
    {
        public IUserService userService { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            userService.GetName();
        }
    }
}
