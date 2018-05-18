namespace UnidaysHomework.PasswordHashing
{
    public class BCryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string passwordToHash)
        {
            return BCrypt.Net.BCrypt.HashPassword(passwordToHash, BCrypt.Net.BCrypt.GenerateSalt(12));
        }
    }
}
