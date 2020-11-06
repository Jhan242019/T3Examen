﻿using ExamenT3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.PatronEstrategia
{
    public class Avanzado : IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios)
        {
            Random random = new Random();
            List<DetalleRutina> detalles = new List<DetalleRutina>();
            for (int i = 0; i < 15; i++)
            {
                var detalle = new DetalleRutina();
                var ejercicio = random.Next(0, ejercicios);
                var tiempo = 120;

                detalle.IdEjercicios = ejercicio;
                detalle.IdRutinaUsuario = idRutina;
                detalle.Tiempo = tiempo;

                detalles.Add(detalle);
            }
            return detalles;
        }
    }
}
