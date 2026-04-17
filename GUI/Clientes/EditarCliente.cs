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
    public partial class EditarCliente : Form
    {
        private ClienteBLL _bll;

        public EditarCliente(Cliente cliente)
        {
            InitializeComponent();
            bsCliente.DataSource = cliente;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // indicamos que se finalizo la edición
                bsCliente.EndEdit();

                if (ValidarCampos())
                {
                    // inicializar el objeto _bll
                    _bll = new ClienteBLL();

                    // un objeto de tipo Cliente
                    Cliente cliente = (Cliente)bsCliente.Current;

                    int resultado = _bll.Guardar(cliente, cliente.ClienteId, true);

                    if (resultado > 0)
                    {
                        MessageBox.Show(
                                "Usuario actualizado con exito",
                                "Banco Green | Formulario Crear Cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                                "Ocurrio un error en la actualización del cliente",
                                "Banco Green | Formulario Editar Cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                    }
                }
                else
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "Ocurrio un error",
                        "Banco Green | Formulario Editar Cliente",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }

        /// <summary>
        /// Valida que los campos de nombre, apellido y documento no estén vacíos.
        /// </summary>
        /// <returns>Verdadero si los campos son válidos, falso en caso contrario.</returns>
        private bool ValidarCampos()
        {
            bool esValido = false;

            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(mskDocumento.Text))
            {
                esValido = true;
            }


            return esValido;
        }
    }
}
