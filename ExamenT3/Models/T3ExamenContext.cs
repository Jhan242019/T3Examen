using ExamenT3.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models
{
    public class T3ExamenContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ejercicios> Ejercicios { get; set; }
        public DbSet<RutinaUsuario> RutinaUsuarios { get; set; }
        public DbSet<DetalleRutina> DetalleRutinas { get; set; }

        public T3ExamenContext(DbContextOptions<T3ExamenContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EjerciciosMap());
            modelBuilder.ApplyConfiguration(new RutinaUsuarioMap());
            modelBuilder.ApplyConfiguration(new DetalleRutinaMap());
        }
    }
}
