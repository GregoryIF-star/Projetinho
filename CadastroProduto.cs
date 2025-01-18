using System.Windows.Forms;

namespace Projetinho
{
    public partial class CadastroProduto : Form
    {
        private static CadastroProduto _instance;
        private CadastroProduto()
        {
            InitializeComponent();
        }

        public static CadastroProduto GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new CadastroProduto();
            }
            return _instance;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            Produto p1 = new Produto() { Nome = txtbnome.Text, Preco = numericUpDown1.Value };
            ProdutoRepository.Save(p1);
            
            var produtos = ProdutoRepository.FindAll();
            dataGridView1.DataSource = produtos;

            txtbnome.Focus();
            txtbnome.SelectAll();
         
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void numericUpDown1_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Select(0, numericUpDown1.Text.Length);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}