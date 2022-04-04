using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DogRegistry
{
    public class Authentication
    {
        public bool Login(string u_Name, string p_word)
        {
            SqlConnection conn = new SqlConnection(@"server = DESKTOP-AL42T46\TRAINEEINSTANCE; database=dogRegistryApp; integrated security=true");
            SqlCommand cmd_login = new SqlCommand("SELECT COUNT (*) FROM Login WHERE username = @u_Name AND password = @p_word", conn);
            cmd_login.Parameters.AddWithValue("@u_Name", u_Name);
            cmd_login.Parameters.AddWithValue("@p_word", p_word);
            
            try
            {
                conn.Open();
                int authorization_count = (int) cmd_login.ExecuteScalar();

                if(authorization_count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return true;

        }
    }
}
