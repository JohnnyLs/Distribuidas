using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace LibraryEscritorio.Views
{
    public partial class Home : Form
    {
        private string _nombreUsuario;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Home(string nombreUsuario)
        {
            InitializeComponent();
            _nombreUsuario = nombreUsuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Mostrar el nombre de usuario en el formulario, por ejemplo, en un label
            lblNombreUsuario.Text = $"Bienvenido: {_nombreUsuario}";
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void menuTitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            //formulario.BackColor = Color.SteelBlue;

            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuDashboards_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmDashboars());
        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuLibros, new frmCategoria());
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuLibros, new frmLibros());
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
        }

        private void menuPrestamos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPrestamos());
        }

        private void menuEstudiantes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmEstudiantes());
        }

        private void menuLibros_Click(object sender, EventArgs e)
        {

        }
    }
}
