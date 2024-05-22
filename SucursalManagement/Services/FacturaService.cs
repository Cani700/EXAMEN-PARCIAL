using System;
using SucursalManagement.Models;
using SucursalManagement.Repositories;
using System.Collections.Generic;

namespace SucursalManagement.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public IEnumerable<Factura> GetAllFacturas()
        {
            return _facturaRepository.GetAll();
        }

        public Factura GetFacturaById(int id)
        {
            return _facturaRepository.GetById(id);
        }

        public void CreateFactura(Factura factura)
        {
            _facturaRepository.Add(factura);
        }

        public void UpdateFactura(Factura factura)
        {
            _facturaRepository.Update(factura);
        }

        public void DeleteFactura(int id)
        {
            _facturaRepository.Delete(id);
        }
    }
}
