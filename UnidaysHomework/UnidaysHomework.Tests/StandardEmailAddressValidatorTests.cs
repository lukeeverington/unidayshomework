using NUnit.Framework;
using UniDaysHomework.Services.Validation;

namespace UnidaysHomework.Tests
{
    [TestFixture]
    public class StandardEmailAddressValidatorTests
    {
        [TestCase("avalidemailaddress@test.com")]
        [TestCase("a-valid-email-address@test.co.uk")]
        [TestCase("firstname.lastname@domain.tld")]
        public void AlowsValidEmailAddresses(string validEmailAddress)
        {
            var validator = new StandardEmailAddressValidator();
            Assert.IsTrue(validator.IsValidEmailAddress(validEmailAddress));
        }

        [TestCase("1")]
        [TestCase("invalid.email.com")]
        [TestCase("not a legit email address")]
        [TestCase("looksright@butisn't")]
        public void RejectsInvalidEmailAddresses(string invalidEmailAddress)
        {
            var validator = new StandardEmailAddressValidator();
            Assert.IsFalse(validator.IsValidEmailAddress(invalidEmailAddress));
        }
    }
}
