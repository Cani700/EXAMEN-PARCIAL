using System;
using SucursalManagement.Models;
using System.Collections.Generic;

namespace SucursalManagement.Services
{
    public interface ISucursalService
    {
        IEnumerable<Sucursal> GetAllSucursales();
        Sucursal GetSucursalById(int id);
        void CreateSucursal(Sucursal sucursal);
        void UpdateSucursal(Sucursal sucursal);
        void DeleteSucursal(int id);
    }
}

