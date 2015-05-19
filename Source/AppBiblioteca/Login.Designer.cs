namespace AppBiblioteca
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.cambiopassword = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.salir = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cambiopassword
            // 
            this.cambiopassword.AutoSize = true;
            this.cambiopassword.Location = new System.Drawing.Point(268, 79);
            this.cambiopassword.Name = "cambiopassword";
            this.cambiopassword.Size = new System.Drawing.Size(94, 13);
            this.cambiopassword.TabIndex = 17;
            this.cambiopassword.TabStop = true;
            this.cambiopassword.Text = "Cambiar Password";
            this.cambiopassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.cambiopassword_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(25, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 8);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // salir
            // 
            this.salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salir.Image = ((System.Drawing.Image)(resources.GetObject("salir.Image")));
            this.salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.salir.Location = new System.Drawing.Point(254, 117);
            this.salir.Name = "salir";
            this.salir.Size = new System.Drawing.Size(108, 51);
            this.salir.TabIndex = 15;
            this.salir.Text = "               Aceptar";
            this.salir.UseVisualStyleBackColor = true;
            this.salir.Click += new System.EventHandler(this.salir_Click);
            // 
            // aceptar
            // 
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Image = ((System.Drawing.Image)(resources.GetObject("aceptar.Image")));
            this.aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aceptar.Location = new System.Drawing.Point(126, 117);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(108, 51);
            this.aceptar.TabIndex = 14;
            this.aceptar.Text = "               Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(25, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(61, 58);
            this.panel1.TabIndex = 13;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(158, 55);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(204, 20);
            this.password.TabIndex = 12;
            this.password.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(158, 20);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(204, 20);
            this.usuario.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuario";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(386, 183);
            this.Controls.Add(this.cambiopassword);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.salir);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel cambiopassword;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button salir;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Label label1;

    }
}