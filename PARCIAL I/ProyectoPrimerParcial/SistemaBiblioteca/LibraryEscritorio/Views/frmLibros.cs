using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace LibraryEscritorio.Views
{
    public partial class frmLibros : Form
    {
        private readonly HttpClient _httpClient;

        public frmLibros()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            CargarCategorias(); // Cargar categorías al iniciar el formulario

            // Asociar evento SelectionChanged al DataGridView
            dgvData.SelectionChanged += dgvData_SelectionChanged;
            // Asociar eventos para validación de Autor y Cantidad
            txtLibroAutor.KeyPress += txtLibroAutor_KeyPress;
            txtLibroCantidad.Validating += txtLibroCantidad_Validating;
        }

        private async void CargarCategorias()
        {
            var categorias = await ObtenerCategorias();
            if (categorias != null && categorias.Count > 0)
            {
                cboLibros.DataSource = categorias;
                cboLibros.DisplayMember = "Nombre";
                cboLibros.ValueMember = "IdCategoria";
            }
        }

        private async Task<List<Categoria>> ObtenerCategorias()
        {
            try
            {
                string url = "http://localhost:12210/Categoria/Lista";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var categoriasResponse = JsonSerializer.Deserialize<ResponseWrapper<List<Categoria>>>(jsonResponse, options);
                    return categoriasResponse.Data;
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de categorías.");
                    return new List<Categoria>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
                return new List<Categoria>();
            }
        }

        private async void btnCargarLibros_Click(object sender, EventArgs e)
        {
            var libros = await ObtenerLibros();
            if (libros != null && libros.Count > 0)
            {
                dgvData.DataSource = libros;
            }
        }

        private async Task<List<LibroViewModel>> ObtenerLibros()
        {
            try
            {
                string url = "http://localhost:12210/Libro/Lista";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var librosResponse = JsonSerializer.Deserialize<ResponseWrapper<List<Libro>>>(jsonResponse, options);

                    var librosViewModel = librosResponse.Data.Select(l => new LibroViewModel
                    {
                        IdLibro = l.IdLibro,
                        Codigo = l.Codigo,
                        Titulo = l.Titulo,
                        Autor = l.Autor,
                        FechaPublicacion = l.FechaPublicacion,
                        Cantidad = l.Cantidad,
                        NombreCategoria = l.OCategoria?.Nombre


                    }).ToList();

                    return librosViewModel;
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de libros.");
                    return new List<LibroViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
                return new List<LibroViewModel>();
            }
        }

        private async void btnLibroGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear un nuevo objeto Libro con los datos del formulario
                var libro = new Libro
                {
                    Titulo = txtNombreLibro.Text,
                    Autor = txtLibroAutor.Text,
                    FechaPublicacion = dtpLibroFechaPublicacion.Value.ToString("yyyy-MM-dd"), // Asegúrate de formatear la fecha correctamente
                    Cantidad = int.Parse(txtLibroCantidad.Text),
                    OCategoria = new Categoria { IdCategoria = (int)cboLibros.SelectedValue, Nombre = cboLibros.Text }
                };

                // Serializar el objeto libro a JSON
                var jsonContent = new StringContent(JsonSerializer.Serialize(libro), Encoding.UTF8, "application/json");

                // Enviar la solicitud POST al servicio web para guardar el libro
                var response = await _httpClient.PostAsync("http://localhost:12210/Libro/Guardar", jsonContent);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Libro guardado exitosamente.");

                    // Limpiar los controles del formulario después de guardar
                    LimpiarControles();

                    // Opcional: recargar la lista de libros después de guardar
                    btnCargarLibros_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Error al guardar el libro. Código de estado: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar guardar el libro: {ex.Message}");
            }
        }

        // Método para limpiar los controles del formulario después de guardar
        private void LimpiarControles()
        {
            txtNombreLibro.Text = "";
            txtLibroAutor.Text = "";
            dtpLibroFechaPublicacion.Value = DateTime.Today;
            txtLibroCantidad.Text = "";
            cboLibros.SelectedIndex = -1; // Deseleccionar cualquier categoría seleccionada en el ComboBox
        }


        private async void btnLibroModificar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvData.SelectedRows.Count > 0)
                {
                    
                    int index = dgvData.SelectedRows[0].Index;

                   
                    LibroViewModel libroSeleccionado = dgvData.Rows[index].DataBoundItem as LibroViewModel;

                    
                    var libroModificado = new Libro
                    {
                        IdLibro = libroSeleccionado.IdLibro,
                        Titulo = txtNombreLibro.Text,
                        Autor = txtLibroAutor.Text,
                        FechaPublicacion = dtpLibroFechaPublicacion.Value.ToString("yyyy-MM-dd"), 
                        Cantidad = int.Parse(txtLibroCantidad.Text),
                        OCategoria = new Categoria { IdCategoria = (int)cboLibros.SelectedValue, Nombre = cboLibros.Text }
                    };

                    
                    var jsonContent = new StringContent(JsonSerializer.Serialize(libroModificado), Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await _httpClient.PutAsync("http://localhost:12210/Libro/Editar", jsonContent);

                    
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Libro modificado exitosamente.");

                        
                        btnCargarLibros_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show($"Error al modificar el libro. Código de estado: {response.StatusCode}");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un libro para modificar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar modificar el libro: {ex.Message}");
            }
        }




        private async void btnLibroEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dgvData.SelectedRows.Count > 0)
                {
                    
                    int index = dgvData.SelectedRows[0].Index;

                    
                    LibroViewModel libroSeleccionado = dgvData.Rows[index].DataBoundItem as LibroViewModel;

                    
                    DialogResult result = MessageBox.Show($"¿Estás seguro de eliminar el libro '{libroSeleccionado.Titulo}'?",
                                                          "Confirmación de Eliminación",
                                                          MessageBoxButtons.YesNo,
                                                          MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        
                        HttpResponseMessage response = await _httpClient.DeleteAsync($"http://localhost:12210/Libro/Eliminar?IdLibro={libroSeleccionado.IdLibro}");

                        
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Libro eliminado exitosamente.");

                            
                            btnCargarLibros_Click(sender, e);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el libro. Código de estado: " + response.StatusCode);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un libro para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar eliminar el libro: {ex.Message}");
            }
        }



        // Clase para manejar la respuesta del servicio
        public class ResponseWrapper<T>
        {
            public T Data { get; set; }
        }

        public class Libro
        {
            public int IdLibro { get; set; }
            public string Codigo { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string FechaPublicacion { get; set; }
            public int Cantidad { get; set; }
            public Categoria OCategoria { get; set; }
        }

        public class Categoria
        {
            public int IdCategoria { get; set; }
            public string Nombre { get; set; }
        }

        public class LibroViewModel
        {
            public int IdLibro { get; set; }
            public string Codigo { get; set; }
            public string Titulo { get; set; }
            public string Autor { get; set; }
            public string FechaPublicacion { get; set; }
            public int Cantidad { get; set; }
            public string NombreCategoria { get; set; }
        }

        private void cboLibros_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                // Obtener el índice de la fila seleccionada
                int index = dgvData.SelectedRows[0].Index;

                // Obtener el objeto LibroViewModel correspondiente
                LibroViewModel libroSeleccionado = dgvData.Rows[index].DataBoundItem as LibroViewModel;

                // Cargar los datos en los controles del formulario
                txtNombreLibro.Text = libroSeleccionado.Titulo;
                txtLibroAutor.Text = libroSeleccionado.Autor;
                dtpLibroFechaPublicacion.Value = DateTime.Parse(libroSeleccionado.FechaPublicacion);
                txtLibroCantidad.Text = libroSeleccionado.Cantidad.ToString();

                // Seleccionar la categoría en el ComboBox

                cboLibros.SelectedValue = libroSeleccionado.NombreCategoria;
                cboLibros.SelectedValue = ObtenerIdCategoriaPorNombre(libroSeleccionado.NombreCategoria);


            }
        }
        private int ObtenerIdCategoriaPorNombre(string nombreCategoria)
        {
            var categorias = cboLibros.DataSource as List<Categoria>;
            var categoria = categorias.FirstOrDefault(c => c.Nombre == nombreCategoria);
            return categoria?.IdCategoria ?? 0; // Retorna el IdCategoria encontrado o 0 si no se encuentra
        }

        private void txtLibroAutor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y algunos caracteres especiales como espacios, comas, etc.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'í' && e.KeyChar != 'é' && e.KeyChar != 'á' && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'ó' && e.KeyChar != 'ú')
            {
                e.Handled = true; // Cancelar la tecla presionada si no es válida
            }
        }

        private void txtLibroCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtLibroCantidad.Text, out int cantidad) || cantidad <= 0 || cantidad > 500)
            {
                MessageBox.Show("Por favor, introduce un número entero positivo entre 1 y 500 para la cantidad.");
                txtLibroCantidad.Focus(); // Poner el foco en el campo de cantidad
                e.Cancel = true; // Cancelar el evento de validación
            }
        }

        private void txtLibroCantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
