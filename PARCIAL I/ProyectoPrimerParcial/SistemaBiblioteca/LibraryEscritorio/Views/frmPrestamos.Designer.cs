namespace LibraryEscritorio.Views
{
    partial class frmPrestamos
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
            txtId = new TextBox();
            label8 = new Label();
            dgvData = new DataGridView();
            btnSeleccionarPrestamo = new DataGridViewButtonColumn();
            IdPrestamo = new DataGridViewTextBoxColumn();
            FechaPrestamo = new DataGridViewTextBoxColumn();
            IdEstudiante = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Estudiante = new DataGridViewTextBoxColumn();
            IdLibro = new DataGridViewTextBoxColumn();
            CodigoLibro = new DataGridViewTextBoxColumn();
            Titulo = new DataGridViewTextBoxColumn();
            FechaDevolucion = new DataGridViewTextBoxColumn();
            EstadoPrestamo = new DataGridViewTextBoxColumn();
            btnPrestamoAnular = new FontAwesome.Sharp.IconButton();
            btnPrestamoDevolver = new FontAwesome.Sharp.IconButton();
            btnPrestamoGuardar = new FontAwesome.Sharp.IconButton();
            lblPrestamoLibro = new Label();
            lblPrestamoEstudiante = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            cboEstudiantes = new ComboBox();
            cboLibros = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.BorderStyle = BorderStyle.None;
            txtId.Location = new Point(251, 37);
            txtId.Name = "txtId";
            txtId.Size = new Size(26, 20);
            txtId.TabIndex = 33;
            txtId.Text = "0";
            txtId.TextChanged += txtId_TextChanged;
            // 
            // label8
            // 
            label8.BackColor = Color.SteelBlue;
            label8.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(334, 15);
            label8.Name = "label8";
            label8.Size = new Size(874, 42);
            label8.TabIndex = 32;
            label8.Text = "LISTA DE PRESTAMOS\r\n:";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.BackgroundColor = Color.SteelBlue;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.Padding = new Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = Color.White;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionarPrestamo, IdPrestamo, FechaPrestamo, IdEstudiante, Codigo, Estudiante, IdLibro, CodigoLibro, Titulo, FechaDevolucion, EstadoPrestamo });
            dgvData.Location = new Point(334, 62);
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
            dgvData.Size = new Size(734, 394);
            dgvData.TabIndex = 31;
            // 
            // btnSeleccionarPrestamo
            // 
            btnSeleccionarPrestamo.FillWeight = 15F;
            btnSeleccionarPrestamo.HeaderText = "";
            btnSeleccionarPrestamo.MinimumWidth = 6;
            btnSeleccionarPrestamo.Name = "btnSeleccionarPrestamo";
            btnSeleccionarPrestamo.ReadOnly = true;
            btnSeleccionarPrestamo.Visible = false;
            btnSeleccionarPrestamo.Width = 35;
            // 
            // IdPrestamo
            // 
            IdPrestamo.HeaderText = "IdPrestamo";
            IdPrestamo.MinimumWidth = 6;
            IdPrestamo.Name = "IdPrestamo";
            IdPrestamo.ReadOnly = true;
            IdPrestamo.Visible = false;
            IdPrestamo.Width = 30;
            // 
            // FechaPrestamo
            // 
            FechaPrestamo.HeaderText = "Fecha Prestamo";
            FechaPrestamo.MinimumWidth = 6;
            FechaPrestamo.Name = "FechaPrestamo";
            FechaPrestamo.ReadOnly = true;
            FechaPrestamo.Visible = false;
            FechaPrestamo.Width = 120;
            // 
            // IdEstudiante
            // 
            IdEstudiante.HeaderText = "IdEstudiante";
            IdEstudiante.MinimumWidth = 6;
            IdEstudiante.Name = "IdEstudiante";
            IdEstudiante.ReadOnly = true;
            IdEstudiante.Visible = false;
            IdEstudiante.Width = 125;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.MinimumWidth = 6;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Visible = false;
            Codigo.Width = 80;
            // 
            // Estudiante
            // 
            Estudiante.HeaderText = "Estudiante";
            Estudiante.MinimumWidth = 6;
            Estudiante.Name = "Estudiante";
            Estudiante.ReadOnly = true;
            Estudiante.Visible = false;
            Estudiante.Width = 125;
            // 
            // IdLibro
            // 
            IdLibro.HeaderText = "IdLibro";
            IdLibro.MinimumWidth = 6;
            IdLibro.Name = "IdLibro";
            IdLibro.ReadOnly = true;
            IdLibro.Visible = false;
            IdLibro.Width = 125;
            // 
            // CodigoLibro
            // 
            CodigoLibro.HeaderText = "Codigo Libro";
            CodigoLibro.MinimumWidth = 6;
            CodigoLibro.Name = "CodigoLibro";
            CodigoLibro.ReadOnly = true;
            CodigoLibro.Visible = false;
            CodigoLibro.Width = 125;
            // 
            // Titulo
            // 
            Titulo.HeaderText = "Titulo";
            Titulo.MinimumWidth = 6;
            Titulo.Name = "Titulo";
            Titulo.ReadOnly = true;
            Titulo.Visible = false;
            Titulo.Width = 125;
            // 
            // FechaDevolucion
            // 
            FechaDevolucion.HeaderText = "Fecha Devolución";
            FechaDevolucion.MinimumWidth = 6;
            FechaDevolucion.Name = "FechaDevolucion";
            FechaDevolucion.ReadOnly = true;
            FechaDevolucion.Visible = false;
            FechaDevolucion.Width = 120;
            // 
            // EstadoPrestamo
            // 
            EstadoPrestamo.HeaderText = "Estado Prestamo";
            EstadoPrestamo.MinimumWidth = 6;
            EstadoPrestamo.Name = "EstadoPrestamo";
            EstadoPrestamo.ReadOnly = true;
            EstadoPrestamo.Visible = false;
            EstadoPrestamo.Width = 190;
            // 
            // btnPrestamoAnular
            // 
            btnPrestamoAnular.BackColor = Color.Brown;
            btnPrestamoAnular.FlatStyle = FlatStyle.Flat;
            btnPrestamoAnular.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrestamoAnular.ForeColor = Color.White;
            btnPrestamoAnular.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnPrestamoAnular.IconColor = Color.White;
            btnPrestamoAnular.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrestamoAnular.IconSize = 30;
            btnPrestamoAnular.Location = new Point(77, 391);
            btnPrestamoAnular.Name = "btnPrestamoAnular";
            btnPrestamoAnular.Size = new Size(145, 38);
            btnPrestamoAnular.TabIndex = 30;
            btnPrestamoAnular.Text = "Anular";
            btnPrestamoAnular.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrestamoAnular.UseVisualStyleBackColor = false;
            btnPrestamoAnular.Click += btnPrestamoAnular_Click;
            // 
            // btnPrestamoDevolver
            // 
            btnPrestamoDevolver.BackColor = Color.DodgerBlue;
            btnPrestamoDevolver.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnPrestamoDevolver.FlatStyle = FlatStyle.Flat;
            btnPrestamoDevolver.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrestamoDevolver.ForeColor = Color.White;
            btnPrestamoDevolver.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnPrestamoDevolver.IconColor = Color.White;
            btnPrestamoDevolver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrestamoDevolver.IconSize = 30;
            btnPrestamoDevolver.Location = new Point(77, 337);
            btnPrestamoDevolver.Name = "btnPrestamoDevolver";
            btnPrestamoDevolver.Size = new Size(145, 39);
            btnPrestamoDevolver.TabIndex = 29;
            btnPrestamoDevolver.Text = "Devolver";
            btnPrestamoDevolver.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrestamoDevolver.UseVisualStyleBackColor = false;
            btnPrestamoDevolver.Click += btnPrestamoDevolver_Click;
            // 
            // btnPrestamoGuardar
            // 
            btnPrestamoGuardar.BackColor = Color.ForestGreen;
            btnPrestamoGuardar.FlatAppearance.BorderColor = Color.Green;
            btnPrestamoGuardar.FlatStyle = FlatStyle.Flat;
            btnPrestamoGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrestamoGuardar.ForeColor = Color.White;
            btnPrestamoGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnPrestamoGuardar.IconColor = Color.White;
            btnPrestamoGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnPrestamoGuardar.IconSize = 30;
            btnPrestamoGuardar.Location = new Point(77, 280);
            btnPrestamoGuardar.Name = "btnPrestamoGuardar";
            btnPrestamoGuardar.Size = new Size(145, 39);
            btnPrestamoGuardar.TabIndex = 28;
            btnPrestamoGuardar.Text = "Guardar";
            btnPrestamoGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnPrestamoGuardar.UseVisualStyleBackColor = false;
            btnPrestamoGuardar.Click += btnPrestamoGuardar_Click;
            // 
            // lblPrestamoLibro
            // 
            lblPrestamoLibro.AutoSize = true;
            lblPrestamoLibro.BackColor = Color.White;
            lblPrestamoLibro.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrestamoLibro.Location = new Point(27, 161);
            lblPrestamoLibro.Name = "lblPrestamoLibro";
            lblPrestamoLibro.Size = new Size(56, 25);
            lblPrestamoLibro.TabIndex = 21;
            lblPrestamoLibro.Text = "Libro:";
            // 
            // lblPrestamoEstudiante
            // 
            lblPrestamoEstudiante.AutoSize = true;
            lblPrestamoEstudiante.BackColor = Color.White;
            lblPrestamoEstudiante.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrestamoEstudiante.Location = new Point(27, 78);
            lblPrestamoEstudiante.Name = "lblPrestamoEstudiante";
            lblPrestamoEstudiante.Size = new Size(98, 25);
            lblPrestamoEstudiante.TabIndex = 20;
            lblPrestamoEstudiante.Text = "Estudiante:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 28);
            label3.Name = "label3";
            label3.Size = new Size(191, 31);
            label3.TabIndex = 19;
            label3.Text = "Nuevo Prestamo";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(4, 26);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 18;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Left;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(328, 483);
            label1.TabIndex = 17;
            // 
            // cboEstudiantes
            // 
            cboEstudiantes.FormattingEnabled = true;
            cboEstudiantes.Location = new Point(27, 116);
            cboEstudiantes.Name = "cboEstudiantes";
            cboEstudiantes.Size = new Size(250, 28);
            cboEstudiantes.TabIndex = 34;
            cboEstudiantes.SelectedIndexChanged += cboEstudiantes_SelectedIndexChanged;
            // 
            // cboLibros
            // 
            cboLibros.FormattingEnabled = true;
            cboLibros.Location = new Point(27, 206);
            cboLibros.Name = "cboLibros";
            cboLibros.Size = new Size(250, 28);
            cboLibros.TabIndex = 35;
            cboLibros.SelectedIndexChanged += cboLibros_SelectedIndexChanged;
            // 
            // frmPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1073, 483);
            Controls.Add(cboLibros);
            Controls.Add(cboEstudiantes);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(dgvData);
            Controls.Add(btnPrestamoAnular);
            Controls.Add(btnPrestamoDevolver);
            Controls.Add(btnPrestamoGuardar);
            Controls.Add(lblPrestamoLibro);
            Controls.Add(lblPrestamoEstudiante);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmPrestamos";
            Text = "frmPrestamos";
            Load += frmPrestamos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private DataGridViewTextBoxColumn FechaCreacion;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn NombreUsuario;
        private DataGridViewTextBoxColumn NombreCompleto;
        private DataGridViewTextBoxColumn IdUsuario;
        private Label label8;
        private DataGridView dgvData;
        private FontAwesome.Sharp.IconButton btnUsuarioEliminar;
        private FontAwesome.Sharp.IconButton btnPrestamoModificar;
        private FontAwesome.Sharp.IconButton btnPrestamoGuardar;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox cboEstudiantes;
        private ComboBox cboLibros;
        private FontAwesome.Sharp.IconButton btnPrestamoAnular;
        private FontAwesome.Sharp.IconButton btnPrestamoDevolver;
        private Label lblPrestamoLibro;
        private Label lblPrestamoEstudiante;
        private DataGridViewButtonColumn btnSeleccionarPrestamo;
        private DataGridViewTextBoxColumn IdPrestamo;
        private DataGridViewTextBoxColumn FechaPrestamo;
        private DataGridViewTextBoxColumn IdEstudiante;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Estudiante;
        private DataGridViewTextBoxColumn IdLibro;
        private DataGridViewTextBoxColumn CodigoLibro;
        private DataGridViewTextBoxColumn Titulo;
        private DataGridViewTextBoxColumn FechaDevolucion;
        private DataGridViewTextBoxColumn EstadoPrestamo;
    }
}