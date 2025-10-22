using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Core.Interfaces
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reservas>> GetAllReservasAsync();
        Task<Reservas> GetReservaAsync(int id);
        Task InsertReservaAsync(Reservas reserva);
        Task UpdateReservaAsync(Reservas reserva);
        Task DeleteReservaAsync(Reservas reserva);
    }
}
