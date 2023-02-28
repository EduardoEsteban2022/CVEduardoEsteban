using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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


        //Metodo insertar cliente
        public bool AgregarCliente(ClienteModelo obj)
        {

            conexion();
            SqlCommand com = new SqlCommand("SP_AgregarCliente", con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {
                com.Parameters.AddWithValue("@nombres", obj.nombres);
                com.Parameters.AddWithValue("@apellidos", obj.apellidos);
                com.Parameters.AddWithValue("@fechaNacimiento", obj.fecha);
                com.Parameters.AddWithValue("@sueldo", obj.sueldo);

                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();
                if (i >= 1)
                {

                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch(Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
        }


    }
}