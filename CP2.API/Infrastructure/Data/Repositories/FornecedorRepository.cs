using CP2.API.Infrastructure.Data.AppData;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;

namespace CP2.API.Infrastructure.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<FornecedorEntity>? ObterTodos()
        {
            var fornecedores = _context.Fornecedor.ToList();

            if (fornecedores.Any())
                return fornecedores;

            return null;
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor is not null)
                return fornecedor;

            return null;
        }

        public FornecedorEntity? SalvarDados(FornecedorEntity entity)
        {
            try
            {
                _context.Add(entity);
                _context.SaveChanges();

                return entity;
            }
            catch (Exception)
            {
                throw new Exception("Não foi possivel salvar o fornecedor");
            }
        }

        public FornecedorEntity? EditarDados(FornecedorEntity entity)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(entity.Id);

                if (fornecedor is not null)
                {
                    fornecedor.Nome = entity.Nome;
                    fornecedor.Email = entity.Email;

                    _context.Update(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                throw new Exception("Não foi possivel localizar o fornecedor");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            try
            {
                var fornecedor = _context.Fornecedor.Find(id);

                if (fornecedor is not null)
                {
                    _context.Remove(fornecedor);
                    _context.SaveChanges();

                    return fornecedor;
                }

                throw new Exception("Não foi possivel localizar o fornecedor");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}