using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models.Maps
{
    public class EjerciciosMap : IEntityTypeConfiguration<Ejercicios>
    {
        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Ejercicio");
            builder.HasKey(o => o.Id);
        }
    }
}
