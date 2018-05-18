using System.Linq;
using UnidaysHomework.Data;
using UnidaysHomework.PasswordHashing;
using UniDaysHomework.Services.Validation;

namespace UniDaysHomework.Services
{
    public class UserService : IUserService
    {
        private IModelValidator<CreateUserParameters> _createUserValidator;
        private IPasswordHasher _passwordHasher;
        private IUserStore _userStore;

        public UserService(IModelValidator<CreateUserParameters> createUserValidator, IPasswordHasher passwordHasher, IUserStore userStore)
        {
            _createUserValidator = createUserValidator;
            _passwordHasher = passwordHasher;
            _userStore = userStore;
        }

        public CreateUserResult Create(CreateUserParameters parameters)
        {
            var validationErrors = _createUserValidator.Validate(parameters).ToList();

            if (validationErrors.Any())
            {
                return CreateUserResult.CreateFailureResult(validationErrors);
            }

            var hashedPassword = _passwordHasher.Hash(parameters.Password);

            var userId = _userStore.Create(parameters.EmailAddress, hashedPassword);

            return CreateUserResult.CreateSuccessResult(userId);
        }
    }
}
