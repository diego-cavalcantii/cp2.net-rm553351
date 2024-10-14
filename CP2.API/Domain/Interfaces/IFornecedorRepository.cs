using CP2.API.Domain.Entities;

namespace CP2.API.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        IEnumerable<FornecedorEntity>? ObterTodos();
        FornecedorEntity? ObterPorId(int id);
        FornecedorEntity? SalvarDados(FornecedorEntity entity);
        FornecedorEntity? EditarDados(FornecedorEntity entity);
        FornecedorEntity? DeletarDados(int id);

    }
}
