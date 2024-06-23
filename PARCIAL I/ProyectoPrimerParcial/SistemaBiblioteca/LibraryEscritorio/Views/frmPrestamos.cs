using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
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

        private void label3_Click(object sender, EventArgs e) { }

        private void txtId_TextChanged(object sender, EventArgs e) { }

        private void cboEstudiantes_SelectedIndexChanged(object sender, EventArgs e) { }

        private void cboLibros_SelectedIndexChanged(object sender, EventArgs e) { }

        private async void frmPrestamos_Load(object sender, EventArgs e)
        {
            var prestamos = await ObtenerPrestamos();
            if (prestamos != null && prestamos.Count > 0)
            {
                dgvData.Columns["IdPrestamo"].Visible = false;
                dgvData.DataSource = prestamos;
                
            }
        }

        private async Task BuscarEstudiantes(string searchValue)
        {
            try
            {
                string urlWithParams = $"http://localhost:12210/Prestamo/BusquedaEstudiante?buscar={searchValue}";
                HttpResponseMessage response = await _httpClient.GetAsync(urlWithParams);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var estudiantesResponse = JsonSerializer.Deserialize<List<EstudianteDesktop>>(jsonResponse, options);

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
                    var librosResponse = JsonSerializer.Deserialize<List<LibroDesktop>>(jsonResponse, options);

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

        private async Task<List<PrestamoViewModel>> ObtenerPrestamos()
        {
            try
            {
                string url = "http://localhost:12210/Prestamo/Lista";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var prestamosResponse = JsonSerializer.Deserialize<ResponseWrapper<List<Prestamo>>>(jsonResponse, options);

                    // Transformar Prestamo a PrestamoViewModel
                    var prestamosViewModel = prestamosResponse.Data.Select(p => new PrestamoViewModel
                    {
                        IdPrestamo = p.IdPrestamo,
                        FechaPrestamo = p.FechaPrestamo,
                        FechaDevolucion = p.FechaDevolucion,
                        EstadoPrestamo = p.EstadoPrestamo,
                        CodigoEstudiante = p.OEstudiante.Codigo,
                        NombreEstudiante = $"{p.OEstudiante.Nombres} {p.OEstudiante.Apellidos}",
                        CodigoLibro = p.OLibro.Codigo,
                        TituloLibro = p.OLibro.Titulo
                    }).ToList();

                    return prestamosViewModel;
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de préstamos.");
                    return new List<PrestamoViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
                return new List<PrestamoViewModel>();
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
            public string Codigo { get; set; }
            public string Titulo { get; set; }
        }

        public class Prestamo
        {
            public int IdPrestamo { get; set; }
            public EstudianteDesktop OEstudiante { get; set; }
            public LibroDesktop OLibro { get; set; }
            public string FechaPrestamo { get; set; }
            public string FechaDevolucion { get; set; }
            public string EstadoPrestamo { get; set; }
        }

        public class PrestamoViewModel
        {
            public int IdPrestamo { get; set; }
            public string FechaPrestamo { get; set; }
            public string FechaDevolucion { get; set; }
            public string EstadoPrestamo { get; set; }
            public string CodigoEstudiante { get; set; }
            public string NombreEstudiante { get; set; }
            public string CodigoLibro { get; set; }
            public string TituloLibro { get; set; }
        }

        private async void btnPrestamoGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que se haya seleccionado un estudiante y un libro
                if (cboEstudiantes.SelectedItem == null || cboLibros.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un estudiante y un libro antes de guardar el préstamo.");
                    return;
                }

                // Crear objeto Prestamo
                var prestamo = new Prestamo
                {
                    OEstudiante = new EstudianteDesktop
                    {
                        IdEstudiante = (int)cboEstudiantes.SelectedItem.GetType().GetProperty("Value").GetValue(cboEstudiantes.SelectedItem)
                    },
                    OLibro = new LibroDesktop
                    {
                        IdLibro = (int)cboLibros.SelectedItem.GetType().GetProperty("Value").GetValue(cboLibros.SelectedItem)
                    },
                    FechaPrestamo = DateTime.Now.ToString("dd/MM/yyyy"),
                    // FechaDevolucion = dtpFechaDevolucion.Value.ToString("dd/MM/yyyy"),
                    EstadoPrestamo = "Prestado"
                };

                // Serializar a JSON
                var jsonContent = new StringContent(JsonSerializer.Serialize(prestamo), Encoding.UTF8, "application/json");

                // Enviar solicitud POST
                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:12210/Prestamo/Guardar", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Préstamo guardado con éxito.");

                    // Limpiar los ComboBox después de guardar
                    cboEstudiantes.DataSource = null;
                    cboEstudiantes.Items.Clear();
                    cboEstudiantes.Text = "";

                    cboLibros.DataSource = null;
                    cboLibros.Items.Clear();
                    cboLibros.Text = "";

                    // Refrescar la lista de préstamos
                    var prestamos = await ObtenerPrestamos();
                    if (prestamos != null && prestamos.Count > 0)
                    {
                        dgvData.DataSource = prestamos;
                    }
                }
                else
                {
                    MessageBox.Show("Error al guardar el préstamo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el préstamo: {ex.Message}");
            }
        }



        private async void btnPrestamoDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    var selectedPrestamo = (PrestamoViewModel)dgvData.SelectedRows[0].DataBoundItem;

                    // Verificar si el préstamo está anulado
                    if (selectedPrestamo.EstadoPrestamo == "Anulado")
                    {
                        MessageBox.Show("No se puede devolver un préstamo que ha sido anulado.");
                        return;
                    }

                    // Continuar con la devolución del préstamo
                    string url = $"http://localhost:12210/Prestamo/Devolver?IdPrestamo={selectedPrestamo.IdPrestamo}";
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Préstamo devuelto con éxito.");
                        // Refrescar la lista de préstamos
                        var prestamos = await ObtenerPrestamos();
                        if (prestamos != null && prestamos.Count > 0)
                        {
                            dgvData.DataSource = prestamos;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al devolver el préstamo.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un préstamo para devolver.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar devolver el préstamo: {ex.Message}");
            }
        }



        private async void btnPrestamoAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.SelectedRows.Count > 0)
                {
                    var selectedPrestamo = (PrestamoViewModel)dgvData.SelectedRows[0].DataBoundItem;

                    // Verificar si el préstamo está devuelto
                    if (selectedPrestamo.EstadoPrestamo == "Devuelto")
                    {
                        MessageBox.Show("No se puede anular un préstamo que ya ha sido devuelto.");
                        return;
                    }

                    // Continuar con la anulación del préstamo
                    string url = $"http://localhost:12210/Prestamo/Anular?IdPrestamo={selectedPrestamo.IdPrestamo}";
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Préstamo anulado con éxito.");
                        // Refrescar la lista de préstamos
                        var prestamos = await ObtenerPrestamos();
                        if (prestamos != null && prestamos.Count > 0)
                        {
                            dgvData.DataSource = prestamos;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al anular el préstamo.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un préstamo para anular.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar anular el préstamo: {ex.Message}");
            }
        }



    }
}
