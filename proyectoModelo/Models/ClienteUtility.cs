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


        //Metodo Editar cliente

        public bool EditarCliente(ClienteModelo cli)
        {
            conexion();
            SqlCommand com = new SqlCommand("SP_EditarCliente",con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {
                com.Parameters.AddWithValue("@id", cli.id);
                com.Parameters.AddWithValue("@nombres", cli.nombres);
                com.Parameters.AddWithValue("@apellidos", cli.apellidos);
                com.Parameters.AddWithValue("@fecha", Convert.ToDateTime(cli.fechaString).ToString("dd/MM/yyyy"));
                com.Parameters.AddWithValue("@sueldo",cli.sueldo);

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
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }


        }


        //metodo eliminar cliente
        public bool EliminarCliente(int id)
        {
            conexion();
            SqlCommand com = new SqlCommand("SP_EliminarCliente",con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {
               
               com.Parameters.AddWithValue("@id", id);
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
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();
            }
            
        }



        //Metodo Obtener Cliente
        public List<ClienteModelo> obtenerCLientes()
        {
            conexion();
            List<ClienteModelo> CliList = new List<ClienteModelo>();


            SqlCommand com = new SqlCommand("SP_ObtenerClientes", con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {

                    CliList.Add(

                        new ClienteModelo
                        {

                            id = Convert.ToInt32(dr["ID"]),
                            nombres = Convert.ToString(dr["NOMBRES"]),
                            apellidos = Convert.ToString(dr["APELLIDOS"]),
                            fechaString= Convert.ToDateTime(dr["FECHA_NACIMIENTO"]).ToString("dd/MM/yyyy"),
                            sueldo = Convert.ToDecimal(dr["SUELDO"])
                        }
                        );
                }

                return CliList;
            }

            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        //Metodo Obtener Cliente
        public List<ClienteModelo> obtenerCLientesR()
        {
            List<ClienteModelo> CliList = new List<ClienteModelo>();
            conexion();
            
            SqlCommand com = new SqlCommand("SP_ObtenerClientes", con);
            com.CommandType = CommandType.StoredProcedure;

            try
            {

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet dataset = new DataSet();

                // Llena el DataSet con los datos recuperados por el SqlDataAdapter
                da.Fill(dataset);
                List<ClienteModelo> mo = new List<ClienteModelo>();

                foreach (DataRow dr in dataset.Tables[0].Rows)
                {

                    ClienteModelo m = new ClienteModelo();
                    m.id = Convert.ToInt32(dr["ID"]);
                    m.nombres = Convert.ToString(dr["NOMBRES"]);
                    m.apellidos = Convert.ToString(dr["APELLIDOS"]);
                    m.fechaString = Convert.ToDateTime(dr["FECHA_NACIMIENTO"]).ToString("dd/MM/yyyy");
                    m.sueldo = Convert.ToDecimal(dr["SUELDO"]);
                    mo.Add(m);   
                }

                return CliList;
            }

            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return null;
            }
            finally
            {
                con.Close();
            }
        }

    }
}