using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;

namespace LibraryEscritorio.Views
{
    public partial class frmEstudiantes : Form
    {
        private readonly HttpClient _httpClient;

        public frmEstudiantes()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            txtNombresEstudiantes.KeyPress += txtNombres_KeyPress;
            txtApellidosEstudiantes.KeyPress += txtNombres_KeyPress;
        }

        private async void frmEstudiantes_Load(object sender, EventArgs e)
        {
            await CargarEstudiantes();
        }

        private async void btnEstudianteGuardar_Click(object sender, EventArgs e)
        {
            // Validar entradas
            string nombres = txtNombresEstudiantes.Text;
            string apellidos = txtApellidosEstudiantes.Text;


            if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // Crear objeto estudiante
            var nuevoEstudiante = new Estudiante
            {
                Nombres = nombres,
                Apellidos = apellidos,
                FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy") // Asignar fecha de creación actual
            };

            // Enviar solicitud POST
            try
            {
                string url = "http://localhost:12210/Estudiante/Guardar";
                var content = new StringContent(JsonSerializer.Serialize(nuevoEstudiante), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Estudiante agregado exitosamente.");
                    await CargarEstudiantes(); // Recargar la lista de estudiantes
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el estudiante.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            txtNombresEstudiantes.Text = string.Empty;
            txtApellidosEstudiantes.Text = string.Empty;
            txtIdE.Text = string.Empty;
        }

        private async void btnEstudianteModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos actuales de los campos de texto
                string nombres = txtNombresEstudiantes.Text;
                string apellidos = txtApellidosEstudiantes.Text;

                // Validar que se haya seleccionado una fila en el DataGridView
                if (dgvDataEstudiantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un estudiante para modificar.");
                    return;
                }

                // Validar que todos los campos obligatorios estén llenos
                if (string.IsNullOrWhiteSpace(nombres) || string.IsNullOrWhiteSpace(apellidos))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                // Obtener el IdEstudiante de la fila seleccionada en el DataGridView
                int idEstudiante = Convert.ToInt32(dgvDataEstudiantes.SelectedRows[0].Cells["IdEstudiante"].Value);

                // Construir el objeto Estudiante con los datos modificados
                Estudiante estudianteModificado = new Estudiante
                {
                    IdEstudiante = idEstudiante,
                    Nombres = nombres,
                    Apellidos = apellidos
                };

                // Serializar el objeto Estudiante a JSON
                var jsonEstudiante = JsonSerializer.Serialize(estudianteModificado);

                // Configurar la solicitud PUT
                string url = $"http://localhost:12210/Estudiante/Editar";
                var content = new StringContent(jsonEstudiante, Encoding.UTF8, "application/json");

                // Realizar la solicitud PUT al servidor
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Estudiante modificado exitosamente.");
                    LimpiarCampos();
                    await CargarEstudiantes();
                }
                else
                {
                    MessageBox.Show($"Error al modificar el estudiante. Estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnEstudianteEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila en el DataGridView
                if (dgvDataEstudiantes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un estudiante para eliminar.");
                    return;
                }

                // Obtener el IdEstudiante de la fila seleccionada en el DataGridView
                int idEstudiante = Convert.ToInt32(dgvDataEstudiantes.SelectedRows[0].Cells["IdEstudiante"].Value);
                string nombreEstudiante = Convert.ToString(dgvDataEstudiantes.SelectedRows[0].Cells["Nombres"].Value);

                // Confirmar con el usuario si desea eliminar
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el estudiante {nombreEstudiante}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Construir la URL de la solicitud DELETE
                    string url = $"http://localhost:12210/Estudiante/Eliminar?idEstudiante={idEstudiante}";

                    // Realizar la solicitud DELETE al servidor
                    HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Estudiante eliminado exitosamente.");
                        LimpiarCampos();
                        await CargarEstudiantes();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar el estudiante. Estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task CargarEstudiantes()
        {
            try
            {
                string url = "http://localhost:12210/Estudiante/Lista";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    };
                    var estudiantesResponse = JsonSerializer.Deserialize<ResponseWrapper<List<Estudiante>>>(jsonResponse, options);

                    if (estudiantesResponse != null && estudiantesResponse.Data != null)
                    {
                        dgvDataEstudiantes.Rows.Clear();
                        foreach (var estudiante in estudiantesResponse.Data)
                        {
                            dgvDataEstudiantes.Rows.Add(null, estudiante.IdEstudiante, estudiante.Codigo, estudiante.Nombres, estudiante.Apellidos, null);
                        }
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

        // Clase para manejar la respuesta del servicio
        public class ResponseWrapper<T>
        {
            public T Data { get; set; }
        }

        // Clase Estudiante, asegúrate de que coincida con la del servicio
        public class Estudiante
        {
            public int IdEstudiante { get; set; }
            public string Codigo { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string FechaCreacion { get; set; }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDataEstudiantes.Columns["btnSeleccionar"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDataEstudiantes.Rows[e.RowIndex];
                txtIdE.Text = row.Cells["IdEstudiante"].Value.ToString();
                txtNombresEstudiantes.Text = row.Cells["Nombres"].Value.ToString();
                txtApellidosEstudiantes.Text = row.Cells["Apellidos"].Value.ToString();
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y algunos caracteres especiales como espacios, comas, etc.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'í' && e.KeyChar != 'é' && e.KeyChar != 'á' && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'ó' && e.KeyChar != 'ú')
            {
                e.Handled = true; // Cancelar la tecla presionada si no es válida
            }
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}