using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
    public class DRegion


    {
        

        private string connectionString= "server=LAB707-06\\SQLEXPRESS; database=msdb; Integrated Security = True;";

       
        public   List<Region> Listar()
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Region> regiones = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("USP_GetRegion", connection);
                command.CommandType = CommandType.StoredProcedure;

                //param = new SqlParameter();
                //param.ParameterName = "@Description";
                //param.SqlDbType = SqlDbType.VarChar;
                //param.Value = description;

                //command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                regiones = new List<Region>();


                while (reader.Read())
                {

                    Region region = new Region();
                    region.IdRegion = (int)reader["RegionID"];
                    region.Description = reader["Description"].ToString();
                    region.Code = reader["Code"].ToString();

                    regiones.Add(region);

                }

                connection.Close();

                //Muestro la información
                return regiones;


            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }
            finally
            {
                connection = null;
                command = null;
                param = null;
                regiones = null;

            }


        }

        public void Insertar(Region region)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("USP_InsRegion", connection); // Nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@RegionID", region.IdRegion);
                    command.Parameters.AddWithValue("@Code", region.Code);
                    command.Parameters.AddWithValue("@Description", region.Description);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

    }
}
