using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace PIIBAPPDB
{
    internal class DataAccess
    {
        static string strConn = "Data Source=(local);Initial Catalog=PapelGive;Integrated Security=SSPI";
        public static SqlConnection conn = new SqlConnection(strConn);


        public static SqlConnection getConn()
        {
            return conn;

        }
        public static SqlCommand getComm(string strComm)
        {
            SqlCommand comm = new SqlCommand(strConn);
            return comm;
        }
    }
}
