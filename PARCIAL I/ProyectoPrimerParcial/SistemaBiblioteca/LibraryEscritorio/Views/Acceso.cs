using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net.Http;
using System.Text.Json;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryEscritorio.Views
{
    public partial class Acceso : Form
    {
        private readonly HttpClient _httpClient;

        public Acceso()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private void Acceso_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void iconButton1_Click(object sender, EventArgs e)
        {
            // Obtener los datos del formulario
            string nombreUsuario = txtDocumento.Text;
            string clave = txtClave.Text;

            // Llamar al método de login
            var usuario = await Login(nombreUsuario, clave);

            if (usuario != null)
            {
                // Login exitoso
                Home form = new Home(usuario.NombreUsuario); // Pasar el nombre de usuario al formulario Home
                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;
            }
            else
            {
                // Login fallido
                MessageBox.Show("Usuario o clave incorrectos.");
            }

        }
        private async Task<Usuario> Login(string nombreUsuario, string clave)
        {
            try
            {
                string url = $"http://localhost:12210/Usuario/Login?nombreUsuario={nombreUsuario}&clave={clave}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse); // Imprimir el JSON de respuesta
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var usuario = JsonSerializer.Deserialize<ResponseWrapper<Usuario>>(jsonResponse, options);
                    return usuario?.Data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
                return null;
            }
        }


        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtClave.Text = "";

            this.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        // Clase para manejar la respuesta del servicio
        public class ResponseWrapper<T>
        {
            public T Data { get; set; }
        }

        // Clase Usuario, asegúrate de que coincida con la del servicio
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string NombreCompleto { get; set; }
            public string NombreUsuario { get; set; }
            public string Clave { get; set; }

        }
    }
}
