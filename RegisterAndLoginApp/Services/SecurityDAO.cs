using System;
using System.Data;
using System.Data.SqlClient;
using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Services
{
    public class SecurityDAO
    {
        string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;";



        public bool FindUserByNameAndPassword(UserModel user)
        {

            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Users WHERE username = @username AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@username", SqlDbType.VarChar, 50).Value = user.UserName;
                command.Parameters.Add("@password", SqlDbType.VarChar, 50).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
        public bool InsertUser(RegisterationModel user)
        {
            bool success = false;
            string sqlStatement = "INSERT INTO dbo.Users (Name, Email, Password, UserName) VALUES (@Name, @Email, @Password, @UserName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = user.Name;
                command.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = user.Email;
                command.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
                command.Parameters.Add("@UserName", SqlDbType.VarChar, 50).Value = user.UserName;

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return success;
        }
    }
}
