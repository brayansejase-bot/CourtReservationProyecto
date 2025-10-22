using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtReservation_Infraestructure.EntitiesConfigurations
{
    public class CanchaConfiguration
    {
        public void Configure(EntityTypeBuilder<Canchas> builder)
        {

          builder.HasKey(e => e.Id).HasName("PK__Canchas__3214EC0745F832C4");
            builder.ToTable("Canchas");

            builder.Property(e => e.EstaActiva).HasDefaultValue(true);
        builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        builder.Property(e => e.Nombre).HasMaxLength(100);
        builder.Property(e => e.PrecioPorHora).HasColumnType("decimal(10, 2)");
        builder.Property(e => e.TipoDeporte).HasMaxLength(50);
        builder.Property(e => e.Ubicacion).HasMaxLength(150);
        
        }
    }
}
