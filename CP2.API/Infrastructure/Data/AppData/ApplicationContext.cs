using CP2.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CP2.API.Infrastructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<FornecedorEntity> Fornecedor { get; set; }
        public DbSet<VendedorEntity> Vendedor { get; set; }

    }
}
