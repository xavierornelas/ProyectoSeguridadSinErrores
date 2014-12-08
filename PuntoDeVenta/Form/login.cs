using DAO;
using DTO;
using PuntoDeVenta.DAO;
using PuntoDeVenta.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace punto_venta
{
    public partial class login : Form
    {
        Usuarios user = new Usuarios();
        List<Usuarios> usuario = null;
       
        public login()
        {
            InitializeComponent();
            clave_scanner_textBox.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios datosUsuario = new Usuarios();
            usuario = new DAOUsuarios().GetUsers();
            string user = user_textBox.Text, pass = Contra.Text;
            bool bandera = false;
            foreach(Usuarios objeto in usuario)
            {
                if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia)) 
                {
                    bandera = true;
                    this.user = objeto;
                }
            }
           
            if (bandera)
            {
                if (UsuariosDefault())
                {
                    MessageBox.Show("Debes cambiar las contraseñas por default, accesa al modulo de usuarios", "Alerta",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Contenedor ventana = new Contenedor(this.user,1);
                    this.Hide();
                    ventana.Show();
                }
                else if (new DAOContrasena_fecha().ObtenerDias(this.user.Id) >= 30)
                {
                    MessageBox.Show("Debes cambiar la contraseña, se caduca cada 30 días.", "Alerta",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Contenedor ventana = new Contenedor(this.user, 2);
                    this.Hide();
                    ventana.Show();
                }
                else 
                {
                    Contenedor ventana = new Contenedor(this.user,3);
                    this.Hide();
                    ventana.Show();
                }
                
                
            }
            else 
            {
                MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool UsuariosDefault() 
        {
            bool usuariodefault=false;
            usuario = new DAOUsuarios().GetUsers();
            foreach (Usuarios temp in usuario)
            {
                if ((temp.Nombre.Equals("admin") && temp.Contrasenia.Equals("admin")) || (temp.Nombre.Equals("empleado") && temp.Contrasenia.Equals("empleado")))
                {
                   
                    usuariodefault = true;
                    break;
                }
            }
            return usuariodefault;
        }
        private void Contra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Usuarios datosUsuario = new Usuarios();
                usuario = new DAOUsuarios().GetUsers();
                string user = user_textBox.Text, pass = Contra.Text;
                bool bandera = false;
                foreach (Usuarios objeto in usuario)
                {
                    if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia))
                    {
                        bandera = true;
                        this.user = objeto;
                    }
                }

                if (bandera)
                {
                    if (UsuariosDefault())
                    {
                        MessageBox.Show("Debes cambiar las contraseñas por default, accesa al modulo de usuarios", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(this.user,1);
                        this.Hide();
                        ventana.Show();
                    }
                    else if(new DAOContrasena_fecha().ObtenerDias(this.user.Id)==30)
                    {
                        MessageBox.Show("Debes cambiar la contraseña, se caduca cada 30 días.", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(this.user,2);
                        this.Hide();
                        ventana.Show();
                    }
                    else
                    {
                        Contenedor ventana = new Contenedor(this.user,3);
                        this.Hide();
                        ventana.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void User_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                Usuarios datosUsuario = new Usuarios();
                usuario = new DAOUsuarios().GetUsers();
                string user = user_textBox.Text, pass = Contra.Text;
                bool bandera = false;
                foreach (Usuarios objeto in usuario)
                {
                    if (user.Equals(objeto.Nombre) && pass.Equals(objeto.Contrasenia))
                    {
                        bandera = true;
                        this.user = objeto;
                    }
                }

                if (bandera)
                {
                    if (UsuariosDefault())
                    {
                        MessageBox.Show("Debes cambiar las contraseñas por default, accesa al modulo de usuarios", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(this.user,1);
                        this.Hide();
                        ventana.Show();
                    }
                    else if (new DAOContrasena_fecha().ObtenerDias(this.user.Id) == 30)
                    {
                        MessageBox.Show("Debes cambiar la contraseña, se caduca cada 30 días.", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(this.user, 2);
                        this.Hide();
                        ventana.Show();
                    }
                    else
                    {
                        Contenedor ventana = new Contenedor(this.user,3);
                        this.Hide();
                        ventana.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña INCORRECTA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void Contra_TextChanged(object sender, EventArgs e)
        {

        }

        private void clave_scanner_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
            if(e.KeyChar==(char)Keys.Enter)
            {
                dto_clave_scaner clave = null;
                clave = new DAOClave_scaner().Getclave_scaner(clave_scanner_textBox.Text);
                if (clave!= null)
                {
                    if (UsuariosDefault())
                    {
                        MessageBox.Show("Debes cambiar las contraseñas por default, accesa al modulo de usuarios", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(new DAOUsuarios().GetUser(clave.id_usuario),1);
                        this.Hide();
                        ventana.Show();
                    }
                    else if (new DAOContrasena_fecha().ObtenerDias(this.user.Id) == 30)
                    {
                        MessageBox.Show("Debes cambiar la contraseña, se caduca cada 30 días.", "Alerta",
            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Contenedor ventana = new Contenedor(this.user, 2);
                        this.Hide();
                        ventana.Show();
                    }
                    else
                    {
                        Contenedor ventana = new Contenedor(new DAOUsuarios().GetUser(clave.id_usuario),3);
                        this.Hide();
                        ventana.Show();
                    }
                    
                }
                else 
                {
                    MessageBox.Show("No existe clave.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RemarcarClave();
                }
            }
        }
        public void RemarcarClave() 
        {
            clave_scanner_textBox.Focus();
            clave_scanner_textBox.SelectionStart = 0;
            clave_scanner_textBox.SelectionLength = clave_scanner_textBox.Text.Length;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void login_Activated(object sender, EventArgs e)
        {
            clave_scanner_textBox.Focus();
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                clave_scanner_textBox.Focus();
            }
            else 
            {
                user_textBox.Focus();
            }
        }

        private void tabPage1_MouseClick(object sender, MouseEventArgs e)
        {
            clave_scanner_textBox.Focus();
        }

        private void tabPage2_MouseClick(object sender, MouseEventArgs e)
        {
            user_textBox.Focus();
        }

        private void user_textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void Contra_KeyPress(object sender, KeyPressEventArgs e)
        {
          
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
