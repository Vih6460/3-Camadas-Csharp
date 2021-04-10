using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexao
    {
        protected SqlConnection conexao = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDAula3;Data Source=PC-VIH\\SQLEXPRESS");
        protected SqlCommand cmd;
        private bool resultado;

        public bool ComandoSQL(string sql)
        {
            resultado = false;
            try
            {
                conexao.Open();
                cmd = new SqlCommand(sql, conexao);
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
            return resultado;
        }

        public DataSet Retorna(string sql)
        {
            try
            {
                conexao.Open();
                cmd = new SqlCommand(sql, conexao);
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }

        public DataTable RetornaTodos(string sql)
        {
            try
            {
                conexao.Open();
                cmd = new SqlCommand(sql, conexao);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable data = new DataTable();
                da.Fill(data);
                return data;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
