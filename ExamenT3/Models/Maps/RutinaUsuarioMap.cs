using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT3.Models.Maps
{
    public class RutinaUsuarioMap : IEntityTypeConfiguration<RutinaUsuario>
    {
        public void Configure(EntityTypeBuilder<RutinaUsuario> builder)
        {
            builder.ToTable("RutinaUsuario");
            builder.HasKey(o => o.Id);
        }
    }
}
