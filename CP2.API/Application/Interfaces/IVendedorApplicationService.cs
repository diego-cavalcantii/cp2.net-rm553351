using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;

namespace CP2.API.Application.Interfaces
{
    public interface IVendedorApplicationService
    {
        IEnumerable<VendedorEntity>? BuscarTodosVendedores();
        VendedorEntity? ObterVendedorPorId(int id);
        VendedorEntity? SalvarDadosVendedor(VendedorDto entity);
        VendedorEntity? EditarDadosVendedor(int id, VendedorDto entity);
        VendedorEntity? DeletarDadosVendedor(int id);
    }
}
