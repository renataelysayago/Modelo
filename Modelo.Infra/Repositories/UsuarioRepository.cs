using Modelo.Data.Context;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;

namespace Modelo.Data.Repositories
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ModeloContext context) : base(context) { }

        public IEnumerable<Usuario> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
