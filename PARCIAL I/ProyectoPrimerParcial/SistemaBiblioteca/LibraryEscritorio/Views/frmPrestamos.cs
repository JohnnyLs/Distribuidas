using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaEntidades;


namespace LibraryEscritorio.Views
{
    public partial class frmPrestamos : Form
    {
        private readonly HttpClient _httpClient;
        public frmPrestamos()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            cboEstudiantes.DropDownStyle = ComboBoxStyle.DropDown;
            cboEstudiantes.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboEstudiantes.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboEstudiantes.TextUpdate += new EventHandler(cboEstudiantes_TextUpdate);

            cboLibros.DropDownStyle = ComboBoxStyle.DropDown;
            cboLibros.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboLibros.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboLibros.TextUpdate += new EventHandler(cboLibros_TextUpdate);


        }
        private async void cboEstudiantes_TextUpdate(object sender, EventArgs e)
        {
            string searchValue = cboEstudiantes.Text;
            await BuscarEstudiantes(searchValue);
        }
        private async void cboLibros_TextUpdate(object sender, EventArgs e)
        {
            string searchValue = cboLibros.Text;
            await BuscarLibros(searchValue);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLibros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void frmPrestamos_Load(object sender, EventArgs e)
        {

        }
        private async Task BuscarEstudiantes(string searchValue)
        {
            try
            {
                // Define la URL del endpoint con el parámetro de búsqueda
                string urlWithParams = $"http://localhost:12210/Prestamo/BusquedaEstudiante?buscar={searchValue}";

                // Realiza la solicitud GET
                HttpResponseMessage response = await _httpClient.GetAsync(urlWithParams);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var estudiantesResponse = JsonSerializer.Deserialize<List<Estudiante>>(jsonResponse, options);

                    // Actualiza el ComboBox con los resultados
                    if (estudiantesResponse != null)
                    {
                        cboEstudiantes.DataSource = null;
                        cboEstudiantes.Items.Clear();
                        foreach (var estudiante in estudiantesResponse)
                        {
                            cboEstudiantes.Items.Add(new { Text = $"{estudiante.Codigo} - {estudiante.Nombres} {estudiante.Apellidos}", Value = estudiante.IdEstudiante });
                        }
                        cboEstudiantes.DroppedDown = true;
                        cboEstudiantes.DisplayMember = "Text";
                        cboEstudiantes.ValueMember = "Value";
                        cboEstudiantes.IntegralHeight = true;
                        cboEstudiantes.SelectedIndex = -1;
                        cboEstudiantes.Text = searchValue;
                        cboEstudiantes.SelectionStart = searchValue.Length;
                        cboEstudiantes.SelectionLength = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de estudiantes.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
            }
        }
        private async Task BuscarLibros(string searchValue)
        {
            try
            {
                string urlWithParams = $"http://localhost:12210/Prestamo/BusquedaLibro?buscar={searchValue}";

                HttpResponseMessage response = await _httpClient.GetAsync(urlWithParams);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var librosResponse = JsonSerializer.Deserialize<List<Libro>>(jsonResponse, options);

                    if (librosResponse != null)
                    {
                        cboLibros.DataSource = null;
                        cboLibros.Items.Clear();
                        foreach (var libro in librosResponse)
                        {
                            cboLibros.Items.Add(new { Text = $"{libro.Codigo} - {libro.Titulo}", Value = libro.IdLibro });
                        }
                        cboLibros.DroppedDown = true;
                        cboLibros.DisplayMember = "Text";
                        cboLibros.ValueMember = "Value";
                        cboLibros.IntegralHeight = true;
                        cboLibros.SelectedIndex = -1;
                        cboLibros.Text = searchValue;
                        cboLibros.SelectionStart = searchValue.Length;
                        cboLibros.SelectionLength = 0;
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de libros.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
            }
        }


       

        // Clase para manejar la respuesta del servicio
        public class ResponseWrapper<T>
        {
            public T Data { get; set; }
        }

        // Clases Estudiante y Libro, asegúrate de que coincidan con las del servicio
        public class EstudianteDesktop
        {
            public int IdEstudiante { get; set; }
            public string Codigo { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
        }

        public class LibroDesktop
        {
            public int IdLibro { get; set; }
            public string Titulo { get; set; }
            
        }
        public class Prestamo
        {
            public int IdPrestamo { get; set; }
            public int IdEstudiante { get; set; }
            public int IdLibro { get; set; }
            public string FechaPrestamo { get; set; }
            
        }


        private async void btnPrestamoGuardar_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
