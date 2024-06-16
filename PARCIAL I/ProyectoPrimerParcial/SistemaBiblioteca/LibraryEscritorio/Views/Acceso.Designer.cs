namespace LibraryEscritorio.Views
{
    partial class Acceso
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
            iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            menuStrip1 = new MenuStrip();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            label2 = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label3 = new Label();
            label4 = new Label();
            txtDocumento = new TextBox();
            txtClave = new TextBox();
            btningresar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(32, 19);
            iconMenuItem1.Text = "iconMenuItem1";
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(32, 19);
            iconMenuItem2.Text = "iconMenuItem2";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.None;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(32, 19);
            iconMenuItem3.Text = "iconMenuItem3";
            // 
            // label1
            // 
            label1.BackColor = Color.SteelBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 453);
            label1.TabIndex = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.SteelBlue;
            label2.Font = new Font("Nirmala UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(303, 51);
            label2.Name = "label2";
            label2.Size = new Size(205, 38);
            label2.TabIndex = 2;
            label2.Text = "LIBRARY4FUN";
            label2.Click += label2_Click;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.SteelBlue;
            iconPictureBox1.ForeColor = Color.GhostWhite;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Book;
            iconPictureBox1.IconColor = Color.GhostWhite;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 84;
            iconPictureBox1.Location = new Point(346, 92);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(84, 88);
            iconPictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            iconPictureBox1.TabIndex = 3;
            iconPictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.SteelBlue;
            label3.Font = new Font("Nirmala UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(277, 195);
            label3.Name = "label3";
            label3.Size = new Size(77, 25);
            label3.TabIndex = 4;
            label3.Text = "Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.SteelBlue;
            label4.Font = new Font("Nirmala UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(277, 275);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 5;
            label4.Text = "Contraseña";
            // 
            // txtDocumento
            // 
            txtDocumento.Cursor = Cursors.Hand;
            txtDocumento.Location = new Point(277, 232);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.PlaceholderText = "Ingrese su usuario";
            txtDocumento.Size = new Size(212, 27);
            txtDocumento.TabIndex = 6;
            // 
            // txtClave
            // 
            txtClave.Cursor = Cursors.Hand;
            txtClave.Location = new Point(277, 310);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.PlaceholderText = "Ingrese su contraseña";
            txtClave.Size = new Size(212, 27);
            txtClave.TabIndex = 7;
            txtClave.TextChanged += textBox2_TextChanged;
            // 
            // btningresar
            // 
            btningresar.BackColor = Color.White;
            btningresar.Cursor = Cursors.Hand;
            btningresar.FlatStyle = FlatStyle.Flat;
            btningresar.Font = new Font("Nirmala UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btningresar.ForeColor = Color.SteelBlue;
            btningresar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btningresar.IconColor = Color.SteelBlue;
            btningresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btningresar.IconSize = 28;
            btningresar.Location = new Point(320, 371);
            btningresar.Name = "btningresar";
            btningresar.Size = new Size(141, 48);
            btningresar.TabIndex = 8;
            btningresar.Text = "Iniciar Sesión";
            btningresar.TextAlign = ContentAlignment.MiddleRight;
            btningresar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btningresar.UseVisualStyleBackColor = false;
            btningresar.Click += iconButton1_Click;
            // 
            // Acceso
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btningresar);
            Controls.Add(txtClave);
            Controls.Add(txtDocumento);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(iconPictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Acceso";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN LIBRARY4FUN";
            Load += Acceso_Load;
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label3;
        private Label label4;
        private TextBox txtDocumento;
        private TextBox txtClave;
        private FontAwesome.Sharp.IconButton btningresar;
    }
}