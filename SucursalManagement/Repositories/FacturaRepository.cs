using System;
using Dapper;
using Npgsql;
using SucursalManagement.Models;
using System.Collections.Generic;
using System.Data;

namespace SucursalManagement.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly string _connectionString;

        public FacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public IEnumerable<Factura> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Factura>("SELECT * FROM Factura");
            }
        }

        public Factura GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Factura>("SELECT * FROM Factura WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(Factura factura)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "INSERT INTO Factura (fecha, monto, cliente_id, sucursal_id) VALUES (@Fecha, @Monto, @ClienteId, @SucursalId)";
                dbConnection.Execute(query, factura);
            }
        }

        public void Update(Factura factura)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "UPDATE Factura SET fecha = @Fecha, monto = @Monto, cliente_id = @ClienteId, sucursal_id = @SucursalId WHERE id = @Id";
                dbConnection.Execute(query, factura);
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Factura WHERE id = @Id", new { Id = id });
            }
        }
    }
}

