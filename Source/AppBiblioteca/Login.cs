using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBiblioteca
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
           
        }

        public string username { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.usuario.Focus();
        }

        private void aceptar_Click(object sender, EventArgs e)
        {
            string value = MSACommon.SecurityUtil.GetPasswordByIdUser(ConfigurationManager.AppSettings["auth"],this.usuario.Text);

            if (value == MSACommon.SecurityUtil.Encrypt(this.password.Text))
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                username = this.usuario.Text;
                this.Hide();
            }
            else
            {
                MessageBox.Show("usuario/password incorrecto.");
            }
            
           
        }

        private void salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cambiopassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:59697/AccountUser/ManageUser");
        }

    }
}
