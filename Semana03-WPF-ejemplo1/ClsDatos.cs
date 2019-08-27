using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Semana03_WPF_ejemplo1
{
    class ClsDatos
    {
        public SqlConnection LeerCadena()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["kotoha"].ConnectionString);
        }

        public DataTable getListOrderDate(DateTime x, DateTime y)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_dateToDate", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@date1", x);
            sqlData.SelectCommand.Parameters.AddWithValue("@date2", y);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public DataTable getDetailsList(int x)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_detailOrder", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@orderId", x);
            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public double totalOrder(Int32 idOrder)
        {
            SqlConnection connection = LeerCadena();
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("usp_totalAmountOrder2", connection);
            sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlData.SelectCommand.Parameters.AddWithValue("@orderId", idOrder);
            sqlData.SelectCommand.Parameters
                .Add("@Total", SqlDbType.Money).Direction = ParameterDirection.Output;
            sqlData.SelectCommand.ExecuteScalar();
            Int32 total = Convert.ToInt32(sqlData.SelectCommand.Parameters["@total"].Value);
            connection.Close();
            return total;
        }


    }
}
