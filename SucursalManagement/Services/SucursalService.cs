using System;
using SucursalManagement.Models;
using SucursalManagement.Repositories;
using System.Collections.Generic;

namespace SucursalManagement.Services
{
    public class SucursalService : ISucursalService
    {
        private readonly ISucursalRepository _sucursalRepository;

        public SucursalService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }

        public IEnumerable<Sucursal> GetAllSucursales()
        {
            return _sucursalRepository.GetAll();
        }

        public Sucursal GetSucursalById(int id)
        {
            return _sucursalRepository.GetById(id);
        }

        public void CreateSucursal(Sucursal sucursal)
        {
            _sucursalRepository.Add(sucursal);
        }

        public void UpdateSucursal(Sucursal sucursal)
        {
            _sucursalRepository.Update(sucursal);
        }

        public void DeleteSucursal(int id)
        {
            _sucursalRepository.Delete(id);
        }
    }
}
