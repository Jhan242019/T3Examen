using ExamenT3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.PatronEstrategia
{
    public class Principiante : IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios)
        {

            Random random = new Random();
            List<DetalleRutina> detalles = new List<DetalleRutina>();
            for (int i = 0; i < 5; i++)
            {
                var detalle = new DetalleRutina();
                var ejercicio = random.Next(1, ejercicios);

                detalle.IdEjercicios = ejercicio;
                detalle.IdRutinaUsuario = idRutina;
                detalle.Tiempo = random.Next(60, 120);

                detalles.Add(detalle);

            }
            return detalles;
        }
    }
}
