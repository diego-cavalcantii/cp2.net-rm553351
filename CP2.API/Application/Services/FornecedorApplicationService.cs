using CP2.API.Application.Interfaces;
using CP2.API.Application.Dtos;
using CP2.API.Domain.Entities;
using CP2.API.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.API.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<FornecedorEntity>? ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public FornecedorEntity? SalvarDadosFornecedor(FornecedorDto dto)
        {
            var fornecedor = new FornecedorEntity
            {
                Nome = dto.Nome,
                Cnpj = dto.Cnpj,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                CriadoEm = DateTime.Now // Data de criação é definida ao salvar
            };

            return _repository.SalvarDados(fornecedor);
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, FornecedorDto dto)
        {
            var fornecedorExistente = _repository.ObterPorId(id);
            if (fornecedorExistente == null)
            {
                // Opcional: lançar exceção ou retornar null, dependendo da sua regra de negócio
                return null;
            }

            // Atualiza os campos do fornecedor existente
            fornecedorExistente.Nome = dto.Nome;
            fornecedorExistente.Cnpj = dto.Cnpj;
            fornecedorExistente.Endereco = dto.Endereco;
            fornecedorExistente.Telefone = dto.Telefone;
            fornecedorExistente.Email = dto.Email;

            return _repository.EditarDados(fornecedorExistente); // Atualiza e retorna a entidade
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            var fornecedorExistente = _repository.ObterPorId(id);
            if (fornecedorExistente == null)
            {
                // Opcional: lançar exceção ou retornar null
                return null;
            }

            return _repository.DeletarDados(id); // Deleta o fornecedor
        }
    }
}
