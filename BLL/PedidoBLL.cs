using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoBLL
    {
        private int numero;
        private DateTime data;
        private int fornecedor;
        private int produto;
        private int quantidade;

        public int Numero { get => numero; set => numero = value; }
        public DateTime Data { get => data; set => data = value; }
        public int Fornecedor { get => fornecedor; set => fornecedor = value; }
        public int Produto { get => produto; set => produto = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }

        Conexao con;

        public DataTable BuscarFornecedor()
        {
            con = new Conexao();
            string sql = "select * from tbfornecedor";
            DataTable dt = new DataTable();
            dt = con.RetornaTodos(sql);
            return dt;
        }
    }
}
