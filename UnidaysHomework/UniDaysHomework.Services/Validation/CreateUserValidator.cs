using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private const string _emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public bool IsValidEmailAddress(string passwordToValidate)
        {
            return Regex.IsMatch(passwordToValidate, _emailRegex);
        }
    }

    public interface IPasswordValidator
    {
        bool IsValidPassword(string passwordToValidate);
    }

    public class StandardPasswordValidator : IPasswordValidator
    {
        private const int minChars = 4;
        private const int maxChars = 30;

        public bool IsValidPassword(string passwordToValidate)
        {
            if (string.IsNullOrWhiteSpace(passwordToValidate))
            {
                return false;
            }

            if (MeetsMinLength(passwordToValidate) &&
                MeetsMaxLength(passwordToValidate) &&
                ContainsLowerCase(passwordToValidate) &&
                ContainsUpperCase(passwordToValidate) &&
                ContainsNumber(passwordToValidate))
            {
                return true;
            }

            return false;
        }

        private bool MeetsMinLength(string password)
        {
            return password.Length >= minChars;
        }

        private bool MeetsMaxLength(string password)
        {
            return password.Length <= maxChars;
        }

        private bool ContainsUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool ContainsLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool ContainsNumber(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
