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
    public class ReservaRepository : IReservaRepository
    {

        private readonly ApplicationDbContext _context;

        public ReservaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservas>> GetAllReservasAsync()
        {
            var reservas = await _context.Reservas.ToListAsync();
            return reservas;
        }

        public async Task<Reservas> GetReservaAsync(int id)
        {
            var reserva = await _context.Reservas.FirstOrDefaultAsync(
                x => x.Id == id);

            return reserva;
        }

        public async Task InsertReservaAsync(Reservas reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReservaAsync(Reservas reserva)
        {
            _context.Reservas.Update(reserva);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteReservaAsync(Reservas reserva)
        {
            _context.Reservas.Remove(reserva);
            await _context.SaveChangesAsync();
        }

    }
}
