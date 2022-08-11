using Modelo.Domain.Models;

namespace Modelo.Domain.Entities
{
    public class Usuario: Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
