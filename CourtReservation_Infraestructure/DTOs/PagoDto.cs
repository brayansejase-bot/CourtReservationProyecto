using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourtReservation_Infraestructure.DTOs
{
    public class PagoDto
    {
        public int Id { get; set; }

        public decimal Monto { get; set; }

        public string MetodoPago { get; set; } = null!;

        public string EstadoPago { get; set; } = null!;

        public DateTime? FechaPago { get; set; }

    }
}
