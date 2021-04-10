using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FornecedorBLL
    {
        private int id;
        private string razao;
        private string cnpj;
        private string telefone;
        private string email;

        public int Id { get => id; set => id = value; }
        public string Razao { get => razao; set => razao = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string Telefone { get => telefone; set => telefone = value; }
        public string Email { get => email; set => email = value; }

        Conexao con;

        public bool Gravar()
        {
            con = new Conexao();
            string sql = "insert into tbfornecedor(razao, cnpj, telefone, email) values ('" + Razao + "','" + Cnpj + "', '" + Telefone + "', '" + Email + "')";
            return con.ComandoSQL(sql);
        }

        public void Pesquisar()
        {
            con = new Conexao();
            string sql = "select * from tbfornecedor where id=" + Id;
            DataSet ds;
            ds = con.Retorna(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Array dados = ds.Tables[0].Rows[0].ItemArray;
                id = Convert.ToInt32(dados.GetValue(0));
                Razao = Convert.ToString(dados.GetValue(1));
                Cnpj = Convert.ToString(dados.GetValue(2));
                Telefone = Convert.ToString(dados.GetValue(3));
                Email = Convert.ToString(dados.GetValue(4));
            }
            else
            {
                id = 0;
            }
        }

        public bool Atualizar()
        {
            con = new Conexao();
            string sql = "update tbfornecedor set razao='" + Razao + "', cnpj='" + Cnpj + "', telefone='" + Telefone + "', email='" + Email + "' where id=" + Id;
            return con.ComandoSQL(sql);
        }

        public bool Excluir()
        {
            con = new Conexao();
            string sql = "delete from tbfornecedor where id=" + Id;
            return con.ComandoSQL(sql);
        }

        public DataTable PesquisarTodos()
        {
            try
            {
                con = new Conexao();
                string sql = "select * from tbfornecedor";
                DataTable dt = new DataTable();
                dt = con.RetornaTodos(sql);
                return dt;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
