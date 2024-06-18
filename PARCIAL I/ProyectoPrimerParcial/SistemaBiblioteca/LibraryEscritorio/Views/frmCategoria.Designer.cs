namespace LibraryEscritorio.Views
{
    partial class frmCategoria
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
            lblCategoriasLista = new Label();
            dgvData = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            IdCategoria = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            FechaCreacion = new DataGridViewTextBoxColumn();
            btnCategoriaModificar = new FontAwesome.Sharp.IconButton();
            btnCategoriaGuardar = new FontAwesome.Sharp.IconButton();
            txtNombreCategoria = new TextBox();
            lblNombreCategoria = new Label();
            lblTituloCategoria = new Label();
            label2 = new Label();
            label1 = new Label();
            btnCategoriaEliminar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // txtIdC
            // 
            txtIdC.BorderStyle = BorderStyle.None;
            txtIdC.Location = new Point(222, 59);
            txtIdC.Name = "txtIdC";
            txtIdC.Size = new Size(26, 20);
            txtIdC.TabIndex = 46;
            txtIdC.Text = "0";
            // 
            // lblCategoriasLista
            // 
            lblCategoriasLista.BackColor = Color.SteelBlue;
            lblCategoriasLista.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCategoriasLista.ForeColor = Color.White;
            lblCategoriasLista.Location = new Point(350, 28);
            lblCategoriasLista.Name = "lblCategoriasLista";
            lblCategoriasLista.Size = new Size(704, 42);
            lblCategoriasLista.TabIndex = 45;
            lblCategoriasLista.Text = "LISTA DE CATEGORIAS:";
            lblCategoriasLista.Click += lblCategoriasLista_Click;
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
            dgvData.Location = new Point(350, 89);
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
            dgvData.Size = new Size(704, 394);
            dgvData.TabIndex = 44;
            dgvData.CellContentClick += dgvData_CellContentClick;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.FillWeight = 15F;
            btnSeleccionar.HeaderText = "";
            btnSeleccionar.MinimumWidth = 6;
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.ReadOnly = true;
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
            Nombre.Width = 306;
            // 
            // FechaCreacion
            // 
            FechaCreacion.HeaderText = "Fecha de Creación";
            FechaCreacion.MinimumWidth = 6;
            FechaCreacion.Name = "FechaCreacion";
            FechaCreacion.ReadOnly = true;
            FechaCreacion.Width = 308;
            // 
            // btnCategoriaModificar
            // 
            btnCategoriaModificar.BackColor = Color.DodgerBlue;
            btnCategoriaModificar.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnCategoriaModificar.FlatStyle = FlatStyle.Flat;
            btnCategoriaModificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategoriaModificar.ForeColor = Color.White;
            btnCategoriaModificar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnCategoriaModificar.IconColor = Color.White;
            btnCategoriaModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategoriaModificar.IconSize = 30;
            btnCategoriaModificar.Location = new Point(60, 363);
            btnCategoriaModificar.Name = "btnCategoriaModificar";
            btnCategoriaModificar.Size = new Size(145, 39);
            btnCategoriaModificar.TabIndex = 42;
            btnCategoriaModificar.Text = "Modificar";
            btnCategoriaModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategoriaModificar.UseVisualStyleBackColor = false;
            btnCategoriaModificar.Click += btnCategoriaModificar_Click;
            // 
            // btnCategoriaGuardar
            // 
            btnCategoriaGuardar.BackColor = Color.ForestGreen;
            btnCategoriaGuardar.FlatAppearance.BorderColor = Color.Green;
            btnCategoriaGuardar.FlatStyle = FlatStyle.Flat;
            btnCategoriaGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategoriaGuardar.ForeColor = Color.White;
            btnCategoriaGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnCategoriaGuardar.IconColor = Color.White;
            btnCategoriaGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategoriaGuardar.IconSize = 30;
            btnCategoriaGuardar.Location = new Point(60, 304);
            btnCategoriaGuardar.Name = "btnCategoriaGuardar";
            btnCategoriaGuardar.Size = new Size(145, 39);
            btnCategoriaGuardar.TabIndex = 41;
            btnCategoriaGuardar.Text = "Guardar";
            btnCategoriaGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategoriaGuardar.UseVisualStyleBackColor = false;
            btnCategoriaGuardar.Click += btnCategoriaGuardar_Click;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCategoria.Location = new Point(29, 195);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.PlaceholderText = "Ingrese el nombre de la categoria";
            txtNombreCategoria.Size = new Size(243, 27);
            txtNombreCategoria.TabIndex = 40;
            // 
            // lblNombreCategoria
            // 
            lblNombreCategoria.AutoSize = true;
            lblNombreCategoria.BackColor = Color.White;
            lblNombreCategoria.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreCategoria.Location = new Point(29, 146);
            lblNombreCategoria.Name = "lblNombreCategoria";
            lblNombreCategoria.Size = new Size(82, 25);
            lblNombreCategoria.TabIndex = 38;
            lblNombreCategoria.Text = "Nombre:";
            // 
            // lblTituloCategoria
            // 
            lblTituloCategoria.AutoSize = true;
            lblTituloCategoria.BackColor = Color.White;
            lblTituloCategoria.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloCategoria.Location = new Point(29, 50);
            lblTituloCategoria.Name = "lblTituloCategoria";
            lblTituloCategoria.Size = new Size(117, 31);
            lblTituloCategoria.TabIndex = 37;
            lblTituloCategoria.Text = "Categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1, 50);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 36;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Left;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(327, 487);
            label1.TabIndex = 35;
            // 
            // btnCategoriaEliminar
            // 
            btnCategoriaEliminar.BackColor = Color.Brown;
            btnCategoriaEliminar.FlatStyle = FlatStyle.Flat;
            btnCategoriaEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCategoriaEliminar.ForeColor = Color.White;
            btnCategoriaEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnCategoriaEliminar.IconColor = Color.White;
            btnCategoriaEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCategoriaEliminar.IconSize = 30;
            btnCategoriaEliminar.Location = new Point(60, 419);
            btnCategoriaEliminar.Name = "btnCategoriaEliminar";
            btnCategoriaEliminar.Size = new Size(145, 38);
            btnCategoriaEliminar.TabIndex = 47;
            btnCategoriaEliminar.Text = "Eliminar";
            btnCategoriaEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCategoriaEliminar.UseVisualStyleBackColor = false;
            btnCategoriaEliminar.Click += btnCategoriaEliminar_Click;
            // 
            // frmCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1058, 487);
            Controls.Add(btnCategoriaEliminar);
            Controls.Add(txtIdC);
            Controls.Add(lblCategoriasLista);
            Controls.Add(dgvData);
            Controls.Add(btnCategoriaModificar);
            Controls.Add(btnCategoriaGuardar);
            Controls.Add(txtNombreCategoria);
            Controls.Add(lblNombreCategoria);
            Controls.Add(lblTituloCategoria);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmCategoria";
            Text = "frmCategoria";
            Load += frmCategoria_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtIdC;
        private Label lblCategoriasLista;
        private DataGridView dgvData;
        private FontAwesome.Sharp.IconButton btnCategoriaModificar;
        private FontAwesome.Sharp.IconButton btnCategoriaGuardar;
        private TextBox txtNombreCategoria;
        private Label lblNombreCategoria;
        private Label lblTituloCategoria;
        private Label label2;
        private Label label1;
        private DataGridViewTextBoxColumn IdEstudiante;
        private FontAwesome.Sharp.IconButton btnCategoriaEliminar;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn IdCategoria;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn FechaCreacion;
    }
}