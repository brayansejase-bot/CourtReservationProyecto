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
    public class UsuarioConfiguration
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC07252BCBEB");

        builder.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534F3CEDA29").IsUnique();

        builder.Property(e => e.Apellido).HasMaxLength(100);
        builder.Property(e => e.Email).HasMaxLength(200);
        builder.Property(e => e.Estado).HasDefaultValue(true);
        builder.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        builder.Property(e => e.Nombre).HasMaxLength(100);
        builder.Property(e => e.Password).HasMaxLength(200);
        builder.Property(e => e.Rol)
                .HasMaxLength(50)
                .HasDefaultValue("Usuario");
        builder.Property(e => e.Telefono).HasMaxLength(20);
        }
    }
}
