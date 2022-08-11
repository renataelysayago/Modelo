using Microsoft.EntityFrameworkCore;
using Modelo.Data.Extensions;
using Modelo.Data.Mappings;
using Modelo.Domain.Entities;

namespace Modelo.Data.Context
{
    public class ModeloContext : DbContext
    {
        public ModeloContext(DbContextOptions<ModeloContext> option) : base(option) { }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            modelBuilder.ApplyGlobalConfiguration();

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
