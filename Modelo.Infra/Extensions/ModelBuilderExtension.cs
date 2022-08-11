using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Models;

namespace Modelo.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder ApplyGlobalConfiguration(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var item in entityType.GetProperties())
                {
                    switch (item.Name)
                    {
                        case nameof(Entity.Id):
                            item.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            item.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            item.IsNullable = false;
                            item.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            item.IsNullable = false;
                            item.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;
        }

        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(
                new Usuario { Id = Guid.Parse("18f0ad2d-e725-48f9-8020-d08f463bf5aa"), Nome = "User Default", Email = "userdefault@gmail.com", DateCreated = new DateTime(2022,2,2), IsDeleted = false, DateUpdated = null }
                );

            return builder;
        }
    }
}
