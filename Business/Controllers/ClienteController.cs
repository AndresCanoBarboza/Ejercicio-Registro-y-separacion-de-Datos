using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


using Entities.Models;
using static DataAccess.Services.RegistroClientes;

namespace Business.Controllers
{

    
    public static class ClienteController
    {
        
        

        public static bool BuscarCliente(string Id)
        {
            return cliente.Where(x => x != null).Any(x => x.clienteId == Id);
        }

        public static bool LlenoCliente()
        {
            return cliente.Any(x => x == null); // Para averiguar si hay espacio
        }

        public static int espacioLibre()
        {
            return Array.IndexOf(cliente, null);
        }

        public static int obtenerPos()
        {
            return Array.IndexOf(cliente, null);
        }
        public static void AgregarCliente(int pos, Clientes nuevo)
        {
            cliente[pos] = nuevo;
        }

        public static void MostrarCliente(DataGridView dgv)
        {
            dgv.Rows.Clear();
            foreach (var item in cliente.Where(x => x != null))
            {
                dgv.Rows.Add(item.ListaClientes());
            }
            
        }

        public static void MostrarFemenino(Form frm, DataGridView dgv1, DataGridView dgv2)
        {
            frm.BeginInvoke(new MethodInvoker(delegate
            {
            dgv1.Rows.Clear();

                foreach (var item in cliente.Where(x => x != null).Where(x => x.generoCliente.Equals('F')))
                {
                    dgv1.Rows.Add(item.ListaClientes());
                    
                    for (int i = 0; i < dgv2.Rows.Count; i++)
                    {
                        if (dgv2.Columns[6].Equals('F'))
                        {
                            dgv2.Rows.RemoveAt(i);
                        }
                    }
                               
                }
            }));
        }


        public static void MostrarMasculino(Form frm, DataGridView dgv1, DataGridView dgv2)
        {
            frm.BeginInvoke(new MethodInvoker(delegate
            {
                dgv1.Rows.Clear();
                foreach (var item in cliente.Where(x => x != null).Where(x => x.generoCliente.Equals('M')))
                {
                    dgv1.Rows.Add(item.ListaClientes());
                    
                    for (int i = 0; i < dgv2.Rows.Count; i++)
                    {
                        if (dgv2.Columns[6].Equals('F'))
                        {
                            dgv2.Rows.RemoveAt(i);
                        }
                    }
                }
            }));
        }

    }
}
