using System.Collections.Generic;

namespace UniDaysHomework.Services
{
    public class CreateUserResult
    {
        public readonly bool Success;
        public readonly List<string> Errors;

        private CreateUserResult(bool success, List<string> errors)
        {
            Success = success;
            Errors = errors;
        }

        public static CreateUserResult CreateFailureResult(List<string> errors)
        {
            return new CreateUserResult(false, errors);
        }

        public static CreateUserResult CreateSuccessResult()
        {
            return new CreateUserResult(true, null);
        }
    }
}
