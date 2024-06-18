namespace LibraryEscritorio.Views
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menu = new MenuStrip();
            menuDashboards = new FontAwesome.Sharp.IconMenuItem();
            menuUsuarios = new FontAwesome.Sharp.IconMenuItem();
            menuPrestamos = new FontAwesome.Sharp.IconMenuItem();
            menuLibros = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            menuEstudiantes = new FontAwesome.Sharp.IconMenuItem();
            menuTitulo = new MenuStrip();
            lblNombreUsuario = new ToolStripTextBox();
            label1 = new Label();
            contenedor = new Panel();
            menu.SuspendLayout();
            menuTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.BackColor = Color.White;
            menu.ImageScalingSize = new Size(20, 20);
            menu.Items.AddRange(new ToolStripItem[] { menuDashboards, menuUsuarios, menuPrestamos, menuLibros, menuEstudiantes });
            menu.Location = new Point(0, 90);
            menu.Name = "menu";
            menu.Size = new Size(1109, 107);
            menu.TabIndex = 1;
            menu.Text = "menuStrip2";
            menu.ItemClicked += menu_ItemClicked;
            // 
            // menuDashboards
            // 
            menuDashboards.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuDashboards.ForeColor = Color.SteelBlue;
            menuDashboards.IconChar = FontAwesome.Sharp.IconChar.BarChart;
            menuDashboards.IconColor = Color.SteelBlue;
            menuDashboards.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuDashboards.IconSize = 68;
            menuDashboards.ImageScaling = ToolStripItemImageScaling.None;
            menuDashboards.Name = "menuDashboards";
            menuDashboards.RightToLeft = RightToLeft.Yes;
            menuDashboards.RightToLeftAutoMirrorImage = true;
            menuDashboards.Rotation = 270D;
            menuDashboards.Size = new Size(144, 103);
            menuDashboards.Text = "Dashboard";
            menuDashboards.TextImageRelation = TextImageRelation.ImageAboveText;
            menuDashboards.Click += menuDashboards_Click;
            // 
            // menuUsuarios
            // 
            menuUsuarios.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuUsuarios.ForeColor = Color.SteelBlue;
            menuUsuarios.IconChar = FontAwesome.Sharp.IconChar.UsersCog;
            menuUsuarios.IconColor = Color.SteelBlue;
            menuUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuUsuarios.IconSize = 68;
            menuUsuarios.ImageScaling = ToolStripItemImageScaling.None;
            menuUsuarios.Name = "menuUsuarios";
            menuUsuarios.Size = new Size(121, 103);
            menuUsuarios.Text = "Usuarios";
            menuUsuarios.TextImageRelation = TextImageRelation.ImageAboveText;
            menuUsuarios.Click += menuUsuarios_Click;
            // 
            // menuPrestamos
            // 
            menuPrestamos.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuPrestamos.ForeColor = Color.SteelBlue;
            menuPrestamos.IconChar = FontAwesome.Sharp.IconChar.Tags;
            menuPrestamos.IconColor = Color.SteelBlue;
            menuPrestamos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuPrestamos.IconSize = 68;
            menuPrestamos.ImageScaling = ToolStripItemImageScaling.None;
            menuPrestamos.Name = "menuPrestamos";
            menuPrestamos.Size = new Size(139, 103);
            menuPrestamos.Text = "Prestamos";
            menuPrestamos.TextImageRelation = TextImageRelation.ImageAboveText;
            menuPrestamos.Click += menuPrestamos_Click;
            // 
            // menuLibros
            // 
            menuLibros.DropDownItems.AddRange(new ToolStripItem[] { iconMenuItem1, iconMenuItem2 });
            menuLibros.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuLibros.ForeColor = Color.SteelBlue;
            menuLibros.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            menuLibros.IconColor = Color.SteelBlue;
            menuLibros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuLibros.IconSize = 68;
            menuLibros.ImageScaling = ToolStripItemImageScaling.None;
            menuLibros.Name = "menuLibros";
            menuLibros.Size = new Size(94, 103);
            menuLibros.Text = "Libros";
            menuLibros.TextImageRelation = TextImageRelation.ImageAboveText;
            menuLibros.Click += menuLibros_Click;
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconMenuItem1.ForeColor = Color.SteelBlue;
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(224, 28);
            iconMenuItem1.Text = "Categorias";
            iconMenuItem1.Click += iconMenuItem1_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.Font = new Font("Nirmala UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconMenuItem2.ForeColor = Color.SteelBlue;
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(224, 28);
            iconMenuItem2.Text = "Lista Libros";
            iconMenuItem2.Click += iconMenuItem2_Click;
            // 
            // menuEstudiantes
            // 
            menuEstudiantes.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuEstudiantes.ForeColor = Color.SteelBlue;
            menuEstudiantes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            menuEstudiantes.IconColor = Color.SteelBlue;
            menuEstudiantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            menuEstudiantes.IconSize = 68;
            menuEstudiantes.ImageScaling = ToolStripItemImageScaling.None;
            menuEstudiantes.Name = "menuEstudiantes";
            menuEstudiantes.Size = new Size(151, 103);
            menuEstudiantes.Text = "Estudiantes";
            menuEstudiantes.TextImageRelation = TextImageRelation.ImageAboveText;
            menuEstudiantes.Click += menuEstudiantes_Click;
            // 
            // menuTitulo
            // 
            menuTitulo.AutoSize = false;
            menuTitulo.BackColor = Color.SteelBlue;
            menuTitulo.ImageScalingSize = new Size(20, 20);
            menuTitulo.Items.AddRange(new ToolStripItem[] { lblNombreUsuario });
            menuTitulo.Location = new Point(0, 0);
            menuTitulo.Name = "menuTitulo";
            menuTitulo.RightToLeft = RightToLeft.Yes;
            menuTitulo.Size = new Size(1109, 90);
            menuTitulo.TabIndex = 2;
            menuTitulo.Text = "menuStrip3";
            menuTitulo.ItemClicked += menuTitulo_ItemClicked;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = false;
            lblNombreUsuario.BackColor = Color.SteelBlue;
            lblNombreUsuario.BorderStyle = BorderStyle.None;
            lblNombreUsuario.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreUsuario.ForeColor = Color.White;
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(300, 38);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.SteelBlue;
            label1.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(46, 26);
            label1.Name = "label1";
            label1.Size = new Size(168, 31);
            label1.TabIndex = 3;
            label1.Text = "LIBRARY4FUN";
            label1.Click += label1_Click_1;
            // 
            // contenedor
            // 
            contenedor.Dock = DockStyle.Fill;
            contenedor.Location = new Point(0, 197);
            contenedor.Name = "contenedor";
            contenedor.Size = new Size(1109, 499);
            contenedor.TabIndex = 4;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 696);
            Controls.Add(contenedor);
            Controls.Add(label1);
            Controls.Add(menu);
            Controls.Add(menuTitulo);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += Home_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            menuTitulo.ResumeLayout(false);
            menuTitulo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private MenuStrip menuTitulo;
        private Label label1;
        private FontAwesome.Sharp.IconMenuItem menuEstudiantes;
        private FontAwesome.Sharp.IconMenuItem menuDashboards;
        private FontAwesome.Sharp.IconMenuItem menuUsuarios;
        private FontAwesome.Sharp.IconMenuItem menuPrestamos;
        private FontAwesome.Sharp.IconMenuItem menuLibros;
        private Panel contenedor;
        private ToolStripTextBox lblNombreUsuario;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
    }
}