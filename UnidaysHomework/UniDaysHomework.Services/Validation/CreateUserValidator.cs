using System;
using System.Collections.Generic;
using UnidaysHomework.Data;

namespace UniDaysHomework.Services.Validation
{
    public interface IModelValidator<T>
    {
        IEnumerable<string> Validate(T item);
    }

    public class CreateUserValidator : IModelValidator<CreateUserParameters>
    {
        private IEmailAddressValidator _emailAddressValidator {get; set;}
        private IPasswordValidator _passwordValidator { get; set; }
        private IUserStore _userStore { get; set; }

        public CreateUserValidator(IEmailAddressValidator emailAddressValidator, IPasswordValidator passwordValidator, IUserStore userStore)
        {
            _emailAddressValidator = emailAddressValidator;
            _passwordValidator = passwordValidator;
            _userStore = userStore;
        }

        IEnumerable<string> IModelValidator<CreateUserParameters>.Validate(CreateUserParameters item)
        {
            if(item == null)
            {
                yield return "CreateUserParameters is required";
                yield break;
            }

            if (string.IsNullOrWhiteSpace(item.EmailAddress))
            {
                yield return "Email Address is required";
            }
            else if (!_emailAddressValidator.IsValidEmailAddress(item.EmailAddress))
            {
                yield return "Email address not valid";
            }

            if (string.IsNullOrWhiteSpace(item.Password))
            {
                yield return "Password is required";
            }
            else if(!_passwordValidator.IsValidPassword(item.Password))
            {
                yield return "Password is not valid";
            }

            if (_userStore.UserExists(item.EmailAddress))
            {
                yield return "User already exists";
            }
        }
    }

    public interface IEmailAddressValidator
    {
        bool IsValidEmailAddress(string emailAddressToValidate);
    }

    public class StandardEmailAddressValidator : IEmailAddressValidator
    {
        public bool IsValidEmailAddress(string emailAddressToValidate)
        {
            return true;

            // TODO: actually validate the email address
        }
    }

    public interface IPasswordValidator
    {
        bool IsValidPassword(string passwordToValidate);
    }

    public class StandardPasswordValidator : IPasswordValidator
    {
        public bool IsValidPassword(string passwordToValidate)
        {
            return true;
            
            // TODO: actually validate the password
        }
    }
}
