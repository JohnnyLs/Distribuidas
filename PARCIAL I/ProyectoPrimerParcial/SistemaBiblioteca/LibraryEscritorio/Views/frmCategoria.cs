using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;



namespace LibraryEscritorio.Views
{
    public partial class frmCategoria : Form
    {
        private readonly HttpClient _httpClient;

        public frmCategoria()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            txtNombreCategoria.KeyPress += txtNombres_KeyPress;
        }

        private async void frmCategoria_Load(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private async void btnCategoriaGuardar_Click(object sender, EventArgs e)
        {
            // Validar entrada
            string nombre = txtNombreCategoria.Text;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear objeto categoría
            var nuevaCategoria = new Categoria
            {
                Nombre = nombre,
                FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy") // Asignar fecha de creación actual
            };

            // Enviar solicitud POST
            try
            {
                string url = "http://localhost:12210/Categoria/Guardar";
                var content = new StringContent(JsonSerializer.Serialize(nuevaCategoria), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Categoría agregada exitosamente.");
                    await CargarCategorias(); // Recargar la lista de categorías
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar la categoría.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            txtNombreCategoria.Text = string.Empty;
            txtIdC.Text = string.Empty;
        }

        private async void btnCategoriaModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos actuales de los campos de texto
                string nombre = txtNombreCategoria.Text;

                // Validar que se haya seleccionado una fila en el DataGridView
                if (dgvData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría para modificar.");
                    return;
                }

                // Validar que todos los campos obligatorios estén llenos
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                // Obtener el IdCategoria de la fila seleccionada en el DataGridView
                int idCategoria = Convert.ToInt32(dgvData.SelectedRows[0].Cells["IdCategoria"].Value);

                // Construir el objeto Categoria con los datos modificados
                Categoria categoriaModificada = new Categoria
                {
                    IdCategoria = idCategoria,
                    Nombre = nombre
                };

                // Serializar el objeto Categoria a JSON
                var jsonCategoria = JsonSerializer.Serialize(categoriaModificada);

                // Configurar la solicitud PUT
                string url = $"http://localhost:12210/Categoria/Editar";
                var content = new StringContent(jsonCategoria, Encoding.UTF8, "application/json");

                // Realizar la solicitud PUT al servidor
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Categoría modificada exitosamente.");
                    LimpiarCampos();
                    await CargarCategorias();
                }
                else
                {
                    MessageBox.Show($"Error al modificar la categoría. Estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnCategoriaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila en el DataGridView
                if (dgvData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una categoría para eliminar.");
                    return;
                }

                // Obtener el IdCategoria de la fila seleccionada en el DataGridView
                int idCategoria = Convert.ToInt32(dgvData.SelectedRows[0].Cells["IdCategoria"].Value);
                string nombreCategoria = Convert.ToString(dgvData.SelectedRows[0].Cells["Nombre"].Value);

                // Confirmar con el usuario si desea eliminar
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar la categoría {nombreCategoria}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Construir la URL de la solicitud DELETE
                    string url = $"http://localhost:12210/Categoria/Eliminar?idCategoria={idCategoria}";

                    // Realizar la solicitud DELETE al servidor
                    HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Categoría eliminada exitosamente.");
                        LimpiarCampos();
                        await CargarCategorias();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar la categoría. Estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task CargarCategorias()
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

                    if (categoriasResponse != null && categoriasResponse.Data != null)
                    {
                        dgvData.Rows.Clear();
                        foreach (var categoria in categoriasResponse.Data)
                        {
                            dgvData.Rows.Add(null, categoria.IdCategoria, categoria.Nombre, categoria.FechaCreacion);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de categorías.");
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

        // Clase Categoria, asegúrate de que coincida con la del servicio
        public class Categoria
        {
            public int IdCategoria { get; set; }
            public string Nombre { get; set; }
            public string FechaCreacion { get; set; }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvData.Columns["btnSeleccionar"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                txtIdC.Text = row.Cells["IdCategoria"].Value.ToString();
                txtNombreCategoria.Text = row.Cells["Nombre"].Value.ToString();
            }
        }

        private void frmCategoria_Load_1(object sender, EventArgs e)
        {

        }

        private async void lblCategoriasLista_Click(object sender, EventArgs e)
        {
            await CargarCategorias();
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y algunos caracteres especiales como espacios, comas, etc.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'í' && e.KeyChar != 'é' && e.KeyChar != 'á' && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'ó' && e.KeyChar != 'ú')
            {
                e.Handled = true; // Cancelar la tecla presionada si no es válida
            }
        }

        private async void btnCargarCategoria_Click(object sender, EventArgs e)
        {
            await CargarCategorias();
        }
    }
}