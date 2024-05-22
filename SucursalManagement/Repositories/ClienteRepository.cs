using Dapper;
using Npgsql;
using SucursalManagement.Models;
using System.Collections.Generic;
using System.Data;

namespace SucursalManagement.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new NpgsqlConnection(_connectionString);

        public IEnumerable<Cliente> GetAll()
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Cliente>("SELECT * FROM Cliente");
            }
        }

        public Cliente GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.QuerySingleOrDefault<Cliente>("SELECT * FROM Cliente WHERE Id = @Id", new { Id = id });
            }
        }

        public void Add(Cliente cliente)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "INSERT INTO Cliente (nombre, apellido, cedula, fechanacimiento, correo, estado) VALUES (@Nombre, @Apellido, @Cedula, @FechaNacimiento, @Correo, @Estado)";
                
                dbConnection.Execute(query, cliente);
            }
        }

        public void Update(Cliente cliente)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                var query = "UPDATE Cliente SET nombre = @Nombre, apellido = @Apellido, cedula = @Cedula, fechanacimiento = @FechaNacimiento, correo = @Correo, estado = @Estado WHERE id = @Id";
                dbConnection.Execute(query, cliente);
            }
        }

        public void Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Cliente WHERE id = @Id", new { Id = id });
            }
        }
    }
}
