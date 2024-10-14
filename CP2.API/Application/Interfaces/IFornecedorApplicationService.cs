using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IFornecedorApplicationService
    {
        IEnumerable<FornecedorEntity>? ObterTodosFornecedores();
        FornecedorEntity? ObterFornecedorPorId(int id);
        FornecedorEntity? SalvarDadosFornecedor(FornecedorDto entity);
        FornecedorEntity? EditarDadosFornecedor(int id, FornecedorDto entity);
        FornecedorEntity? DeletarDadosFornecedor(int id);
    }
}
