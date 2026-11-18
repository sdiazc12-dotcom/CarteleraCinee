using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CarteleraCinee

{
    public class FuncionRepositorio
    {
        private const string CadenaConexion =
            @"Server=(localdb)\MSSQLLocalDB;" +
            @"Database=CarteleraDB;" +
            @"Trusted_Connection=True;" +
            @"TrustServerCertificate=True;";

        public void Insertar(Funcion x)
        {
            string sql = "INSERT INTO Funciones (Pelicula, Sala, Precio) " +
                         "VALUES (@pelicula, @sala, @precio)";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@pelicula", x.Pelicula);
                comando.Parameters.AddWithValue("@sala", x.Sala);
                comando.Parameters.AddWithValue("@precio", x.Precio);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public List<Funcion> ListarTodos()
        {
            List<Funcion> lista = new List<Funcion>();
            string sql = "SELECT Id, Pelicula, Sala, Precio " +
                         "FROM Funciones ORDER BY Id";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Funcion
                        {
                            Id = lector.GetInt32(0),
                            Pelicula = lector.GetString(1),
                            Sala = lector.GetString(2),
                            Precio = lector.GetDecimal(3)
                        });
                    }
                }
            }
            return lista;
        }

        public Funcion? BuscarPorId(int id)
        {
            string sql = "SELECT Id, Pelicula, Sala, Precio " +
                         "FROM Funciones WHERE Id = @id";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        return new Funcion
                        {
                            Id = lector.GetInt32(0),
                            Pelicula = lector.GetString(1),
                            Sala = lector.GetString(2),
                            Precio = lector.GetDecimal(3)
                        };
                    }
                }
            }
            return null;
        }

        public bool Actualizar(Funcion x)
        {
            string sql = "UPDATE Funciones " +
                         "SET Pelicula = @pelicula, Sala = @sala, Precio = @precio " +
                         "WHERE Id = @id";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@pelicula", x.Pelicula);
                comando.Parameters.AddWithValue("@sala", x.Sala);
                comando.Parameters.AddWithValue("@precio", x.Precio);
                comando.Parameters.AddWithValue("@id", x.Id);

                conexion.Open();
                int filas = comando.ExecuteNonQuery();
                return filas == 1;
            }
        }

        public bool Eliminar(int id)
        {
            string sql = "DELETE FROM Funciones WHERE Id = @id";

            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                int filas = comando.ExecuteNonQuery();
                return filas == 1;
            }
        }
    }
}