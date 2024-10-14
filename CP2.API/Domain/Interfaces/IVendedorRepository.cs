using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        IEnumerable<VendedorEntity>? ObterTodos();
        VendedorEntity? ObterPorId(int id);
        VendedorEntity? SalvarDados(VendedorEntity entity);
        VendedorEntity? EditarDados(VendedorEntity entity);
        VendedorEntity? DeletarDados(int id);
        
    }
}
