using System.ComponentModel.DataAnnotations;
using UnidaysHomework.Validation;

namespace UnidaysHomework.Models
{
    public class CreateUserInputModel
    {
        [Required,EmailAddress,CheckIfUserExists]
        public string EmailAddress { get; set; }

        [Required,MeetsPasswordRules]
        public string Password { get; set; }
    }
}