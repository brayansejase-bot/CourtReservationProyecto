using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CourtReservation_Core.Entities;
using CourtReservation_Core.Interfaces;
using CourtReservation_Infraestructure.Context;

namespace CourtReservation_Infraestructure.Repositories
{
    public class CanchaRepository : ICanchaRepository
    {
        private readonly ApplicationDbContext _context;

        public CanchaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<Canchas>> GetAllCanchaAsync()
        {
            var canchas = await _context.Canchas.ToListAsync();
            return canchas;
        }

        public async Task<Canchas> GetCanchaAsync(int id)
        {
            var cancha = await  _context.Canchas.FirstOrDefaultAsync(
                x => x.Id == id);

            return cancha;
        }

        public async Task InsertCanchaAsync(Canchas cancha)
        {
            _context.Canchas.Add(cancha);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCanchaAsync(Canchas cancha)
        {
            _context.Canchas.Update(cancha);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCanchaAsync(Canchas cancha)
        {
            _context.Canchas.Remove(cancha);
            await _context.SaveChangesAsync();
        }

    }
}
