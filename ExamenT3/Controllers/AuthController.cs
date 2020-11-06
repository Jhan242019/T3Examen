using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ExamenT3.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ExamenT3.Controllers
{
    public class AuthController : BaseController
    {
        private readonly T3ExamenContext context;
        private readonly IConfiguration configuration;
        public IHostEnvironment hostEnv;

        public AuthController(T3ExamenContext context, IHostEnvironment hostEnv, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.configuration = configuration;
            this.hostEnv = hostEnv;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = context.Users
                .Where(o => o.Username == username && o.Password == CreateHash(password))
                .FirstOrDefault();
            //validar si el usuario existe, y si el password es correcto
            if (user != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                HttpContext.SignInAsync(claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Login", "Usuario o contraseña incorrectos.");
            return View();
        }
        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return View("Login");
        }
        private string CreateHash(string input)
        {
            var sha = SHA256.Create();
            input += configuration.GetValue<string>("Token");
            var hash = sha.ComputeHash(Encoding.Default.GetBytes(input));

            return Convert.ToBase64String(hash);
        }
        [HttpGet]
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(User user, string password, string passwordConf, string email)
        {
            if (password != passwordConf) // <-- para convalidar contraseña y confirmacion de contraseña
                ModelState.AddModelError("PasswordConf", "Las contraseñas no coinciden");

            if (ModelState.IsValid)
            {
                user.Password = CreateHash(password);
                context.Users.Add(user);
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("Registrar", user);
        }
    }
}
