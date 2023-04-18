using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Obtengo la conexión
            SqlConnection connection = new SqlConnection("Data Source=HUGO-PC\\SQLEXPRESS;Initial Catalog=CAVV_MonitoreoViolencia;Integrated Security=True;");

            connection.Open();
            //Hago mi consulta
            SqlCommand command = new SqlCommand("select  Code,Description from region", connection);

            //
            SqlDataReader dataReader = command.ExecuteReader();

            connection.Close();

            List<Region> regions = new List<Region>();
            while (dataReader.Read())
            {

                regions.Add(new Region()
                {
                    Code = dataReader["Code"].ToString(),
                    Description = dataReader["Description"].ToString(),

                });                               

            }            



            Console.Read();


        }
    }
}
