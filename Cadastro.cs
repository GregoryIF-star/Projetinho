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
    public partial class Cadastro : Form
    {
        private static Cadastro _instance;
        private Cadastro()
        {
            InitializeComponent();
        }
        public static Cadastro GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new Cadastro();
            }
            return _instance;
        }
    }
}
