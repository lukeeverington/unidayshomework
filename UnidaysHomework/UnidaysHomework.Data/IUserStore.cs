using System.Data.SqlClient;

namespace UnidaysHomework.Data
{
    public interface IUserStore
    {
        void Create(string emailAddress, string passwordHash);
        bool UserExists(string emailAddress);
    }

    public class UserStore : IUserStore
    {
        private SqlConnection _sqlConnection;

        public UserStore(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        private const string CreateSql = @"INSERT INTO [User] (EmailAddress, PasswordHash) VALUES (@emailAddress, @passwordHash)";

        public void Create(string emailAddress, string passwordHash)
        {
            var command = new SqlCommand(CreateSql, _sqlConnection);
            command.Parameters.AddWithValue("@emailAddress", emailAddress);
            command.Parameters.AddWithValue("@passwordHash", passwordHash);
            command.ExecuteNonQuery();
        }

        private const string ExistsSql = @"SELECT COUNT(Id) FROM [User] WHERE EmailAddress = @emailAddress";

        public bool UserExists(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
            {
                return false;
            }

            var command = new SqlCommand(ExistsSql, _sqlConnection);
            command.Parameters.AddWithValue("@emailAddress", emailAddress);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                var count = (int)reader[0];
                if (count != 0)
                {
                    // anything other than 0 means the user exists
                    return true;
                }
            }

            return false;
        }
    }
}