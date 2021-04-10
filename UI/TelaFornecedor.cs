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
    public partial class TelaFornecedor : Form
    {
        public TelaFornecedor()
        {
            InitializeComponent();
            desabilita();
        }

        FornecedorBLL fornecedor;

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilita();
        }

        public void desabilita()
        {
            txtEmail.Enabled = false;
            txtRazao.Enabled = false;
            mtbCnpj.Enabled = false;
            mtbTelefone.Enabled = false;
            btnAtualizar.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        public void habilita()
        {
            txtEmail.Enabled = true;
            txtRazao.Enabled = true;
            mtbCnpj.Enabled = true;
            mtbTelefone.Enabled = true;
            btnAtualizar.Enabled = true;
            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = true;
        }

        public void limpar()
        {
            txtEmail.Text = null;
            txtId.Text = null;
            txtRazao.Text = null;
            mtbCnpj.Text = null;
            mtbTelefone.Text = null;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            fornecedor = new FornecedorBLL();
            fornecedor.Razao = txtRazao.Text;
            fornecedor.Telefone = mtbTelefone.Text;
            fornecedor.Cnpj = mtbCnpj.Text;
            fornecedor.Email = txtEmail.Text;
            if (fornecedor.Gravar())
            {
                MessageBox.Show("Cadastrado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível cadastrar");
            }
            limpar();
            desabilita();
            carrega_datagrid();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            fornecedor = new FornecedorBLL();
            fornecedor.Id = int.Parse(txtId.Text);
            fornecedor.Pesquisar();
            if (fornecedor.Id == 0)
            {
                MessageBox.Show("Fornecedor não encontrado!");
            }
            else
            {
                txtEmail.Text = fornecedor.Email;
                txtRazao.Text = fornecedor.Razao;
                mtbCnpj.Text = fornecedor.Cnpj;
                mtbTelefone.Text = fornecedor.Telefone;
            }
            habilita();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            fornecedor = new FornecedorBLL();
            fornecedor.Id = int.Parse(txtId.Text);
            fornecedor.Razao = txtRazao.Text;
            fornecedor.Email = txtEmail.Text;
            fornecedor.Cnpj = mtbCnpj.Text;
            fornecedor.Telefone = mtbTelefone.Text;

            if (fornecedor.Atualizar())
            {
                MessageBox.Show("Atualizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível atualizar!");
            }
            limpar();
            desabilita();
            carrega_datagrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            fornecedor = new FornecedorBLL();
            fornecedor.Id = int.Parse(txtId.Text);

            if (fornecedor.Excluir())
            {
                MessageBox.Show("Excluido com sucesso!");
            }
            else
            {
                MessageBox.Show("Não foi possível excluir!");
            }
            limpar();
            desabilita();
            carrega_datagrid();
        }

        private void TelaFornecedor_Load(object sender, EventArgs e)
        {
            carrega_datagrid();
        }

        private void carrega_datagrid()
        {
            fornecedor = new FornecedorBLL();
            dataGridView1.DataSource = fornecedor.PesquisarTodos();
        } 
    }
}
