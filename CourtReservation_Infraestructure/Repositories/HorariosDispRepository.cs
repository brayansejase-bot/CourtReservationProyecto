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
    public class HorariosDispRepository : IHorariosDispRepository
    {
        private readonly ApplicationDbContext _context;

        public HorariosDispRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HorariosDisponibles>> GetAllHorariosAsync()
        {
            var horarios = await _context.HorariosDisponibles.ToListAsync();
            return horarios;
        }

        public async Task<HorariosDisponibles> GetHorarioAsync(int id)
        {
            var horario = await _context.HorariosDisponibles.FirstOrDefaultAsync(
                x => x.Id == id);

            return horario;
        }

        public async Task InsertHorarioAsync(HorariosDisponibles horario)
        {
            _context.HorariosDisponibles.Add(horario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHorarioAsync(HorariosDisponibles horario)
        {
            _context.HorariosDisponibles.Update(horario);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteHorarioAsync(HorariosDisponibles horario)
        {
            _context.HorariosDisponibles.Remove(horario);
            await _context.SaveChangesAsync();
        }

    }
}
