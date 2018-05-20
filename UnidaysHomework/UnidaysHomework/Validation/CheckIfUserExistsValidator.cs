using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using UnidaysHomework.Data;

namespace UnidaysHomework.Validation
{
    public class CheckIfUserExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var store = DependencyResolver.Current.GetService<IUserStore>();

            var exists = store.UserExists(value as string);

            if (exists)
            {
                return new ValidationResult("User already exists with this email address", new List<string> { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }

    public class MeetsPasswordRulesAttribute : ValidationAttribute
    {
        private const int minChars = 4;
        private const int maxChars = 30;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return new ValidationResult("Password is required");
            }

            if (MeetsMinLength(password) && 
                MeetsMaxLength(password) && 
                ContainsLowerCase(password) && 
                ContainsUpperCase(password) && 
                ContainsNumber(password))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(
                $@"The password is does not meet the minimum requirements. Ensure it contains between {minChars} and {maxChars} characters and contains at least one upper case letter, one lower case letter and one number.", new List<string> { "Password" });
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