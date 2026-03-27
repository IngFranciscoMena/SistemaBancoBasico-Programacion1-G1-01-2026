using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Autenticacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // validar las credenciales
            if (txtUsuario.Text.Equals("admin") && txtContraseña.Text.Equals("admin"))
            {
                // mostrar el menu principal
            }
            else
            {
                // mostrar un mensaje de error
                MessageBox.Show("Credenciales incorrectas.", "Banco Green | Inicio de Sesión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
