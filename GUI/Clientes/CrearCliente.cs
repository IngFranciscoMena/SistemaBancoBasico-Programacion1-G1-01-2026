using BLL;
using EL;
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
    public partial class CrearCliente : Form
    {
        // creamos un objeto privado de la clase ClienteBLL
        private ClienteBLL _bll;

        public CrearCliente()
        {
            InitializeComponent();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // un objeto de tipo Cliente
                Cliente cliente = new Cliente();

                cliente.Nombres = txtNombres.Text;
                cliente.Apellidos = txtApellidos.Text;
                cliente.Documento = txtDocumento.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefono = txtTelefono.Text;

                // inicializar el objeto _bll
                _bll = new ClienteBLL();

                int resultado = _bll.Guardar(cliente);


                if (resultado > 0)
                {

                }
                else
                {

                }

            }
            else
            {

            }
        }

        private bool ValidarCampos()
        {
            bool esValido = false;

            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(txtDocumento.Text))
            {
                esValido = true;
            }


            return esValido;
        }
    }
}
