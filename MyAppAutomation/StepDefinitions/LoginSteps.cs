using TechTalk.SpecFlow;
using MyAppAutomation.Pages;
using MyAppAutomation.Utilities;
using NUnit.Framework;

namespace MyAppAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage _loginPage;

        [Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/login");
            _loginPage = new LoginPage(Hooks.Driver);
        }

        [When(@"I enter username ""(.*)"" and password ""(.*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLogin();
        }

        [Then(@"I should be logged in successfully")]
        public void ThenIShouldBeLoggedInSuccessfully()
        {
            Assert.IsFalse(_loginPage.IsErrorDisplayed());
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            Assert.IsTrue(_loginPage.IsErrorDisplayed());
        }

        [Then(@"I should see a validation message")]
        public void ThenIShouldSeeAValidationMessage()
        {
            Assert.IsTrue(_loginPage.IsValidationDisplayed());
        }
    }
}
