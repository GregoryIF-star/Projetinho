using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projetinho
{
    public partial class CadastroUsuario : Form
    {
        private static CadastroUsuario _instance;
        private CadastroUsuario()
        {
            InitializeComponent();
        }

        public static CadastroUsuario GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CadastroUsuario();
            }
            return _instance;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    textBox2.Focus();
                    textBox2.SelectAll();
                    textBox3.Clear();
                    textBox1.Clear();
                    label4.Visible = true;
                    return;
                }

                Credencial c = new Credencial
                {
                    Email = textBox1.Text,
                    Senha = textBox3.Text,
                    Administrador = checkBox1.Checked
                };

                Usuario u = new Usuario
                {
                    Nome = textBox2.Text,
                    Credencial = c
                };

                UsuarioRepository.Save(u);
                label5.Visible = true;
                textBox2.Focus();
                textBox2.SelectAll();
                textBox3.Clear();
                textBox1.Clear();
            }
            catch (Exception ex)
            {

                label6.Visible = true;
                textBox2.Focus();
                textBox2.SelectAll();
                textBox3.Clear();
                textBox1.Clear();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
        }
    }
}
