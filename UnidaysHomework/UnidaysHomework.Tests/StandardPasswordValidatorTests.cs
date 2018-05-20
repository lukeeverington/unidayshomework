using NUnit.Framework;
using UniDaysHomework.Services.Validation;

namespace UnidaysHomework.Tests
{
    [TestFixture]
    public class StandardPasswordValidatorTests
    {
        [TestCase("Password1")]
        [TestCase("ABCDEFg0")]
        public void AlowsValidPasswords(string validPassword)
        {
            var validator = new StandardPasswordValidator();
            Assert.IsTrue(validator.IsValidPassword(validPassword));
        }

        [TestCase("2Ab")]
        [TestCase("looksGoodButNoNumber")]
        [TestCase("123456789")]
        [TestCase("thisismi55ingacaptitalletter")]
        public void RejectsInvalidPasswords(string invalidPassword)
        {
            var validator = new StandardPasswordValidator();
            Assert.IsFalse(validator.IsValidPassword(invalidPassword));
        }
    }
}
