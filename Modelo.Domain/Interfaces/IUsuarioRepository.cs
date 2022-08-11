using Modelo.Domain.Entities;
using Template.Domain.Interfaces;

namespace Modelo.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        IEnumerable<Usuario> GetAll();
    }
}
