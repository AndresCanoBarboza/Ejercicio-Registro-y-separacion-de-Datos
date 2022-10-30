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
using System.Threading;


namespace App.Forms
{
    public partial class frmAnalizarClientes : Form
    {
        public frmAnalizarClientes()
        {
            InitializeComponent();
        }

        
        private void frmAnalizarClientes_Load(object sender, EventArgs e)
        {
            MostrarCliente(dgvClientes);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count == 1)
            {
                MessageBox.Show("Primero debe registrar clientes");
                return;
            }

            Thread thread1 = new Thread(() => MostrarFemenino(this, dgvFemeninos, dgvClientes));
            thread1.Start();
            
            Thread thread2 = new Thread(() => MostrarMasculino(this, dgvMasculino, dgvClientes));
            thread2.Start();
            
        }
    }
}


/* Referencias
 
Gestionando varios Hilos con Thread y Task. https://www.youtube.com/watch?v=Dpdxd-ATFOc&t=765s
Uso de Lock - 5 - Programación Multihilos C#. https://www.youtube.com/watch?v=hI1n-kGXQLM
C# multithreading. https://www.youtube.com/watch?v=rUbmW4qAh8w
How to pass parameters to ThreadStart method in Thread?. https://stackoverflow.com/questions/3360555/how-to-pass-parameters-to-threadstart-method-in-thread
Como ejecutar un hilo con un metodo que tiene parametros. https://social.msdn.microsoft.com/Forums/es-ES/0d76b720-6991-4130-bf88-e5a0d7498916/como-ejecutar-un-hilo-con-un-metodo-que-tiene-parametros?forum=vcses
Instrucción lock (Referencia de C#). https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/statements/lock#:~:text=La%20instrucci%C3%B3n%20lock%20adquiere%20el,adquirir%20y%20liberar%20el%20bloqueo.
System.InvalidOperationException trabajando con hilos. https://es.stackoverflow.com/questions/106391/system-invalidoperationexception-trabajando-con-hilos

 
 */