using BLL;
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
    public partial class TelaPedido : Form
    {
        public TelaPedido()
        {
            InitializeComponent();
        }

        PedidoBLL pedido;

        private void TelaPedido_Load(object sender, EventArgs e)
        {
            carrega_fornecedor();
        }

        private void carrega_fornecedor()
        {
            pedido = new PedidoBLL();
            cbxFornecedor.ValueMember = "id";
            cbxFornecedor.DisplayMember = "razao";
            cbxFornecedor.DataSource = pedido.BuscarFornecedor();
            cbxFornecedor.SelectedValue = -1;
            cbxFornecedor.Update();
        }
    }
}
