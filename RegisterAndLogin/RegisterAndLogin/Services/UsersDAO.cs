using RegisterAndLogin.Models;
using System.Data.SqlClient;

namespace RegisterAndLogin.Services
{
    public class UsersDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Users;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        public bool FindUserByNameOrPassword(UserModel user)
        {
            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE userName = @UserName AND password =@password";

            using (SqlConnection connection = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand(sqlStatement, connection);

                cmd.Parameters.Add("@UserName", System.Data.SqlDbType.VarChar, 40).Value = user.userName;
                cmd.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); 
                }
            }

            return success;


        }
    }
}
