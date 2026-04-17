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

            // inicializar nuestro BindingSource
            bsCliente.MoveLast();
            bsCliente.AddNew();
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

                    int resultado = _bll.Guardar(cliente);

                    if (resultado > 0)
                    {
                        MessageBox.Show(
                                "Usuario registrado con exito",
                                "Banco Green | Formulario Crear Cliente",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                                "Ocurrio un error en el registro del cliente",
                                "Banco Green | Formulario Crear Cliente",
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
                        "Banco Green | Formulario Crear Cliente",
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // cerrar el formulario
            this.Close();
        }
    }
}
