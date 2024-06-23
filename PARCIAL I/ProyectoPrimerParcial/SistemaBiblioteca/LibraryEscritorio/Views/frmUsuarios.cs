using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json.Serialization;

namespace LibraryEscritorio.Views
{
    public partial class frmUsuarios : Form
    {
        private readonly HttpClient _httpClient;
        public frmUsuarios()
        {
            InitializeComponent();
            _httpClient = new HttpClient();

            txtNombreCompleto.KeyPress += txtNombreCompleto_KeyPress;
        }

        private async void btnUsuarioAgregar_Click(object sender, EventArgs e)
        {
            // Validar entradas
            string nombreCompleto = txtNombreCompleto.Text;
            string nombreUsuario = txtNombreUsuario.Text;
            string clave = txtClave.Text;
            string repetirClave = txtRepetirClave.Text;

            if (string.IsNullOrWhiteSpace(nombreCompleto) || string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave) || string.IsNullOrWhiteSpace(repetirClave))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (clave != repetirClave)
            {
                MessageBox.Show("Las contraseñas no coinciden.");
                return;
            }

            // Crear objeto usuario
            var nuevoUsuario = new Usuario
            {
                NombreCompleto = nombreCompleto,
                NombreUsuario = nombreUsuario,
                Clave = clave,
                FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy") // Asignar fecha de creación actual
            };

            // Enviar solicitud POST
            try
            {
                string url = "http://localhost:12210/Usuario/Guardar";
                var content = new StringContent(JsonSerializer.Serialize(nuevoUsuario), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario agregado exitosamente.");
                    await CargarUsuarios(); // Recargar la lista de usuarios
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar conectarse con el servicio: {ex.Message}");
            }
        }
        private void LimpiarCampos()
        {
            txtNombreCompleto.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtRepetirClave.Text = string.Empty;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar si se hizo clic en el botón btnSeleccionar
            if (e.ColumnIndex == dgvData.Columns["btnSeleccionar"].Index && e.RowIndex >= 0)
            {
                // Obtener los datos de la fila seleccionada
                DataGridViewRow row = dgvData.Rows[e.RowIndex];

                // Asignar los datos a los campos de texto
                txtId.Text = row.Cells["IdUsuario"].Value.ToString();
                txtNombreCompleto.Text = row.Cells["NombreCompleto"].Value.ToString();
                txtNombreUsuario.Text = row.Cells["NombreUsuario"].Value.ToString();
                //txtClave.Text = row.Cells["Clave"].Value.ToString();
            }
        }

        private async void btnUsuarioModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos actuales de los campos de texto
                string nombreCompleto = txtNombreCompleto.Text;
                string nombreUsuario = txtNombreUsuario.Text;
                string clave = txtClave.Text;
                string repetirClave = txtRepetirClave.Text;

                // Validar que se haya seleccionado una fila en el DataGridView
                if (dgvData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un usuario para modificar.");
                    return;
                }
                // Validar que todos los campos obligatorios estén llenos
                if (string.IsNullOrWhiteSpace(nombreCompleto) ||
                    string.IsNullOrWhiteSpace(nombreUsuario) ||
                    string.IsNullOrWhiteSpace(clave) ||
                    string.IsNullOrWhiteSpace(repetirClave))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }
                // Validar que las contraseñas coincidan
                if (clave != repetirClave)
                {
                    MessageBox.Show("Las contraseñas no coinciden.");
                    return;
                }

                // Obtener el IdUsuario de la fila seleccionada en el DataGridView
                int idUsuario = Convert.ToInt32(dgvData.SelectedRows[0].Cells["IdUsuario"].Value);

                // Construir el objeto Usuario con los datos modificados
                Usuario usuarioModificado = new Usuario
                {
                    IdUsuario = idUsuario,
                    NombreCompleto = nombreCompleto,
                    NombreUsuario = nombreUsuario,
                    Clave = clave
                };

                // Serializar el objeto Usuario a JSON
                var jsonUsuario = JsonSerializer.Serialize(usuarioModificado);

                // Configurar la solicitud PUT
                string url = $"http://localhost:12210/Usuario/Editar";
                var content = new StringContent(jsonUsuario, Encoding.UTF8, "application/json");

                // Realizar la solicitud PUT al servidor
                HttpResponseMessage response = await _httpClient.PutAsync(url, content);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario modificado exitosamente.");

                    // Limpiar los campos de texto
                    LimpiarCampos();

                    // Recargar la lista de usuarios en el DataGridView
                    await CargarUsuarios();
                }
                else
                {
                    MessageBox.Show($"Error al modificar el usuario. Estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void btnUsuarioEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si se ha seleccionado una fila en el DataGridView
                if (dgvData.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar un usuario para eliminar.");
                    return;
                }

                // Obtener el IdUsuario de la fila seleccionada en el DataGridView
                int idUsuario = Convert.ToInt32(dgvData.SelectedRows[0].Cells["IdUsuario"].Value);
                string nombreUsuario = Convert.ToString(dgvData.SelectedRows[0].Cells["NombreUsuario"].Value);

                // Confirmar con el usuario si desea eliminar
                DialogResult result = MessageBox.Show($"¿Está seguro que desea eliminar el usuario {nombreUsuario}?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Construir la URL de la solicitud DELETE
                    string url = $"http://localhost:12210/Usuario/Eliminar?idUsuario={idUsuario}";

                    // Realizar la solicitud DELETE al servidor
                    HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                    // Verificar si la solicitud fue exitosa
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.");

                        // Limpiar los campos de texto
                        LimpiarCampos();

                        // Recargar la lista de usuarios en el DataGridView
                        await CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show($"Error al eliminar el usuario. Estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async void frmUsuarios_Load(object sender, EventArgs e)
        {
            await CargarUsuarios();
        }
        private async Task CargarUsuarios()
        {
            try
            {
                string url = "http://localhost:12210/Usuario/Lista";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

                    };
                    var usuariosResponse = JsonSerializer.Deserialize<ResponseWrapper<List<Usuario>>>(jsonResponse, options);

                    if (usuariosResponse != null && usuariosResponse.Data != null)
                    {
                        dgvData.Rows.Clear();
                        foreach (var usuario in usuariosResponse.Data)
                        {

                            dgvData.Rows.Add(null, usuario.IdUsuario, usuario.NombreCompleto, usuario.NombreUsuario, null, usuario.FechaCreacion);

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener la lista de usuarios.");
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

        // Clase Usuario, asegúrate de que coincida con la del servicio
        public class Usuario
        {
            public int IdUsuario { get; set; }
            public string NombreCompleto { get; set; }
            public string NombreUsuario { get; set; }
            public string Clave { get; set; }
            public string FechaCreacion { get; set; }

        }

        private void txtNombreCompleto_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtNombreCompleto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras y algunos caracteres especiales como espacios, comas, etc.
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 'í' && e.KeyChar != 'é' && e.KeyChar != 'á' && e.KeyChar != 'ñ' && e.KeyChar != 'Ñ' && e.KeyChar != 'ó' && e.KeyChar != 'ú')
            {
                e.Handled = true; // Cancelar la tecla presionada si no es válida
            }
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRepetirClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

