using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourtReservation_Core.Entities;

namespace CourtReservation_Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAllUsuarioAsync();
        Task<Usuarios> GetUsuarioAsync(int id);
        Task InsertUsuarioAsync(Usuarios usuario);
        Task UpdateUsuarioAsync(Usuarios usuario);
        Task DeleteUsarioAsync(Usuarios usuario);
    }
}
