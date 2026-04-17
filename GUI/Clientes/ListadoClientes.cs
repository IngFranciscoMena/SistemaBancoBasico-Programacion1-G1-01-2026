using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Clientes
{
    public partial class ListadoClientes : Form
    {
        private ClienteBLL _bllCliente;

        public ListadoClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            // incializar el objeto _bll
            _bllCliente = new ClienteBLL();

            bsClientes.DataSource = _bllCliente.Mostrar();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            CrearCliente formCrear = new CrearCliente();
            formCrear.ShowDialog();
        }
    }
}
