using ScopeMed.Core.Models;
using ScopeMed.Interface.Interfaces;
using System.Data.SqlClient;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ScopeMed.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("SELECT UserId, Email, PasswordHash FROM Users WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User
                        {
                            UserId = reader.GetInt32(0),
                            Email = reader.GetString(1),
                            PasswordHash = reader.GetString(2)
                        };
                    }
                }
            }

            return null;
        }

        public async Task<bool> AddUserAsync(User user)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("INSERT INTO Users (email, encryptedPassword, dateCreate, firstName, lastName, isVerified) VALUES (@Email, @Password, @DateCreate, @FirstName, @LastName, @IsVerified)", conn);
                command.Parameters.AddWithValue("@Email", data.Email);
                command.Parameters.AddWithValue("@Password", EncryptPassword(data.Password));
                command.Parameters.AddWithValue("@DateCreate", DateTime.UtcNow);
                command.Parameters.AddWithValue("@FirstName", data.FirstName);
                command.Parameters.AddWithValue("@LastName", data.LastName);
                command.Parameters.AddWithValue("@IsVerified", false);

                var result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }
    }
}
