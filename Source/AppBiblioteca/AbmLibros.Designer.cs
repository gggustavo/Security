﻿namespace AppBiblioteca
{
    partial class AbmLibros
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
            this.Alta = new System.Windows.Forms.Button();
            this.Baja = new System.Windows.Forms.Button();
            this.Modificacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Alta
            // 
            this.Alta.Enabled = false;
            this.Alta.Location = new System.Drawing.Point(12, 12);
            this.Alta.Name = "Alta";
            this.Alta.Size = new System.Drawing.Size(75, 23);
            this.Alta.TabIndex = 0;
            this.Alta.Text = "Alta";
            this.Alta.UseVisualStyleBackColor = true;
            // 
            // Baja
            // 
            this.Baja.Enabled = false;
            this.Baja.Location = new System.Drawing.Point(93, 12);
            this.Baja.Name = "Baja";
            this.Baja.Size = new System.Drawing.Size(75, 23);
            this.Baja.TabIndex = 1;
            this.Baja.Text = "Baja";
            this.Baja.UseVisualStyleBackColor = true;
            // 
            // Modificacion
            // 
            this.Modificacion.Enabled = false;
            this.Modificacion.Location = new System.Drawing.Point(174, 12);
            this.Modificacion.Name = "Modificacion";
            this.Modificacion.Size = new System.Drawing.Size(75, 23);
            this.Modificacion.TabIndex = 2;
            this.Modificacion.Text = "Modificacion";
            this.Modificacion.UseVisualStyleBackColor = true;
            // 
            // AbmLibros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 307);
            this.Controls.Add(this.Modificacion);
            this.Controls.Add(this.Baja);
            this.Controls.Add(this.Alta);
            this.Name = "AbmLibros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "AbmLibros";
            this.Text = "AbmLibros";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Alta;
        private System.Windows.Forms.Button Baja;
        private System.Windows.Forms.Button Modificacion;
    }
}