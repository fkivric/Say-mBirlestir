using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SayimBirlestir
{
    class SqlConnectionObject
    {
        public String GetValue(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connectionstring))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            if (dt.Rows != null)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return "";
            }
        }
        public DataTable GetData(string spName, SqlConnection sql)
        {
            DataTable returnType = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(spName, sql);
            da.Fill(returnType);
            if (returnType.Rows.Count > 0)
            {
                return returnType;
            }
            else
            {
                return null;
            }
        }
    }
}
