using MSACommon;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBiblioteca
{
    public partial class Main : Form
    {
        Result list = null;
        public bool IsClose { get; set; }

        public Main()
        {
            InitializeComponent();
            Login login = new Login();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                list = MSACommon.SecurityUtil.GetListResult(ConfigurationManager.AppSettings["uri"], login.username);
                if (list != null && list.Rol.Count > 0)
                {
                    if (list.Rol[0].Elements.Count > 0)
                    {
                        foreach (var item in list.Rol[0].Elements)
                        {
                            string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, item.Name);
                            Type type = Type.GetType(formTypeFullName, true);
                            if (item.Name == type.Name)
                            {
                                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                                menuItem.Name = type.Name;
                                menuItem.Text = type.Name;
                                menuItem.Click += new System.EventHandler(this.MenuItem_Click);
                                this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {menuItem, this.salirToolStripMenuItem});
                            }
                        }
                    }
                    else
                    {
                        this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.salirToolStripMenuItem});
                    }
                }
            }
            else
            {
                IsClose = true;
                this.Close();
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            List<MSACommon.Permission> permission = new List<Permission>();
            foreach (var item in list.Rol[0].Elements.Where(x => x.Name == sender.ToString()))
            {
                foreach (var per in item.Permissions)
                {
                    permission.Add(per);
                }
            }
            string formTypeFullName = string.Format("{0}.{1}", this.GetType().Namespace, sender.ToString());
            Type type = Type.GetType(formTypeFullName, true);
            Form frm = (Form)Activator.CreateInstance(type, permission);
            frm.ShowDialog();     
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
