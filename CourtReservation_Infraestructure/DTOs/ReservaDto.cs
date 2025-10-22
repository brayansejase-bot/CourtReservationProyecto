using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Infraestructure.Dto_s
{
    public class ReservaDto
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public int CanchaId { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Estado { get; set; } = null!;

        public string? Notas { get; set; }


    }
}
