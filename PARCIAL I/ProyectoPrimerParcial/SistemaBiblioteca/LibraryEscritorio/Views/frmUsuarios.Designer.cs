namespace LibraryEscritorio.Views
{
    partial class frmUsuarios
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombreCompleto = new TextBox();
            txtNombreUsuario = new TextBox();
            txtClave = new TextBox();
            txtRepetirClave = new TextBox();
            btnUsuarioGuardar = new FontAwesome.Sharp.IconButton();
            btnUsuarioModificar = new FontAwesome.Sharp.IconButton();
            btnUsuarioEliminar = new FontAwesome.Sharp.IconButton();
            dgvData = new DataGridView();
            btnSeleccionar = new DataGridViewButtonColumn();
            IdUsuario = new DataGridViewTextBoxColumn();
            NombreCompleto = new DataGridViewTextBoxColumn();
            NombreUsuario = new DataGridViewTextBoxColumn();
            Clave = new DataGridViewTextBoxColumn();
            FechaCreacion = new DataGridViewTextBoxColumn();
            label8 = new Label();
            txtId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Dock = DockStyle.Left;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(327, 507);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 43);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 21);
            label3.Name = "label3";
            label3.Size = new Size(97, 31);
            label3.TabIndex = 2;
            label3.Text = "Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 65);
            label4.Name = "label4";
            label4.Size = new Size(166, 25);
            label4.TabIndex = 3;
            label4.Text = "Nombre Completo:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(56, 132);
            label5.Name = "label5";
            label5.Size = new Size(147, 25);
            label5.TabIndex = 4;
            label5.Text = "Nombre Usuario:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(56, 200);
            label6.Name = "label6";
            label6.Size = new Size(105, 25);
            label6.TabIndex = 5;
            label6.Text = "Contraseña:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Nirmala UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(56, 268);
            label7.Name = "label7";
            label7.Size = new Size(165, 25);
            label7.TabIndex = 6;
            label7.Text = "Repetir Contraseña:";
            // 
            // txtNombreCompleto
            // 
            txtNombreCompleto.BorderStyle = BorderStyle.FixedSingle;
            txtNombreCompleto.Location = new Point(56, 93);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.PlaceholderText = "Ingrese su nombre completo";
            txtNombreCompleto.Size = new Size(207, 27);
            txtNombreCompleto.TabIndex = 7;
            txtNombreCompleto.TextChanged += txtNombreCompleto_TextChanged;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtNombreUsuario.Location = new Point(56, 160);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Ingrese su usuario";
            txtNombreUsuario.Size = new Size(207, 27);
            txtNombreUsuario.TabIndex = 8;
            txtNombreUsuario.TextChanged += txtNombreUsuario_TextChanged;
            // 
            // txtClave
            // 
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.Location = new Point(56, 228);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese su contraseña";
            txtClave.Size = new Size(207, 27);
            txtClave.TabIndex = 9;
            txtClave.TextChanged += txtClave_TextChanged;
            // 
            // txtRepetirClave
            // 
            txtRepetirClave.BorderStyle = BorderStyle.FixedSingle;
            txtRepetirClave.Location = new Point(56, 298);
            txtRepetirClave.Margin = new Padding(5);
            txtRepetirClave.Name = "txtRepetirClave";
            txtRepetirClave.PasswordChar = '*';
            txtRepetirClave.PlaceholderText = "Ingrese su contraseña";
            txtRepetirClave.Size = new Size(207, 27);
            txtRepetirClave.TabIndex = 10;
            txtRepetirClave.TextChanged += txtRepetirClave_TextChanged;
            // 
            // btnUsuarioGuardar
            // 
            btnUsuarioGuardar.BackColor = Color.ForestGreen;
            btnUsuarioGuardar.FlatAppearance.BorderColor = Color.Green;
            btnUsuarioGuardar.FlatStyle = FlatStyle.Flat;
            btnUsuarioGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarioGuardar.ForeColor = Color.White;
            btnUsuarioGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnUsuarioGuardar.IconColor = Color.White;
            btnUsuarioGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarioGuardar.IconSize = 30;
            btnUsuarioGuardar.Location = new Point(87, 348);
            btnUsuarioGuardar.Name = "btnUsuarioGuardar";
            btnUsuarioGuardar.Size = new Size(145, 39);
            btnUsuarioGuardar.TabIndex = 11;
            btnUsuarioGuardar.Text = "Guardar";
            btnUsuarioGuardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarioGuardar.UseVisualStyleBackColor = false;
            btnUsuarioGuardar.Click += btnUsuarioAgregar_Click;
            // 
            // btnUsuarioModificar
            // 
            btnUsuarioModificar.BackColor = Color.DodgerBlue;
            btnUsuarioModificar.FlatAppearance.BorderColor = Color.DodgerBlue;
            btnUsuarioModificar.FlatStyle = FlatStyle.Flat;
            btnUsuarioModificar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarioModificar.ForeColor = Color.White;
            btnUsuarioModificar.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
            btnUsuarioModificar.IconColor = Color.White;
            btnUsuarioModificar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarioModificar.IconSize = 30;
            btnUsuarioModificar.Location = new Point(87, 393);
            btnUsuarioModificar.Name = "btnUsuarioModificar";
            btnUsuarioModificar.Size = new Size(145, 39);
            btnUsuarioModificar.TabIndex = 12;
            btnUsuarioModificar.Text = "Modificar";
            btnUsuarioModificar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarioModificar.UseVisualStyleBackColor = false;
            btnUsuarioModificar.Click += btnUsuarioModificar_Click;
            // 
            // btnUsuarioEliminar
            // 
            btnUsuarioEliminar.BackColor = Color.Brown;
            btnUsuarioEliminar.FlatStyle = FlatStyle.Flat;
            btnUsuarioEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarioEliminar.ForeColor = Color.White;
            btnUsuarioEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnUsuarioEliminar.IconColor = Color.White;
            btnUsuarioEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarioEliminar.IconSize = 30;
            btnUsuarioEliminar.Location = new Point(87, 438);
            btnUsuarioEliminar.Name = "btnUsuarioEliminar";
            btnUsuarioEliminar.Size = new Size(145, 38);
            btnUsuarioEliminar.TabIndex = 13;
            btnUsuarioEliminar.Text = "Eliminar";
            btnUsuarioEliminar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarioEliminar.UseVisualStyleBackColor = false;
            btnUsuarioEliminar.Click += btnUsuarioEliminar_Click;
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
            dgvData.Columns.AddRange(new DataGridViewColumn[] { btnSeleccionar, IdUsuario, NombreCompleto, NombreUsuario, Clave, FechaCreacion });
            dgvData.Location = new Point(388, 82);
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
            dgvData.Size = new Size(678, 394);
            dgvData.TabIndex = 14;
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
            // IdUsuario
            // 
            IdUsuario.HeaderText = "IdUsuario";
            IdUsuario.MinimumWidth = 6;
            IdUsuario.Name = "IdUsuario";
            IdUsuario.ReadOnly = true;
            IdUsuario.Visible = false;
            IdUsuario.Width = 30;
            // 
            // NombreCompleto
            // 
            NombreCompleto.HeaderText = "Nombre Completo";
            NombreCompleto.MinimumWidth = 6;
            NombreCompleto.Name = "NombreCompleto";
            NombreCompleto.ReadOnly = true;
            NombreCompleto.Width = 190;
            // 
            // NombreUsuario
            // 
            NombreUsuario.HeaderText = "Nombre de Usuario";
            NombreUsuario.MinimumWidth = 6;
            NombreUsuario.Name = "NombreUsuario";
            NombreUsuario.ReadOnly = true;
            NombreUsuario.Width = 210;
            // 
            // Clave
            // 
            Clave.HeaderText = "Clave";
            Clave.MinimumWidth = 6;
            Clave.Name = "Clave";
            Clave.ReadOnly = true;
            Clave.Visible = false;
            Clave.Width = 125;
            // 
            // FechaCreacion
            // 
            FechaCreacion.HeaderText = "Fecha de Creación";
            FechaCreacion.MinimumWidth = 6;
            FechaCreacion.Name = "FechaCreacion";
            FechaCreacion.ReadOnly = true;
            FechaCreacion.Width = 190;
            // 
            // label8
            // 
            label8.BackColor = Color.SteelBlue;
            label8.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(388, 21);
            label8.Name = "label8";
            label8.Size = new Size(678, 42);
            label8.TabIndex = 15;
            label8.Text = "LISTA DE USUARIOS:";
            label8.Click += label8_Click;
            // 
            // txtId
            // 
            txtId.BorderStyle = BorderStyle.None;
            txtId.Location = new Point(237, 36);
            txtId.Name = "txtId";
            txtId.Size = new Size(26, 20);
            txtId.TabIndex = 16;
            txtId.Text = "0";
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1105, 507);
            Controls.Add(txtId);
            Controls.Add(label8);
            Controls.Add(dgvData);
            Controls.Add(btnUsuarioEliminar);
            Controls.Add(btnUsuarioModificar);
            Controls.Add(btnUsuarioGuardar);
            Controls.Add(txtRepetirClave);
            Controls.Add(txtClave);
            Controls.Add(txtNombreUsuario);
            Controls.Add(txtNombreCompleto);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmUsuarios";
            Text = "frmUsuarios";
            Load += frmUsuarios_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombreCompleto;
        private TextBox txtNombreUsuario;
        private TextBox txtClave;
        private TextBox txtRepetirClave;
        private FontAwesome.Sharp.IconButton btnUsuarioGuardar;
        private FontAwesome.Sharp.IconButton btnUsuarioModificar;
        private FontAwesome.Sharp.IconButton btnUsuarioEliminar;
        private DataGridView dgvData;
        private Label label8;
        private TextBox txtId;
        private DataGridViewButtonColumn btnSeleccionar;
        private DataGridViewTextBoxColumn IdUsuario;
        private DataGridViewTextBoxColumn NombreCompleto;
        private DataGridViewTextBoxColumn NombreUsuario;
        private DataGridViewTextBoxColumn Clave;
        private DataGridViewTextBoxColumn FechaCreacion;
    }
}