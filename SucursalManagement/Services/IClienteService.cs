using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SucursalManagement.Models;

namespace SucursalManagement.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        void CreateCliente(Cliente cliente);
        void UpdateCliente(Cliente cliente);
        void DeleteCliente(int id);
    }
}
