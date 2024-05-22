using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SucursalManagement.Models;
using SucursalManagement.Repositories;

namespace SucursalManagement.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente GetClienteById(int id)
        {
            return _clienteRepository.GetById(id);
        }

        public void CreateCliente(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void UpdateCliente(Cliente cliente)
        {
            _clienteRepository.Update(cliente);
        }

        public void DeleteCliente(int id)
        {
            _clienteRepository.Delete(id);
        }
    }
}
