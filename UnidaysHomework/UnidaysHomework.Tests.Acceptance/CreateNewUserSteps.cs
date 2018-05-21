using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UnidaysHomework.Tests.Acceptance
{
    [Binding]
    public class CreateNewUserSteps : StepsBase
    {
        protected RemoteWebDriver Driver
        {
            get => Get<RemoteWebDriver>("driver");
            set => Set(value, "driver");
        }

        [BeforeScenario]
        public void StartupWebDriver()
        {
            Driver = new EdgeDriver();
        }

        [AfterScenario]
        public void ShutdownWebDriver()
        {
            Driver?.Wait(1000);
            Driver?.Close();
            Driver?.Dispose();
        }

        private class FormInput
        {
            public string EmailAddress { get; set; }
            public string Password { get; set; }
        }

        private class UserDatabaseModel
        {
            public int Id { get; set; }
            public string EmailAddress { get; set; }
            public string PasswordHash { get; set; }
        }

        private string SiteUrl
        {
            get => Get<string>("websiteUrl");
            set => Set(value, "websiteUrl");
        }

        private FormInput TestCredentials
        {
            get => Get<FormInput>();
            set => Set(value);
        }

        private UserDatabaseModel UserInDatabase
        {
            get => Get<UserDatabaseModel>();
            set => Set(value);
        }

        [Given(@"I am using the test user credentials")]
        public void GivenIAmUsingTheTestUserCredentials(Table table)
        {
            TestCredentials = table.CreateInstance<FormInput>();
        }

        [Given(@"I have not already added the test user to the database")]
        public void GivenIHaveNotAlreadyAddedTheTestUserToTheDatabase()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniDaysDatabase"].ConnectionString))
            {
                conn.Execute("DELETE FROM [User] WHERE EmailAddress = @EmailAddress", new { TestCredentials.EmailAddress });
            }
        }

        [Given(@"I am using the local instance of the website")]
        public void GivenIAmUsingTheLocalInstanceOfTheWebsite()
        {
            SiteUrl = "http://localhost:51963/";
        }

        [Given(@"I have already added the test user to the database")]
        public void GivenIHaveAlreadyAddedTheTestUserToTheDatabase()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniDaysDatabase"].ConnectionString))
            {
                conn.Execute("DELETE FROM [User] WHERE EmailAddress = @EmailAddress; INSERT INTO [User] (EmailAddress, PasswordHash) VALUES (@EmailAddress, 'somehashedpassword')", new { TestCredentials.EmailAddress, TestCredentials.Password });
            }
        }

        [When(@"I complete the add user form with the test credentials")]
        public void WhenICompleteTheAddUserFormWithTheTestCredentials()
        {
            Driver.Url(SiteUrl);
            Driver.SetTextForId("EmailAddress", TestCredentials.EmailAddress, true);
            Driver.SetTextForId("Password", TestCredentials.Password, true);
            Driver.Wait(100);
            new Actions(Driver).Click(Driver.FindElementById("submit")).Perform();
            Driver.WaitForNavigationToComplete();
            Driver.Wait(3000);
        }

        [When(@"I complete the add user form without entering any details")]
        public void WhenICompleteTheAddUserFormWithoutEnteringAnyDetails()
        {
            Driver.Url(SiteUrl);
            // should be empty anyway, but just in case...
            Driver.SetTextForId("EmailAddress", string.Empty, true);
            Driver.SetTextForId("Password", string.Empty, true);

            Driver.Wait(100);
            new Actions(Driver).Click(Driver.FindElementById("submit")).Perform();
            Driver.WaitForNavigationToComplete();
            Driver.Wait(3000);
        }

        [When(@"I complete the add user form with the details")]
        public void WhenICompleteTheAddUserFormWithTheDetails(Table table)
        {
            TestCredentials = table.CreateInstance<FormInput>();

            Driver.Url(SiteUrl);
            Driver.SetTextForId("EmailAddress", TestCredentials.EmailAddress);
            Driver.SetTextForId("Password", TestCredentials.Password);
            Driver.Submit();
        }

        [Then(@"the test email address will exist in the database")]
        public void ThenTheTestEmailAddressWillExistInTheDatabase()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniDaysDatabase"].ConnectionString))
            {
                UserInDatabase = conn.Query<UserDatabaseModel>("SELECT Id, EmailAddress, PasswordHash FROM [User] WHERE EmailAddress = @EmailAddress", new { TestCredentials.EmailAddress }).SingleOrDefault();
            }

            Assert.IsNotNull(UserInDatabase);
            Assert.AreEqual(TestCredentials.EmailAddress, UserInDatabase.EmailAddress);
        }

        [Then(@"the password will have been hashed")]
        public void ThenThePasswordWillHaveBeenHashed()
        {
            // ensure there's something there, and that it's not the unhashed password, we'll trust that this is the hashed version
            Assert.IsFalse(string.IsNullOrWhiteSpace(UserInDatabase.PasswordHash));
            Assert.AreNotEqual(TestCredentials.Password, UserInDatabase.PasswordHash);
        }

        [Then(@"the site will show a message indicating the user has been created")]
        public void ThenTheSiteWillShowAMessageIndicatingTheUserHasBeenCreated()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the site will show me a message indicating that the user already exists")]
        public void ThenTheSiteWillShowMeAMessageIndicatingThatTheUserAlreadyExists()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the test email address will not have been added to the database again")]
        public void ThenTheTestEmailAddressWillNotHaveBeenAddedToTheDatabaseAgain()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UniDaysDatabase"].ConnectionString))
            {
                UserInDatabase = conn.Query<UserDatabaseModel>("SELECT Id, EmailAddress, PasswordHash FROM [User] WHERE EmailAddress = @EmailAddress", new { TestCredentials.EmailAddress, TestCredentials.Password }).SingleOrDefault();
            }

            // With did .SingleOrDefault() so this woud be null if  there was more than one user with the same email address
            Assert.IsNotNull(UserInDatabase);
        }

        [Then(@"the site will indicate that the email address is required")]
        public void ThenTheSiteWillIndicateThatTheEmailAddressIsRequired()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the site will indicate that the password is required")]
        public void ThenTheSiteWillIndicateThatThePasswordIsRequired()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the site will indicate that the email address is not valid")]
        public void ThenTheSiteWillIndicateThatTheEmailAddressIsNotValid()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"the site will indicate that the password is not valid")]
        public void ThenTheSiteWillIndicateThatThePasswordIsNotValid()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
