namespace UnidaysHomework.PasswordHashing
{
    public interface IPasswordHasher
    {
        string Hash(string passwordToHash);
    }
}
