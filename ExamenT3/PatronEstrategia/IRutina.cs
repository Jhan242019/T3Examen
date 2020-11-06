using ExamenT3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.PatronEstrategia
{
    public interface IRutina
    {
        public List<DetalleRutina> Rutina(int idRutina, int ejercicios);
    }
}
