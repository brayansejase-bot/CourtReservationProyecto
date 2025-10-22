using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtReservation_Infraestructure.Dto_s
{
    public class CanchaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string TipoDeporte { get; set; } = null!;

        public decimal PrecioPorHora { get; set; }

        public string? Ubicacion { get; set; }


    }
}
