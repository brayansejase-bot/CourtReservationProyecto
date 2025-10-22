using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;
using CourtReservation_Core.Interfaces;
using CourtReservation_Core.Interfaces.Services_Interfaces;

namespace CourtReservation_Core.Services
{
    public class ReservaService : IReservaService
    {
        public readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository postRepository)
        {
            _reservaRepository = postRepository;
        }

        public async Task<IEnumerable<Reservas>> GetAllReservasAsync()
        {
            return await _reservaRepository.GetAllReservasAsync();
        }

        public async Task<Reservas> GetReservaAsync(int id)
        {
            var reserva = await _reservaRepository.GetReservaAsync(id);
            if (reserva == null)
                throw new Exception("Reserva no encontrada");
            return reserva;

        }

        public async Task InsertReservaAsync(Reservas reserva)
        {
           /* var overlapping = await _reservaRepository.GetOverlappingReservationsAsync(reserva.CanchaId, reserva.FechaInicio, reserva.FechaFin);
            if (overlapping.Any())
                throw new Exception("La cancha ya está reservada en ese horario");
           */

            reserva.Estado = "Reservada";
            reserva.FechaCreacion = DateTime.Now;

            await _reservaRepository.InsertReservaAsync(reserva);
        }

        public async Task UpdateReservaAsync(Reservas reserva)
        {
            var existingReserva = await _reservaRepository.GetReservaAsync(reserva.Id);
            if (existingReserva == null)
                throw new Exception("Reserva no encontrada");

            await _reservaRepository.UpdateReservaAsync(reserva);
        }

        public async Task DeleteReservaAsync(Reservas reserva)
        {
            var existingReserva = await _reservaRepository.GetReservaAsync(reserva.Id);
            if (existingReserva == null)
                throw new Exception("Reserva no encontrada");

            await _reservaRepository.DeleteReservaAsync(reserva);
        }
    }
}
