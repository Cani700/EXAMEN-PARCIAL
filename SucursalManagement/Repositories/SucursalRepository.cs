using System;
using Dapper;
using Npgsql;
using SucursalManagement.Models;
using System.Collections.Generic;
using System.Data;

namespace SucursalManagement.Repositories
{
    public class SucursalRepository : ISucursalRepository
    {
        private readonly string _connectionString;

        public SucursalRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public IEnumerable<Sucursal> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Sucursal>("SELECT * FROM Sucursal");
            }
        }

        public Sucursal GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Sucursal>("SELECT * FROM Sucursal WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(Sucursal sucursal)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "INSERT INTO Sucursal (nombre, direccion, telefono) VALUES (@Nombre, @Direccion, @Telefono)";
                dbConnection.Execute(query, sucursal);
            }
        }

        public void Update(Sucursal sucursal)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "UPDATE Sucursal SET nombre = @Nombre, direccion = @Direccion, telefono = @Telefono WHERE id = @Id";
                dbConnection.Execute(query, sucursal);
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Sucursal WHERE id = @Id", new { Id = id });
            }
        }
    }
}

