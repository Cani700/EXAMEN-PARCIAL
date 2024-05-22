using System;
using SucursalManagement.Models;
using System.Collections.Generic;

namespace SucursalManagement.Services
{
    public interface IFacturaService
    {
        IEnumerable<Factura> GetAllFacturas();
        Factura GetFacturaById(int id);
        void CreateFactura(Factura factura);
        void UpdateFactura(Factura factura);
        void DeleteFactura(int id);
    }
}
