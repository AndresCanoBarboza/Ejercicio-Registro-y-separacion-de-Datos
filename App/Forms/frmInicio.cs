using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App.Forms
{
    public partial class frmInicio : Form
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            frmRegistrarClientes ventana = new frmRegistrarClientes();
            ventana.ShowDialog();
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            frmAnalizarClientes ventana = new frmAnalizarClientes();
            ventana.ShowDialog();    
        }
    }
}
