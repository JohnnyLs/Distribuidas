using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using SoapService.Models;

public class MySQLDB
{
    private readonly string _connectionString;

    public MySQLDB(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Libro> GetLibros()
    {
        List<Libro> libros = new List<Libro>();
        using (MySqlConnection con = new MySqlConnection(_connectionString))
        {
            string query = "SELECT id, nombre, descripcion, fecha, precio, numero_pagina FROM LIBROS";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Libro libro = new Libro();
                        libro.id = Convert.ToInt32(reader["id"]);
                        libro.nombre = reader["nombre"].ToString();
                        libro.descripcion = reader["descripcion"].ToString();
                        libro.fecha = Convert.ToDateTime(reader["fecha"]);
                        libro.precio = Convert.ToDecimal(reader["precio"]);
                        libro.numero_paginas = Convert.ToInt32(reader["numero_paginas"]);
                        libros.Add(libro);
                    }
                }
            }
        }
        return libros;
    }
    
    public void AgregarLibro(Libro libro)
    {
        using (MySqlConnection con = new MySqlConnection(_connectionString))
        {
            string query = "INSERT INTO LIBROS(nombre, descripcion, fecha, precio, numero_paginas) VALUES (@nombre, @descripcion, @fecha, @precio, @paginas)";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Nombre", libro.nombre);
                cmd.Parameters.AddWithValue("@Descripcion", libro.descripcion);
                cmd.Parameters.AddWithValue("@Fecha", libro.fecha);
                cmd.Parameters.AddWithValue("@Precio", libro.precio);
                cmd.Parameters.AddWithValue("@Paginas", libro.numero_paginas);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void ActualizarLibro(Libro libro)
    {
        using (MySqlConnection con = new MySqlConnection(_connectionString))
        {
            string query = "UPDATE LIBROS SET nombre = @nombre, descripcion = @descripcion, fecha = @fecha, precio = @precio, numero_paginas = @paginas WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@nombre", libro.nombre);
                cmd.Parameters.AddWithValue("@descripcion", libro.descripcion);
                cmd.Parameters.AddWithValue("@fecha", libro.descripcion);
                cmd.Parameters.AddWithValue("@precio", libro.descripcion);
                cmd.Parameters.AddWithValue("@paginas", libro.descripcion);
                cmd.Parameters.AddWithValue("@id", libro.id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void EliminarLibro(int id)
    {
        using (MySqlConnection con = new MySqlConnection(_connectionString))
        {
            string query = "DELETE FROM LIBROS WHERE id = @Id";
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

