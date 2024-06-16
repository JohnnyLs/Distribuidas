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
using static LibraryEscritorio.Views.Acceso;

namespace LibraryEscritorio.Views
{
    public partial class frmDashboars : Form
    {
        private readonly HttpClient _httpClient;
        public frmDashboars()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private async Task CargarDatosDashboard()
        {
            try
            {
                string url = "http://localhost:12210/Home/Dashboard";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var dashboardData = JsonSerializer.Deserialize<ResponseWrapper<DashboardDTO>>(jsonResponse, options);

                    if (dashboardData != null && dashboardData.Data != null)
                    {
                        lblTotalLibros.Text = dashboardData.Data.TotalLibro.ToString();
                        lblTotalEstudiantes.Text = dashboardData.Data.TotalEstudiante.ToString();
                        lblPrestamos.Text = dashboardData.Data.TotalPrestamos.ToString();
                        lblDevoluciones.Text = dashboardData.Data.TotalDevuelto.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener los datos del dashboard.");
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

        // Clase DashboardDTO, asegúrate de que coincida con la del servicio
        public class DashboardDTO
        {
            public int TotalLibro { get; set; }
            public int TotalEstudiante { get; set; }
            public int TotalPrestamos { get; set; }
            public int TotalDevuelto { get; set; }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void frmDashboars_Load(object sender, EventArgs e)
        {
            await CargarDatosDashboard();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTotalLibros_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalEstudiantes_Click(object sender, EventArgs e)
        {

        }

        private void lblPrestamos_Click(object sender, EventArgs e)
        {

        }

        private void lblDevoluciones_Click(object sender, EventArgs e)
        {

        }
    }
}
