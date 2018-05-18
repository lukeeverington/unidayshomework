using System.Collections.Generic;

namespace UniDaysHomework.Services
{
    public class CreateUserResult
    {
        public readonly bool Success;
        public readonly int? UserId;
        public readonly List<string> Errors;

        private CreateUserResult(bool success, int? userId, List<string> errors)
        {
            Success = success;
            UserId = userId;
            Errors = errors;
        }

        public static CreateUserResult CreateFailureResult(List<string> errors)
        {
            return new CreateUserResult(false, null, errors);
        }

        public static CreateUserResult CreateSuccessResult(int userId)
        {
            return new CreateUserResult(true, userId, null);
        }
    }
}
