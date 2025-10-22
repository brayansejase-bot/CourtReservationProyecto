using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Core.Interfaces
{
    public interface ICanchaRepository
    {
        Task<IEnumerable<Canchas>> GetAllCanchaAsync();
        Task<Canchas> GetCanchaAsync(int id);
        Task InsertCanchaAsync(Canchas cancha);
        Task UpdateCanchaAsync(Canchas cancha);
        Task DeleteCanchaAsync(Canchas cancha);
    }
}
