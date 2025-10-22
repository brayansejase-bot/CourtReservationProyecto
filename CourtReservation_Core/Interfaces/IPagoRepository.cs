using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Core.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pagos>> GetAllPagosAsync();
        Task<Pagos> GetPagoAsync(int id);
        Task InsertPagoAsync(Pagos pago);
        Task UpdatePagoAsync(Pagos pago);
        Task DeletePagoAsync(Pagos pago);
    }
}
