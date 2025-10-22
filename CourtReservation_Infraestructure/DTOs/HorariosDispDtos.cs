using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Infraestructure.DTOs
{
    public class HorariosDispDtos
    {
        public int Id { get; set; }

        public int CanchaId { get; set; }

        public int DiaSemana { get; set; }

        public TimeOnly HoraInicio { get; set; }

        public TimeOnly HoraFin { get; set; }

        public virtual Canchas Cancha { get; set; } = null!;
    }
}
