using AplicacionTp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsersAsync();

        Task<Usuario> CreateUserAsync(Usuario usuario);
    }
}
