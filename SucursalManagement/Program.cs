using Microsoft.Extensions.DependencyInjection;
using SucursalManagement.Models;
using SucursalManagement.Repositories;
using SucursalManagement.Services;
using System;
using System.Collections.Generic;

namespace SucursalManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de Dependency Injection
            var serviceProvider = new ServiceCollection()
                .AddTransient<IClienteRepository, ClienteRepository>(provider => new ClienteRepository("Host=localhost;Database=postgres;Username=postgres;Password=1234"))
                .AddTransient<IClienteService, ClienteService>()
                .AddTransient<ISucursalRepository, SucursalRepository>(provider => new SucursalRepository("Host=localhost;Database=postgres;Username=postgres;Password=1234"))
                .AddTransient<ISucursalService, SucursalService>()
                .AddTransient<IFacturaRepository, FacturaRepository>(provider => new FacturaRepository("Host=localhost;Database=postgres;Username=postgres;Password=1234"))
                .AddTransient<IFacturaService, FacturaService>()
                .BuildServiceProvider();  // El punto y coma va aquí, fuera del paréntesis


            var clienteService = serviceProvider.GetService<IClienteService>();

            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Agregar Cliente");
                Console.WriteLine("3. Actualizar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Salir");
                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarClientes(clienteService);
                        break;
                    case "2":
                        AgregarCliente(clienteService);
                        break;
                    case "3":
                        ActualizarCliente(clienteService);
                        break;
                    case "4":
                        EliminarCliente(clienteService);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        private static void ListarClientes(IClienteService clienteService)
        {
            var clientes = clienteService.GetAllClientes();
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"{cliente.Id}: {cliente.Nombre} {cliente.Apellido}, {cliente.Cedula}, {cliente.Correo}, {cliente.Estado}");
            }
        }

        private static void AgregarCliente(IClienteService clienteService)
        {
            var cliente = new Cliente();
            do
            {
                Console.WriteLine("Ingrese el nombre del cliente:");
                cliente.Nombre = Console.ReadLine();

                if (cliente.Nombre.Length < 3)
                {
                    Console.WriteLine("El nombre debe tener al menos 3 caracteres. Inténtelo de nuevo.");
                }
            }
            while (cliente.Nombre.Length < 3);


            do
            {
                Console.WriteLine("Ingrese el apellido del cliente:");
                cliente.Apellido = Console.ReadLine();

                if (cliente.Apellido.Length < 3)
                {
                    Console.WriteLine("El apellido debe tener al menos 3 caracteres. Inténtelo de nuevo.");
                }
            }
            while (cliente.Apellido.Length < 3);
            
            
            Console.WriteLine("Ingrese la cédula del cliente:");
            cliente.Cedula = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de nacimiento del cliente (yyyy-mm-dd):");
            if (DateTime.TryParse(Console.ReadLine(), out var fechaNacimiento))
            {
                cliente.FechaNacimiento = fechaNacimiento;
            }



            do
            {
                Console.WriteLine("Ingrese el correo del cliente:");
                cliente.Correo = Console.ReadLine();

                if (cliente.Correo.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Utiliza letras especiales");
                }
            }
            while (cliente.Correo.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase));


            Console.WriteLine("Ingrese el estado del cliente:");
            cliente.Estado = Console.ReadLine();

            clienteService.CreateCliente(cliente);
            Console.WriteLine("Cliente agregado exitosamente.");
        }

        private static void ActualizarCliente(IClienteService clienteService)
        {
            Console.WriteLine("Ingrese el ID del cliente a actualizar:");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                var cliente = clienteService.GetClienteById(id);
                if (cliente == null)
                {
                    Console.WriteLine("Cliente no encontrado.");
                    return;
                }

                do
                {
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    cliente.Nombre = Console.ReadLine();

                    if (cliente.Nombre.Length < 3)
                    {
                        Console.WriteLine("El nombre debe tener al menos 3 caracteres. Inténtelo de nuevo.");
                    }
                }
                while (cliente.Nombre.Length < 3);
               
               do
            {
                Console.WriteLine("Ingrese el apellido del cliente:");
                cliente.Apellido = Console.ReadLine();

                if (cliente.Apellido.Length < 3)
                {
                    Console.WriteLine("El apellido debe tener al menos 3 caracteres. Inténtelo de nuevo.");
                }
            }
            while (cliente.Apellido.Length < 3);
                Console.WriteLine("Ingrese la nueva cédula del cliente:");
                cliente.Cedula = Console.ReadLine();
                
                
                Console.WriteLine("Ingrese la nueva fecha de nacimiento del cliente (yyyy-mm-dd):");
                if (DateTime.TryParse(Console.ReadLine(), out var fechaNacimiento))
                {
                    cliente.FechaNacimiento = fechaNacimiento;
                }
                Console.WriteLine("Ingrese el nuevo correo del cliente:");
                cliente.Correo = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo estado del cliente:");
                cliente.Estado = Console.ReadLine();

                clienteService.UpdateCliente(cliente);
                Console.WriteLine("Cliente actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }

        private static void EliminarCliente(IClienteService clienteService)
        {
            Console.WriteLine("Ingrese el ID del cliente a eliminar:");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                clienteService.DeleteCliente(id);
                Console.WriteLine("Cliente eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }
    }
}

