using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;
using CourtReservation_Core.Interfaces;
using CourtReservation_Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CourtReservation_Infraestructure.Repositories
{
    public class PagoRepository : IPagoRepository
    {
        private readonly ApplicationDbContext _context;

        public PagoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Pagos>> GetAllPagosAsync()
        {
            var pagos = await _context.Pagos.ToListAsync();
            return pagos;
        }

        public async Task<Pagos> GetPagoAsync(int id)
        {
            var pago = await _context.Pagos.FirstOrDefaultAsync(
                x => x.Id == id);

            return pago;
        }

        public async Task InsertPagoAsync(Pagos pago)
        {
            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePagoAsync(Pagos pago)
        {
            _context.Pagos.Update(pago);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePagoAsync(Pagos pago)
        {
            _context.Pagos.Remove(pago);
            await _context.SaveChangesAsync();
        }
    }
}
