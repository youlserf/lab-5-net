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
    public class DProduct


    {
        

        private string connectionString= "server=LAB707-06\\SQLEXPRESS; database=lab5; Integrated Security = True;";

       
        public   List<Product> Listar(string name)
        {

            //Obtengo la conexión
            SqlConnection connection = null;
            SqlParameter param = null;
            SqlCommand command = null;
            List<Product> products = null;
            try
            {
                connection = new SqlConnection(connectionString);

                connection.Open();

                //Hago mi consulta
                command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                param = new SqlParameter();
                param.ParameterName = "@Name";
                param.SqlDbType = SqlDbType.VarChar;
                param.Value = name;

                command.Parameters.Add(param);

                SqlDataReader reader = command.ExecuteReader();
                products = new List<Product>();


                while (reader.Read())
                {

                    Product Product = new Product();
                    Product.IdProduct = (int)reader["id"];
                    Product.Name = reader["name"].ToString();
                    Product.Price = (decimal)reader["price"];

                    products.Add(Product);

                }

                connection.Close();

                //Muestro la información
                return products;


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
                products = null;

            }


        }

        
        public void Insertar(Product Product)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertProduct", connection); // Nombre del procedimiento almacenado
                    command.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado                
                    command.Parameters.AddWithValue("@Name", Product.Name);
                    command.Parameters.AddWithValue("@Price", Product.Price);

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
