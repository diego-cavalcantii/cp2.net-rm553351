using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<VendedorEntity>? ObterTodos()
        {
            var vendedores = _context.Vendedor.ToList();

            if (vendedores.Any())
                return vendedores;

            return null;
        }
        
        public VendedorEntity? ObterPorId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            
            if (vendedor is not null)
                return vendedor;
            
            return null;
        }
        
        public VendedorEntity? SalvarDados(VendedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel salvar o vendedor");
            }
        }
        
        public VendedorEntity? EditarDados(VendedorEntity entity)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(entity.Id);

                if (vendedor is not null)
                {
                    vendedor.Nome = entity.Nome;
                    vendedor.Email = entity.Email;

                    _context.Update(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                throw new Exception("Não foi possivel localizar o vendedor");
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel editar o vendedor");
            }
        }
        
        public VendedorEntity? DeletarDados(int id)
        {
            try
            {
                var vendedor = _context.Vendedor.Find(id);

                if (vendedor is not null)
                {
                    _context.Remove(vendedor);
                    _context.SaveChanges();

                    return vendedor;
                }

                throw new Exception("Não foi possivel localizar o vendedor");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message,ex);
            }
        }
    }
}
