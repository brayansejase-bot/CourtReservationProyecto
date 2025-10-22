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
    public class PagoConfiguration
    {
        public void Configure(EntityTypeBuilder<Pagos> builder)
        {
            builder.ToTable("Pagos");
            builder.HasKey(e => e.Id).HasName("PK__Pagos__3214EC07552E9A00");

        builder.Property(e => e.EstadoPago)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");
        builder.Property(e => e.FechaPago).HasColumnType("datetime");
        builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        builder.Property(e => e.MetodoPago).HasMaxLength(50);
        builder.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

        builder.HasOne(d => d.Reserva).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.ReservaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pagos_Reservas");
        }
    }
}
