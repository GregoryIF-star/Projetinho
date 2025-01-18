namespace Projetinho
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        private Form1()
        {
            InitializeComponent();
        }

        public static Form1 GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Form1();
            }
            return _instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsuarioRepository.Autenticar(textBox1.Text, Credencial.ComputeSHA256(textBox2.Text)) != null)
            {
                Sisteminha.GetInstance(UsuarioRepository.
                    Autenticar(textBox1.Text, Credencial.ComputeSHA256(textBox2.Text))).Show();
                textBox2.Clear();
                textBox1.Focus();
                this.Hide();
            }
            else
            {
                textBox2.Clear();
                textBox1.Focus();
                textBox1.SelectAll();
                label3.Visible = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            label3.Visible = false;
        }
    }
}
