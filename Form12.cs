namespace Projetinho
{
    public partial class Form12 : Form
    {
        private static Form12 _instance;
        private Form12()
        {
            InitializeComponent();
        }

        public static Form12 GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Form12();
            }
            return _instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Credencial c = new Credencial();
            c.Email = "root";
            c.Senha = "1";
            c.Administrador = true;

            Usuario u = new Usuario();
            u.Nome = "1";
            u.Credencial = c;
            c.Usuario = u;

            if (UsuarioRepository.Autenticar(textBox1.Text, Credencial.ComputeSHA256(textBox2.Text)) != null)
            {
                Sisteminha.GetInstance(UsuarioRepository.
                    Autenticar(textBox1.Text, Credencial.ComputeSHA256(textBox2.Text))).Show();
                textBox2.Clear();
                textBox1.Focus();
                this.Hide();
            }
            else if (textBox1.Text == u.Nome && Credencial.ComputeSHA256(textBox2.Text) == c.Senha)
            {
                Sisteminha.GetInstance(u).Show();
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
    }
}
