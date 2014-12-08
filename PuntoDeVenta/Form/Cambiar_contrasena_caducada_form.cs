using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class Cambiar_contrasena_caducada_form : Form
    {
        Usuarios usuarioActual = null;
        public Cambiar_contrasena_caducada_form(Usuarios usuario)
        {
            InitializeComponent();
            nombre_textbox.Text = usuario.Nombre;
            usuarioActual = usuario;
        }

        private void cambiar_contrasena_Button_Click(object sender, EventArgs e)
        {
            if (usuarioActual.Contrasenia != contrasena_anterior_textBox.Text)
            {
                //Contraseña anterior incorrecta
                MessageBox.Show("Contraseña actual incorrecta", "Alerta",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RemarcarText();

            }
            else if (contrasena_nueva_textBox.Text != repite_contrasena_textBox.Text)
            {
                //mandar mensaje de contraseñas diferentes
                MessageBox.Show("Contraseña nueva no coincide", "Alerta",
       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RemarcarText();
            }
            else 
            {
                usuarioActual.Contrasenia = contrasena_nueva_textBox.Text;
                new DAOUsuarios().ModifyUser(usuarioActual);
                MessageBox.Show("Contraseña cambiada", "Alerta",
      MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Hide();
            }
        }
        public void RemarcarText() 
        {
           
            contrasena_anterior_textBox.Focus();
            contrasena_anterior_textBox.SelectionStart = 0;
            contrasena_anterior_textBox.SelectionLength = contrasena_anterior_textBox.Text.Length;
            contrasena_nueva_textBox.Text = null;
            repite_contrasena_textBox = null;
           
        }
    }
}
