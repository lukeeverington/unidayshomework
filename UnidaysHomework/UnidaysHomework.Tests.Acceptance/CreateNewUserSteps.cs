using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace UnidaysHomework.Tests.Acceptance
{
    [Binding]
    public class StepsBase
    {
        public static T Get<T>(string key = null)
        {
            return key == null ? ScenarioContext.Current.Get<T>() : ScenarioContext.Current.Get<T>(key);
        }

        public static void Set<T>(T item, string key = null)
        {
            if(key == null)
            {
                ScenarioContext.Current.Set(item);
            }
            else
            {
                ScenarioContext.Current.Set(item, key);
            }
        }
    }

    [Binding]
    public class CreateNewUserSteps : StepsBase
    {
        private class FormInput
        {
            public string EmailAddress { get; set; }
            public string Password { get; set; }
        }

        private string SiteUrl
        {
            get { return Get<string>("websiteUrl"); }
            set { Set(value, "websiteUrl"); }
        }

        private FormInput TestCredentials
        {
            get { return Get<FormInput>(); }
            set { Set(value); }
        }

        [Given(@"I am using the test user credentials")]
        public void GivenIAmUsingTheTestUserCredentials(Table table)
        {
            TestCredentials = table.CreateInstance<FormInput>();
        }
        
        [Given(@"I have not already added the test user to the database")]
        public void GivenIHaveNotAlreadyAddedTheTestUserToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I am using the local instance of the website")]
        public void GivenIAmUsingTheLocalInstanceOfTheWebsite()
        {
            SiteUrl = "http://localhost:51963/";
        }
        
        [Given(@"I have already added the test user to the database")]
        public void GivenIHaveAlreadyAddedTheTestUserToTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I complete the add user form with the test credentials")]
        public void WhenICompleteTheAddUserFormWithTheTestCredentials()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I complete the add user form without entering any details")]
        public void WhenICompleteTheAddUserFormWithoutEnteringAnyDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I complete the add user form with the details")]
        public void WhenICompleteTheAddUserFormWithTheDetails(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the test email address will exist in the database")]
        public void ThenTheTestEmailAddressWillExistInTheDatabase()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the password will have been hashed")]
        public void ThenThePasswordWillHaveBeenHashed()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will show a message indicating the user has been created")]
        public void ThenTheSiteWillShowAMessageIndicatingTheUserHasBeenCreated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will show me a message indicating that the user already exists")]
        public void ThenTheSiteWillShowMeAMessageIndicatingThatTheUserAlreadyExists()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the test email address will not have been added to the database again")]
        public void ThenTheTestEmailAddressWillNotHaveBeenAddedToTheDatabaseAgain()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will indicate that the email address is required")]
        public void ThenTheSiteWillIndicateThatTheEmailAddressIsRequired()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will indicate that the password is required")]
        public void ThenTheSiteWillIndicateThatThePasswordIsRequired()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will indicate that the email address is not valid")]
        public void ThenTheSiteWillIndicateThatTheEmailAddressIsNotValid()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the site will indicate that the password is not valid")]
        public void ThenTheSiteWillIndicateThatThePasswordIsNotValid()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
