
using SoapService.Models;
using MySql.Data.MySqlClient;

namespace SoapService.Services
{
    public class CustomerService : CustomerServiceContract
    {
        private readonly string _connectionString;

        public CustomerService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Libro> GetLibros()
        {
            List<Libro> libros = new List<Libro>();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM LIBROS";
                MySqlCommand command = new MySqlCommand(query, connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        libros.Add(new Libro
                        {
                            id = reader.GetInt32("id"),
                            nombre = reader.GetString("nombre"),
                            descripcion = reader.GetString("descripcion")
                        });
                    }
                }
            }

            return libros;
        }

        public void AgregarLibro(Libro libro)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO LIBROS(nombre, descripcion) VALUES (@nombre, @descripcion)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", libro.nombre);
                command.Parameters.AddWithValue("@descripcion", libro.descripcion);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarLibro(Libro libro)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE LIBROS SET nombre = @nombre, descripcion = @descripcion WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", libro.nombre);
                command.Parameters.AddWithValue("@descripcion", libro.descripcion);
                command.Parameters.AddWithValue("@id", libro.id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EliminarLibro(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM LIBROS WHERE id = @id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
