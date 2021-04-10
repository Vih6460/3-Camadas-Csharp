using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula3
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }

        private Form tela;

        private void btnProduto_Click(object sender, EventArgs e)
        {
            tela?.Close();
            tela = new TelaProduto
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            pnlTela.Controls.Add(tela);
            tela.Show();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            tela?.Close();
            tela = new TelaFornecedor
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            pnlTela.Controls.Add(tela);
            tela.Show();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            tela?.Close();
            tela = new TelaPedido
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            pnlTela.Controls.Add(tela);
            tela.Show();
        }
    }
}
