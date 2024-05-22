using System;
using SucursalManagement.Models;
using System.Collections.Generic;

namespace SucursalManagement.Repositories
{
    public interface IFacturaRepository
    {
        IEnumerable<Factura> GetAll();
        Factura GetById(int id);
        void Add(Factura factura);
        void Update(Factura factura);
        void Delete(int id);
    }
}

