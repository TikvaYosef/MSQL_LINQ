
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSQL_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Shop> list1 = new List<Shop>();
            try
            {
                string conectionS = "Data Source=DESKTOP-5E70RM2;Initial Catalog=msdb;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(conectionS))
                {
                    connection.Open();
                    string query = @"SELECT * FROM Shop";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader datafromdb = command.ExecuteReader();

                    if (datafromdb.HasRows)
                    {
                        while (datafromdb.Read())
                        {
                            list1.Add(new Shop(datafromdb.GetString(0),datafromdb.GetInt(1));
                            //Console.WriteLine(datafromdb.GetString(1));

                        }
                    }

                    else
                    {
                        Console.WriteLine("no rows in table");
                    }
                    connection.Close();
                }
               
            }
            catch(SqlException)
            {
                Console.WriteLine("error");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        
    }
    
}
