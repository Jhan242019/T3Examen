using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenT3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamenT3.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly T3ExamenContext context;
        public BaseController(T3ExamenContext context)
        {
            this.context = context;
        }
        protected User LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Users.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
