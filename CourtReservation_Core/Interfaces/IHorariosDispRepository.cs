using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Core.Interfaces
{
    public interface IHorariosDispRepository
    {
        Task<IEnumerable<HorariosDisponibles>> GetAllHorariosAsync();
        Task<HorariosDisponibles> GetHorarioAsync(int id);
        Task InsertHorarioAsync(HorariosDisponibles horario);
        Task UpdateHorarioAsync(HorariosDisponibles horario);
        Task DeleteHorarioAsync(HorariosDisponibles horario);
    }
}
