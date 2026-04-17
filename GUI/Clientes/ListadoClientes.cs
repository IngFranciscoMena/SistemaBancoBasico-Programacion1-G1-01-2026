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
            try
            {
                // incializar el objeto _bll
                _bllCliente = new ClienteBLL();

                bsClientes.DataSource = _bllCliente.Mostrar();
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "Ocurrio un error",
                        "Banco Green | Listado de Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            CrearCliente formCrear = new CrearCliente();
            formCrear.ShowDialog();
            // recargar los datos
            CargarClientes();
        }

        private void dgvListadoClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // validar que la celda sea parte de la colección
                // el indice en la columna y la fila sea la posición 0, 0
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                // almacenar el nombre de la columna
                string nombreColumna = dgvListadoClientes.Columns[e.ColumnIndex].Name;

                // obtener el cliente seleccionado
                Cliente cliente = (Cliente)bsClientes[e.RowIndex];

                if (cliente == null)
                    return;

                // verificar que acción se desea realizar
                if (nombreColumna == "Editar")
                {
                    // mostrar el formulario Editar Cliente
                    EditarCliente formEdicion = new EditarCliente(cliente);
                    formEdicion.ShowDialog();
                    // recargar los datos
                    CargarClientes();
                }
                else if (nombreColumna == "Eliminar")
                {
                    DialogResult respuesta = MessageBox.Show(
                            "¿Desea eliminar el cliente seleccionado?",
                            "Banco Grenn | Eliminar Cliente",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                    if (respuesta == DialogResult.Yes) 
                    {
                        _bllCliente = new ClienteBLL();

                        // eliminar el cliente
                        int resultado = _bllCliente.Eliminar(cliente.ClienteId);

                        if (resultado > 0)
                        {
                            MessageBox.Show(
                                    "Usuario eliminado con exito",
                                    "Banco Green | Eliminar Cliente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );

                            // recargar los datos
                            CargarClientes();
                        }
                        else
                        {
                            MessageBox.Show(
                                    "Ocurrio un error al eliminar el cliente",
                                    "Banco Green | Eliminar Cliente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                        "Ocurrio un error",
                        "Banco Green | Listado de Clientes",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
            }
        }
    }
}
