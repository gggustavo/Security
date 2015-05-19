using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppBiblioteca
{
    public partial class AbmGeneros : Form
    {
        public AbmGeneros(List<MSACommon.Permission> permission)
        {
            InitializeComponent();

            foreach (var item in permission)
            {
                if (item.Name == this.Alta.Name)
                    this.Alta.Enabled = true;

                if (item.Name == this.Baja.Name)
                    this.Baja.Enabled = true;

                if (item.Name == this.Modificacion.Name)
                    this.Modificacion.Enabled = true;
            }
        }
    }
}
