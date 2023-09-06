using ClientesApi.Domain.Entities;
using ClientesApi.Domain.Interfaces.Repositories;
using ClientesApi.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApi.Domain.Services
{
    public class ClienteDomainService: IClienteDomainService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDomainService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Create(Cliente entity)
        {
            _clienteRepository.Create(entity);
        }

        public void Update(Cliente entity)
        {
            var cliente = _clienteRepository.GetById(entity.Id);

            cliente.Nome = entity.Nome;
            cliente.Email = entity.Email;
            cliente.Cpf = entity.Cpf;
            cliente.Telefone = entity.Telefone;
            cliente.DataHoraCriacao = entity.DataHoraCriacao = DateTime.Now;

            _clienteRepository.Update(cliente);

        }

        public void Delete(Cliente entity)
        {
            var cliente = _clienteRepository.GetById(entity.Id);

            _clienteRepository.Delete(cliente);
        }

        public List<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetById(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);

            return cliente;
        }
    }
}
