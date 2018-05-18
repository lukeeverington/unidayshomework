namespace UniDaysHomework.Services
{
    public class CreateUserParameters
    {
        public readonly string EmailAddress;
        public readonly string Password;

        public CreateUserParameters(string emailAddress, string password)
        {
            EmailAddress = emailAddress;
            Password = password;
        }
    }
}
