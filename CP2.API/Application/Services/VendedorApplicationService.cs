using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.API.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VendedorEntity>? BuscarTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? SalvarDadosVendedor(VendedorDto dto)
        {
            var vendedor = new VendedorEntity
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                DataNascimento = dto.DataNascimento,
                Endereco = dto.Endereco,
                DataContratacao = dto.DataContratacao,
                ComissaoPercentual = dto.ComissaoPercentual,
                MetaMensal = dto.MetaMensal,
                CriadoEm = DateTime.Now // Define a data de criação no momento do cadastro
            };

            return _repository.SalvarDados(vendedor);
        }

        public VendedorEntity? EditarDadosVendedor(int id, VendedorDto dto)
        {
            var vendedorExistente = _repository.ObterPorId(id);
            if (vendedorExistente == null)
            {
                return null; // Opcional: lançar exceção caso o vendedor não exista
            }

            // Atualiza os dados do vendedor, exceto a data de criação
            vendedorExistente.Nome = dto.Nome;
            vendedorExistente.Email = dto.Email;
            vendedorExistente.Telefone = dto.Telefone;
            vendedorExistente.DataNascimento = dto.DataNascimento;
            vendedorExistente.Endereco = dto.Endereco;
            vendedorExistente.DataContratacao = dto.DataContratacao;
            vendedorExistente.ComissaoPercentual = dto.ComissaoPercentual;
            vendedorExistente.MetaMensal = dto.MetaMensal;

            return _repository.EditarDados(vendedorExistente);
        }

        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            var vendedorExistente = _repository.ObterPorId(id);
            if (vendedorExistente == null)
            {
                return null; // Opcional: lançar exceção caso o vendedor não exista
            }

            return _repository.DeletarDados(id);
        }
    }
}
