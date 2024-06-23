namespace LibraryEscritorio.Views
{
    partial class frmLibros
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            txtIdC = new TextBox();
            lblLibrosLista = new Label();
            dgvData = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            IdCategoria = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            FechaCreacion = new DataGridViewTextBoxColumn();
            btnLibroEliminar = new FontAwesome.Sharp.IconButton();
            btnLibroModificar = new FontAwesome.Sharp.IconButton();
            btnLibroGuardar = new FontAwesome.Sharp.IconButton();
            txtNombreLibro = new TextBox();
            lblLibroTitulo = new Label();
            lblTituloLibro = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCargarLibros = new FontAwesome.Sharp.IconButton();
            lblAutorLibro = new Label();
            txtLibroAutor = new TextBox();
            lblLibroCategoria = new Label();
            cboLibros = new ComboBox();
            lblLibroCreacion = new Label();
            dtpLibroFechaPublicacion = new DateTimePicker();
            label3 = new Label();
            txtLibroCantidad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // txtIdC
            // 
            txtIdC.BorderStyle = BorderStyle.None;
            txtIdC.Location = new Point(222, 37);
            txtIdC.Name = "txtIdC";
            txtIdC.Size = new Size(26, 20);
            txtIdC.TabIndex = 57;
            txtIdC.Text = "0";
            // 
            // lblLibrosLista
            // 
            lblLibrosLista.BackColor = Color.SteelBlue;
            lblLibrosLista.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLibrosLista.ForeColor = Color.White;
            lblLibrosLista.Location = new Point(366, 28);
            lblLibrosLista.Name = "lblLibrosLista";
            lblLibrosLista.Size = new Size(704, 42);
            lblLibrosLista.TabIndex = 56;
            lblLibrosLista.Text = "LISTA DE LIBROS";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.BackgroundColor = Color.SteelBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, IdCategoria, Nombre, FechaCreacion });
            dgvData.Location = new Point(366, 89);
            dgvData.MultiSelect = false;
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvData.RowHeadersWidth = 51;
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dgvData.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvData.RowTemplate.Height = 32;
            dgvData.Size = new Size(704, 387);
            dgvData.TabIndex = 55;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.FillWeight = 15F;
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.MinimumWidth = 6;
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
            btnSeleccionar.Visible = false;
            btnSeleccionar.Width = 35;
            // 
            // IdCategoria
            // 
            IdCategoria.HeaderText = "IdCategoria";
            IdCategoria.MinimumWidth = 6;
            IdCategoria.Name = "IdCategoria";
            IdCategoria.ReadOnly = true;
            IdCategoria.Visible = false;
            IdCategoria.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Visible = false;
            Nombre.Width = 306;
            // 
            // FechaCreacion
            // 
            FechaCreacion.HeaderText = "Fecha de Creación";
            FechaCreacion.MinimumWidth = 6;
            FechaCreacion.Name = "FechaCreacion";
            FechaCreacion.ReadOnly = true;
            FechaCreacion.Visible = false;
            FechaCreacion.Width = 308;
            // 
            // btnLibroEliminar
            // 
            btnLibroEliminar.BackColor = Color.Brown;
            btnLibroEliminar.FlatStyle = FlatStyle.Flat;
            btnLibroEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLibroEliminar.ForeColor = Color.White;
            btnLibroEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnLibroEliminar.IconColor = Color.White;
            btnLibroEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLibroEliminar.IconSize = 30;
            btnLibroEliminar.Location = new Point(180, 438);
            btnLibroEliminar.Name = "btnLibroEliminar";
            btnLibroEliminar.Size = new Size(145, 38);
            btnLibroEliminar.TabIndex = 58;
            btnLibroEliminar.Text = "Eliminar";
            btnLibroEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLibroEliminar.UseVisualStyleBackColor = false;
            btnLibroEliminar.Click += btnLibroEliminar_Click;
            // 
            // btnLibroModificar
            // 
            btnLibroModificar.BackColor = Color.DodgerBlue;
            btnLibroModificar.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnLibroModificar.FlatStyle = FlatStyle.Flat;
            btnLibroModificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLibroModificar.ForeColor = Color.White;
            btnLibroModificar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnLibroModificar.IconColor = Color.White;
            btnLibroModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLibroModificar.IconSize = 30;
            btnLibroModificar.Location = new Point(31, 438);
            btnLibroModificar.Name = "btnLibroModificar";
            btnLibroModificar.Size = new Size(145, 39);
            btnLibroModificar.TabIndex = 54;
            btnLibroModificar.Text = "Modificar";
            btnLibroModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLibroModificar.UseVisualStyleBackColor = false;
            btnLibroModificar.Click += btnLibroModificar_Click;
            // 
            // btnLibroGuardar
            // 
            btnLibroGuardar.BackColor = Color.ForestGreen;
            btnLibroGuardar.FlatAppearance.BorderColor = Color.Green;
            btnLibroGuardar.FlatStyle = FlatStyle.Flat;
            btnLibroGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLibroGuardar.ForeColor = Color.White;
            btnLibroGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnLibroGuardar.IconColor = Color.White;
            btnLibroGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnLibroGuardar.IconSize = 30;
            btnLibroGuardar.Location = new Point(180, 375);
            btnLibroGuardar.Name = "btnLibroGuardar";
            btnLibroGuardar.Size = new Size(145, 39);
            btnLibroGuardar.TabIndex = 53;
            btnLibroGuardar.Text = "Guardar";
            btnLibroGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLibroGuardar.UseVisualStyleBackColor = false;
            btnLibroGuardar.Click += btnLibroGuardar_Click;
            // 
            // txtNombreLibro
            // 
            txtNombreLibro.BorderStyle = BorderStyle.FixedSingle;
            txtNombreLibro.Location = new Point(56, 104);
            txtNombreLibro.Name = "txtNombreLibro";
            txtNombreLibro.PlaceholderText = "Ingrese el nombre del libro";
            txtNombreLibro.Size = new Size(243, 27);
            txtNombreLibro.TabIndex = 52;
            // 
            // lblLibroTitulo
            // 
            lblLibroTitulo.AutoSize = true;
            lblLibroTitulo.BackColor = Color.White;
            lblLibroTitulo.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLibroTitulo.Location = new Point(31, 76);
            lblLibroTitulo.Name = "lblLibroTitulo";
            lblLibroTitulo.Size = new Size(60, 25);
            lblLibroTitulo.TabIndex = 51;
            lblLibroTitulo.Text = "Titulo:";
            // 
            // lblTituloLibro
            // 
            lblTituloLibro.AutoSize = true;
            lblTituloLibro.BackColor = Color.White;
            lblTituloLibro.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloLibro.Location = new Point(31, 28);
            lblTituloLibro.Name = "lblTituloLibro";
            lblTituloLibro.Size = new Size(70, 31);
            lblTituloLibro.TabIndex = 50;
            lblTituloLibro.Text = "Libro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(-17, 50);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 49;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Left;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(360, 499);
            label1.TabIndex = 48;
            // 
            // btnCargarLibros
            // 
            btnCargarLibros.BackColor = Color.Gold;
            btnCargarLibros.FlatAppearance.BorderColor = Color.Green;
            btnCargarLibros.FlatStyle = FlatStyle.Flat;
            btnCargarLibros.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCargarLibros.ForeColor = Color.White;
            btnCargarLibros.IconChar = FontAwesome.Sharp.IconChar.School;
            btnCargarLibros.IconColor = Color.White;
            btnCargarLibros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCargarLibros.IconSize = 30;
            btnCargarLibros.Location = new Point(29, 375);
            btnCargarLibros.Name = "btnCargarLibros";
            btnCargarLibros.Size = new Size(145, 39);
            btnCargarLibros.TabIndex = 59;
            btnCargarLibros.Text = "Cargar";
            btnCargarLibros.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCargarLibros.UseVisualStyleBackColor = false;
            btnCargarLibros.Click += btnCargarLibros_Click;
            // 
            // lblAutorLibro
            // 
            lblAutorLibro.AutoSize = true;
            lblAutorLibro.BackColor = Color.White;
            lblAutorLibro.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAutorLibro.Location = new Point(31, 134);
            lblAutorLibro.Name = "lblAutorLibro";
            lblAutorLibro.Size = new Size(62, 25);
            lblAutorLibro.TabIndex = 60;
            lblAutorLibro.Text = "Autor:";
            // 
            // txtLibroAutor
            // 
            txtLibroAutor.BorderStyle = BorderStyle.FixedSingle;
            txtLibroAutor.Location = new Point(56, 162);
            txtLibroAutor.Name = "txtLibroAutor";
            txtLibroAutor.PlaceholderText = "Ingrese el nombre del libro";
            txtLibroAutor.Size = new Size(243, 27);
            txtLibroAutor.TabIndex = 61;
            // 
            // lblLibroCategoria
            // 
            lblLibroCategoria.AutoSize = true;
            lblLibroCategoria.BackColor = Color.White;
            lblLibroCategoria.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLibroCategoria.Location = new Point(29, 192);
            lblLibroCategoria.Name = "lblLibroCategoria";
            lblLibroCategoria.Size = new Size(92, 25);
            lblLibroCategoria.TabIndex = 62;
            lblLibroCategoria.Text = "Categoria:";
            // 
            // cboLibros
            // 
            cboLibros.FormattingEnabled = true;
            cboLibros.Location = new Point(56, 220);
            cboLibros.Name = "cboLibros";
            cboLibros.Size = new Size(250, 28);
            cboLibros.TabIndex = 63;
            cboLibros.SelectedIndexChanged += cboLibros_SelectedIndexChanged;
            // 
            // lblLibroCreacion
            // 
            lblLibroCreacion.AutoSize = true;
            lblLibroCreacion.BackColor = Color.White;
            lblLibroCreacion.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLibroCreacion.Location = new Point(31, 251);
            lblLibroCreacion.Name = "lblLibroCreacion";
            lblLibroCreacion.Size = new Size(156, 25);
            lblLibroCreacion.TabIndex = 64;
            lblLibroCreacion.Text = "Fecha de creación:";
            // 
            // dtpLibroFechaPublicacion
            // 
            dtpLibroFechaPublicacion.Location = new Point(56, 279);
            dtpLibroFechaPublicacion.Name = "dtpLibroFechaPublicacion";
            dtpLibroFechaPublicacion.Size = new Size(250, 27);
            dtpLibroFechaPublicacion.TabIndex = 65;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(33, 309);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 66;
            label3.Text = "Cantidad:";
            // 
            // txtLibroCantidad
            // 
            txtLibroCantidad.BorderStyle = BorderStyle.FixedSingle;
            txtLibroCantidad.Location = new Point(56, 337);
            txtLibroCantidad.Name = "txtLibroCantidad";
            txtLibroCantidad.PlaceholderText = "Ingrese la cantidad";
            txtLibroCantidad.Size = new Size(243, 27);
            txtLibroCantidad.TabIndex = 67;
            txtLibroCantidad.TextChanged += txtLibroCantidad_TextChanged;
            // 
            // frmLibros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1076, 499);
            Controls.Add(txtLibroCantidad);
            Controls.Add(label3);
            Controls.Add(dtpLibroFechaPublicacion);
            Controls.Add(lblLibroCreacion);
            Controls.Add(cboLibros);
            Controls.Add(lblLibroCategoria);
            Controls.Add(txtLibroAutor);
            Controls.Add(lblAutorLibro);
            Controls.Add(btnCargarLibros);
            Controls.Add(txtIdC);
            Controls.Add(lblLibrosLista);
            Controls.Add(dgvData);
            Controls.Add(btnLibroEliminar);
            Controls.Add(btnLibroModificar);
            Controls.Add(btnLibroGuardar);
            Controls.Add(txtNombreLibro);
            Controls.Add(lblLibroTitulo);
            Controls.Add(lblTituloLibro);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmLibros";
            Text = "frmLibros";
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdC;
        private Label lblLibrosLista;
        private DataGridView dgvData;
        private FontAwesome.Sharp.IconButton btnLibroEliminar;
        private FontAwesome.Sharp.IconButton btnLibroModificar;
        private FontAwesome.Sharp.IconButton btnLibroGuardar;
        private TextBox txtNombreLibro;
        private Label lblLibroTitulo;
        private Label lblTituloLibro;
        private Label label2;
        private Label label1;
        private FontAwesome.Sharp.IconButton btnCargarLibros;
        private Label lblAutorLibro;
        private TextBox txtLibroAutor;
        private Label lblLibroCategoria;
        private ComboBox cboLibros;
        private Label lblLibroCreacion;
        private DateTimePicker dtpLibroFechaPublicacion;
        private Label label3;
        private TextBox txtLibroCantidad;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn IdCategoria;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn FechaCreacion;
    }
}