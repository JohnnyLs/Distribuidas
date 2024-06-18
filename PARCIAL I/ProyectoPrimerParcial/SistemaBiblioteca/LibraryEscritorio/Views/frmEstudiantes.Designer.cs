namespace LibraryEscritorio.Views
{
    partial class frmEstudiantes
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            txtIdE = new TextBox();
            lblEstudiantesTitulo = new Label();
            dgvDataEstudiantes = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            IdEstudiante = new DataGridViewTextBoxColumn();
            Codigo = new DataGridViewTextBoxColumn();
            Nombres = new DataGridViewTextBoxColumn();
            Apellidos = new DataGridViewTextBoxColumn();
            btnEstudianteEliminar = new FontAwesome.Sharp.IconButton();
            btnEstudianteModificar = new FontAwesome.Sharp.IconButton();
            btnEstudianteGuardar = new FontAwesome.Sharp.IconButton();
            txtNombresEstudiantes = new TextBox();
            lblApellidosEstudiantes = new Label();
            lblNombreEstudiantes = new Label();
            lblEstudiantes = new Label();
            label2 = new Label();
            label1 = new Label();
            txtApellidosEstudiantes = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDataEstudiantes).BeginInit();
            SuspendLayout();
            // 
            // txtIdE
            // 
            txtIdE.BorderStyle = BorderStyle.None;
            txtIdE.Location = new Point(227, 59);
            txtIdE.Name = "txtIdE";
            txtIdE.Size = new Size(26, 20);
            txtIdE.TabIndex = 33;
            txtIdE.Text = "0";
            // 
            // lblEstudiantesTitulo
            // 
            lblEstudiantesTitulo.BackColor = Color.SteelBlue;
            lblEstudiantesTitulo.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstudiantesTitulo.ForeColor = Color.White;
            lblEstudiantesTitulo.Location = new Point(355, 28);
            lblEstudiantesTitulo.Name = "lblEstudiantesTitulo";
            lblEstudiantesTitulo.Size = new Size(678, 42);
            lblEstudiantesTitulo.TabIndex = 32;
            lblEstudiantesTitulo.Text = "LISTA DE ESTUDIANTES:";
            // 
            // dgvDataEstudiantes
            // 
            dgvDataEstudiantes.AllowUserToAddRows = false;
            dgvDataEstudiantes.BackgroundColor = Color.SteelBlue;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.Padding = new Padding(2);
            dataGridViewCellStyle4.SelectionBackColor = Color.White;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvDataEstudiantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvDataEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataEstudiantes.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, IdEstudiante, Codigo, Nombres, Apellidos });
            dgvDataEstudiantes.Location = new Point(355, 89);
            dgvDataEstudiantes.MultiSelect = false;
            dgvDataEstudiantes.Name = "dgvDataEstudiantes";
            dgvDataEstudiantes.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = Color.White;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvDataEstudiantes.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvDataEstudiantes.RowHeadersWidth = 51;
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dgvDataEstudiantes.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvDataEstudiantes.RowTemplate.Height = 32;
            dgvDataEstudiantes.Size = new Size(704, 394);
            dgvDataEstudiantes.TabIndex = 31;
            dgvDataEstudiantes.CellContentClick += dgvData_CellContentClick;
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
            // IdEstudiante
            // 
            IdEstudiante.HeaderText = "Id";
            IdEstudiante.MinimumWidth = 6;
            IdEstudiante.Name = "IdEstudiante";
            IdEstudiante.ReadOnly = true;
            IdEstudiante.Visible = false;
            IdEstudiante.Width = 30;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.MinimumWidth = 6;
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            Codigo.Width = 125;
            // 
            // Nombres
            // 
            Nombres.HeaderText = "Nombres";
            Nombres.MinimumWidth = 6;
            Nombres.Name = "Nombres";
            Nombres.ReadOnly = true;
            Nombres.Width = 245;
            // 
            // Apellidos
            // 
            Apellidos.HeaderText = "Apellidos";
            Apellidos.MinimumWidth = 6;
            Apellidos.Name = "Apellidos";
            Apellidos.ReadOnly = true;
            Apellidos.Width = 243;
            // 
            // btnEstudianteEliminar
            // 
            btnEstudianteEliminar.BackColor = Color.Brown;
            btnEstudianteEliminar.FlatStyle = FlatStyle.Flat;
            btnEstudianteEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstudianteEliminar.ForeColor = Color.White;
            btnEstudianteEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnEstudianteEliminar.IconColor = Color.White;
            btnEstudianteEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstudianteEliminar.IconSize = 30;
            btnEstudianteEliminar.Location = new Point(65, 445);
            btnEstudianteEliminar.Name = "btnEstudianteEliminar";
            btnEstudianteEliminar.Size = new Size(145, 38);
            btnEstudianteEliminar.TabIndex = 30;
            btnEstudianteEliminar.Text = "Eliminar";
            btnEstudianteEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstudianteEliminar.UseVisualStyleBackColor = false;
            btnEstudianteEliminar.Click += btnEstudianteEliminar_Click;
            // 
            // btnEstudianteModificar
            // 
            btnEstudianteModificar.BackColor = Color.DodgerBlue;
            btnEstudianteModificar.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnEstudianteModificar.FlatStyle = FlatStyle.Flat;
            btnEstudianteModificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstudianteModificar.ForeColor = Color.White;
            btnEstudianteModificar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnEstudianteModificar.IconColor = Color.White;
            btnEstudianteModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstudianteModificar.IconSize = 30;
            btnEstudianteModificar.Location = new Point(65, 400);
            btnEstudianteModificar.Name = "btnEstudianteModificar";
            btnEstudianteModificar.Size = new Size(145, 39);
            btnEstudianteModificar.TabIndex = 29;
            btnEstudianteModificar.Text = "Modificar";
            btnEstudianteModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstudianteModificar.UseVisualStyleBackColor = false;
            btnEstudianteModificar.Click += btnEstudianteModificar_Click;
            // 
            // btnEstudianteGuardar
            // 
            btnEstudianteGuardar.BackColor = Color.ForestGreen;
            btnEstudianteGuardar.FlatAppearance.BorderColor = Color.Green;
            btnEstudianteGuardar.FlatStyle = FlatStyle.Flat;
            btnEstudianteGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstudianteGuardar.ForeColor = Color.White;
            btnEstudianteGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnEstudianteGuardar.IconColor = Color.White;
            btnEstudianteGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEstudianteGuardar.IconSize = 30;
            btnEstudianteGuardar.Location = new Point(65, 355);
            btnEstudianteGuardar.Name = "btnEstudianteGuardar";
            btnEstudianteGuardar.Size = new Size(145, 39);
            btnEstudianteGuardar.TabIndex = 28;
            btnEstudianteGuardar.Text = "Guardar";
            btnEstudianteGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnEstudianteGuardar.UseVisualStyleBackColor = false;
            btnEstudianteGuardar.Click += btnEstudianteGuardar_Click;
            // 
            // txtNombresEstudiantes
            // 
            txtNombresEstudiantes.BorderStyle = BorderStyle.FixedSingle;
            txtNombresEstudiantes.Location = new Point(34, 174);
            txtNombresEstudiantes.Name = "txtNombresEstudiantes";
            txtNombresEstudiantes.PlaceholderText = "Ingrese sus nombres";
            txtNombresEstudiantes.Size = new Size(243, 27);
            txtNombresEstudiantes.TabIndex = 24;
            // 
            // lblApellidosEstudiantes
            // 
            lblApellidosEstudiantes.AutoSize = true;
            lblApellidosEstudiantes.BackColor = Color.White;
            lblApellidosEstudiantes.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblApellidosEstudiantes.Location = new Point(34, 222);
            lblApellidosEstudiantes.Name = "lblApellidosEstudiantes";
            lblApellidosEstudiantes.Size = new Size(90, 25);
            lblApellidosEstudiantes.TabIndex = 21;
            lblApellidosEstudiantes.Text = "Apellidos:";
            // 
            // lblNombreEstudiantes
            // 
            lblNombreEstudiantes.AutoSize = true;
            lblNombreEstudiantes.BackColor = Color.White;
            lblNombreEstudiantes.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreEstudiantes.Location = new Point(34, 131);
            lblNombreEstudiantes.Name = "lblNombreEstudiantes";
            lblNombreEstudiantes.Size = new Size(90, 25);
            lblNombreEstudiantes.TabIndex = 20;
            lblNombreEstudiantes.Text = "Nombres:";
            // 
            // lblEstudiantes
            // 
            lblEstudiantes.AutoSize = true;
            lblEstudiantes.BackColor = Color.White;
            lblEstudiantes.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstudiantes.Location = new Point(34, 50);
            lblEstudiantes.Name = "lblEstudiantes";
            lblEstudiantes.Size = new Size(137, 31);
            lblEstudiantes.TabIndex = 19;
            lblEstudiantes.Text = "Estudiantes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 50);
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
            label1.Size = new Size(327, 511);
            label1.TabIndex = 17;
            // 
            // txtApellidosEstudiantes
            // 
            txtApellidosEstudiantes.BorderStyle = BorderStyle.FixedSingle;
            txtApellidosEstudiantes.Location = new Point(34, 262);
            txtApellidosEstudiantes.Name = "txtApellidosEstudiantes";
            txtApellidosEstudiantes.PlaceholderText = "Ingrese sus apellidos";
            txtApellidosEstudiantes.Size = new Size(243, 27);
            txtApellidosEstudiantes.TabIndex = 34;
            txtApellidosEstudiantes.TextChanged += txtApellido_TextChanged;
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1062, 511);
            Controls.Add(txtApellidosEstudiantes);
            Controls.Add(txtIdE);
            Controls.Add(lblEstudiantesTitulo);
            Controls.Add(dgvDataEstudiantes);
            Controls.Add(btnEstudianteEliminar);
            Controls.Add(btnEstudianteModificar);
            Controls.Add(btnEstudianteGuardar);
            Controls.Add(txtNombresEstudiantes);
            Controls.Add(lblApellidosEstudiantes);
            Controls.Add(lblNombreEstudiantes);
            Controls.Add(lblEstudiantes);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDataEstudiantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIdE;
        private Label lblEstudiantesTitulo;
        private DataGridView dgvDataEstudiantes;
        private FontAwesome.Sharp.IconButton btnEstudianteEliminar;
        private FontAwesome.Sharp.IconButton btnEstudianteModificar;
        private FontAwesome.Sharp.IconButton btnEstudianteGuardar;
        private TextBox txtRepetirClave;
        private TextBox txtClave;
        private TextBox txtNombreUsuario;
        private TextBox txtNombresEstudiantes;
        private Label label7;
        private Label label6;
        private Label lblApellidosEstudiantes;
        private Label lblNombreEstudiantes;
        private Label lblEstudiantes;
        private Label label2;
        private Label label1;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn IdEstudiante;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombres;
        private DataGridViewTextBoxColumn Apellidos;
        private TextBox txtApellidosEstudiantes;
    }
}