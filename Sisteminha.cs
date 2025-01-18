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
    public partial class Sisteminha : Form
    {
        private static Usuario _usuario;
        private static Sisteminha _instance;
        private Sisteminha()
        {
            InitializeComponent();
            usuarioToolStripMenuItem.Enabled = _usuario.Credencial.Administrador;
            toolStripStatusLabel1.Text = _usuario.Nome + " || " + DateTime.Now;
        }
        public static Sisteminha GetInstance(Usuario usuario)
        {
            _usuario = usuario;
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Sisteminha();
            }
            return _instance;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Sisteminha_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.GetInstance().Show();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroUsuario.GetInstance().MdiParent = this;
            CadastroUsuario.GetInstance().Show();
            CadastroUsuario.GetInstance().BringToFront();
            CadastroUsuario.GetInstance().WindowState = FormWindowState.Normal;
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroProduto.GetInstance().MdiParent = this;
            CadastroProduto.GetInstance().Show();
            CadastroProduto.GetInstance().BringToFront();
            CadastroProduto.GetInstance().WindowState = FormWindowState.Normal;
        }
    }
}
