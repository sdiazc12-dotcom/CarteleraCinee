using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarteleraCinee

{
    public class Program
    {
        public static void Main(string[] args)
        {
            FuncionRepositorio repo = new FuncionRepositorio();
            string opcion;

            do
            {
                opcion = LeerOpcionMenu();

                switch (opcion)
                {
                    case "1":
                        RegistrarFuncion(repo);
                        break;
                    case "2":
                        ListarFunciones(repo);
                        break;
                    case "3":
                        BuscarFuncion(repo);
                        break;
                    case "4":
                        ActualizarPrecio(repo);
                        break;
                    case "5":
                        EliminarFuncion(repo);
                        break;
                    case "6":
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
            }
            while (opcion != "6");
        }

        private static string LeerOpcionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== MENÚ CARTELERA ===");
            Console.WriteLine("1. Registrar función");
            Console.WriteLine("2. Listar funciones");
            Console.WriteLine("3. Buscar función por Id");
            Console.WriteLine("4. Actualizar precio");
            Console.WriteLine("5. Eliminar función");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");
            return Console.ReadLine();
        }

        private static void RegistrarFuncion(FuncionRepositorio repo)
        {
            Console.WriteLine();
            Console.Write("Película: ");
            string pelicula = Console.ReadLine().Trim();

            Console.Write("Sala: ");
            string sala = Console.ReadLine().Trim();

            Console.Write("Precio: ");
            bool precioOk = decimal.TryParse(Console.ReadLine(), out decimal precio);

            if (!precioOk || precio <= 0
                || string.IsNullOrWhiteSpace(pelicula)
                || string.IsNullOrWhiteSpace(sala))
            {
                Console.WriteLine("Datos inválidos.");
                return;
            }

            try
            {
                repo.Insertar(new Funcion
                {
                    Pelicula = pelicula,
                    Sala = sala,
                    Precio = precio
                });

                Console.WriteLine("Función registrada.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);
            }
        }

        private static void ListarFunciones(FuncionRepositorio repo)
        {
            try
            {
                List<Funcion> lista = repo.ListarTodos();

                if (lista.Count == 0)
                {
                    Console.WriteLine("No hay funciones registradas.");
                    return;
                }

                decimal totalGeneral = 0;
                foreach (Funcion f in lista)
                {
                    Console.WriteLine(f);
                    totalGeneral += f.Precio;
                }

                Console.WriteLine($"TOTAL DE PRECIOS: Q {totalGeneral:N2}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);
            }
        }

        private static void BuscarFuncion(FuncionRepositorio repo)
        {
            Console.WriteLine();
            Console.Write("Id a buscar: ");
            bool idOk = int.TryParse(Console.ReadLine(), out int id);

            if (!idOk)
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            try
            {
                Funcion? f = repo.BuscarPorId(id);

                if (f == null)
                {
                    Console.WriteLine("No existe ese Id.");
                    return;
                }

                Console.WriteLine(f);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);
            }
        }

        private static void ActualizarPrecio(FuncionRepositorio repo)
        {
            Console.WriteLine();
            Console.Write("Id de la función a actualizar: ");
            bool idOk = int.TryParse(Console.ReadLine(), out int id);

            if (!idOk)
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            try
            {
                Funcion? f = repo.BuscarPorId(id);

                if (f == null)
                {
                    Console.WriteLine("No existe ese Id.");
                    return;
                }

                Console.WriteLine("Función actual: " + f);
                Console.Write("Nuevo precio: ");
                bool precioOk = decimal.TryParse(Console.ReadLine(), out decimal precio);

                if (!precioOk || precio <= 0)
                {
                    Console.WriteLine("Precio inválido.");
                    return;
                }

                f.Precio = precio;

                if (repo.Actualizar(f))
                {
                    Console.WriteLine("Función actualizada.");
                }
                else
                {
                    Console.WriteLine("No existe ese Id.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);
            }
        }

        private static void EliminarFuncion(FuncionRepositorio repo)
        {
            Console.WriteLine();
            Console.Write("Id de la función a eliminar: ");
            bool idOk = int.TryParse(Console.ReadLine(), out int id);

            if (!idOk)
            {
                Console.WriteLine("Id inválido.");
                return;
            }

            try
            {
                if (repo.Eliminar(id))
                {
                    Console.WriteLine("Función eliminada.");
                }
                else
                {
                    Console.WriteLine("No existe ese Id.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error de base de datos: " + ex.Message);
            }
        }
    }
}