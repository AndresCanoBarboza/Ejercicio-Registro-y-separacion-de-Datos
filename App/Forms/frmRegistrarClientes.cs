using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Business.Controllers.ClienteController;
using Entities.Models;

namespace App.Forms
{
    public partial class frmRegistrarClientes : Form
    {
        public frmRegistrarClientes()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtIdCliente.Text = string.Empty;
            txtNombreCliente.Text = string.Empty;
            txtApellido1.Text = string.Empty;
            txtApellido2.Text = string.Empty;
            cmbGenero.SelectedItem = null;

        }

                
        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardarCliente_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdCliente.Text) || string.IsNullOrEmpty(txtNombreCliente.Text) || string.IsNullOrEmpty(txtApellido1.Text) || string.IsNullOrEmpty(txtApellido2.Text))// Validación de espacio vacío de campo Descripción
            {
                MessageBox.Show("No pueden quedar espacios vacíos.");
                return;
            }

            if (cmbGenero.SelectedItem == null) // Validación de selección de comboBox género
            {
                MessageBox.Show("Debe seleccionar una opción en género.");
                return;
            }

            if (dtpFechaNacimiento.Value.Date > DateTime.Today || dtpFechaIngreso.Value.Date > DateTime.Today) // Validación para que no se pueda escoger fecha futura
            {
                MessageBox.Show("No puede seleccionar una fecha futura.");
                return;
            }

            if (BuscarCliente(txtIdCliente.Text))
            {
                MessageBox.Show("El Id de Cliente ya existe.");
                return;
            }

            Clientes nuevo = new Clientes()
            {
                clienteId = txtIdCliente.Text,
                nombreCliente = txtNombreCliente.Text,
                apellido1Cliente = txtApellido1.Text,
                apellido2Cliente = txtApellido2.Text,
                fechaNacimiento = dtpFechaNacimiento.Value,
                fechaIngreso = dtpFechaIngreso.Value,
                generoCliente = cmbGenero.SelectedIndex == 0 ? 'F' : cmbGenero.SelectedIndex == 1 ? 'M' : cmbGenero.SelectedIndex == 2 ? 'O' : '\0',
            };

            if (LlenoCliente())
            {
                AgregarCliente(obtenerPos(), nuevo);
                MessageBox.Show("Cliente agregado.");
            }
            else
            {
                MessageBox.Show("No hay más espacio.");
            }

            Limpiar();
        }
    }
}
