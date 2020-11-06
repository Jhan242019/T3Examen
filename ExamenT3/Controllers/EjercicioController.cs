using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenT3.Models;
using ExamenT3.PatronEstrategia;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ExamenT3.Controllers
{
    [Authorize]
    public class EjercicioController : BaseController
    {
        private readonly T3ExamenContext context;
        private IRutina tipoRutina;
        public IHostEnvironment hostEnv;

        public EjercicioController(T3ExamenContext context, IHostEnvironment hostEnv) : base(context)
        {
            this.context = context;
            this.hostEnv = hostEnv;
        }

        [HttpGet]
        public ActionResult Index(int RutinaId)
        {

            ViewBag.Ejercicios = context.Ejercicios.ToList();

            var rutina = context.DetalleRutinas.
                Where(o => o.IdRutinaUsuario == RutinaId).
                Include(o => o.Ejercicios).
                ToList();

            return View(rutina);
        }

        [HttpGet]
        public ActionResult Rutinas()
        {
            ViewBag.User = LoggedUser().Id;

            var rutinas = context.RutinaUsuarios.
                Where(o => o.IdUsuario == LoggedUser().Id).
                ToList();

            return View(rutinas);
        }

        [HttpGet]
        public ActionResult CrearRutina()
        {
            ViewBag.Tipo = new List<string> { "Principiante", "Intermedio", "Avanzado" };
         
            return View(new RutinaUsuario());
        }
        [HttpPost]
        public ActionResult CrearRutina(RutinaUsuario rutina)
        {
            rutina.IdUsuario = LoggedUser().Id;
            if (ModelState.IsValid)
            {
                context.RutinaUsuarios.Add(rutina);
                context.SaveChanges();

                int idRutina = rutina.Id;
                var ejercicios = context.Ejercicios.ToList();
                int ejercicio = ejercicios.Count();
                switch (rutina.Tipo)
                {
                    case "Principiante":
                        tipoRutina = new Principiante();
                        break;
                    case "Intermedio":
                        tipoRutina = new Intermedio();
                        break;
                    case "Avanzado":
                        tipoRutina = new Avanzado();
                        break;
                }

                var aplicar = tipoRutina.Rutina(idRutina, ejercicio);

                context.DetalleRutinas.AddRange(aplicar);
                context.SaveChanges();

                return RedirectToAction("Rutinas");
            }
            else
            {
                ViewBag.Tipo = new List<string> { "Intermedio", "Principiante", "Avanzado" };
                return View(new RutinaUsuario());
            }

        }
    }
}
