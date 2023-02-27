using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace proyectoModelo.Models
{
    public class ClienteUtility
    {
        private SqlConnection con;

        private void conexion()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conectar"].ToString();
            con = new SqlConnection(constr);
        }



    }
}