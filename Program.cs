namespace Projetinho
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Repository repo = new Repository();


            if (UsuarioRepository.Autenticar("root", Credencial.ComputeSHA256("ifnmg")) == null)
            {
                Credencial c = new Credencial();
                c.Email = "root";
                c.Senha = "ifnmg";
                c.Administrador = true;

                Usuario u = new Usuario();
                u.Nome = "root";
                u.Credencial = c;
                c.Usuario = u;
                UsuarioRepository.Save(u);
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(Form1.GetInstance());
        }
    }
}