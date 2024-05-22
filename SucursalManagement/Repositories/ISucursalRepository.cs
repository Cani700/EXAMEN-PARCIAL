using System;
using System.Collections.Generic;
using SucursalManagement.Models;


namespace SucursalManagement.Repositories
{
    public interface ISucursalRepository
    {
        IEnumerable<Sucursal> GetAll();
        Sucursal GetById(int id);
        void Add(Sucursal sucursal);
        void Update(Sucursal sucursal);
        void Delete(int id);
    }
}

