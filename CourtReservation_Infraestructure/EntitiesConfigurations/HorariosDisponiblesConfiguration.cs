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
    public class HorariosDisponiblesConfiguration
    {

        public void Configure(EntityTypeBuilder<HorariosDisponibles> builder)
        {
            builder.ToTable("HorariosDisponibles");
            builder.HasKey(e => e.Id).HasName("PK__Horarios__3214EC07E1826348");

        builder.HasOne(d => d.Cancha).WithMany(p => p.HorariosDisponibles)
                .HasForeignKey(d => d.CanchaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horarios_Canchas");
        }
    }
}
