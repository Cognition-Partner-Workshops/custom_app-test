using TechTalk.SpecFlow;
using MyAppAutomation.Pages;
using MyAppAutomation.Utilities;
using NUnit.Framework;

namespace MyAppAutomation.StepDefinitions
{
    [Binding]
    public class UserCreationSteps
    {
        private UserCreationPage _userPage;

        [Given(@"I navigate to the user creation page")]
        public void GivenINavigateToTheUserCreationPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/createUser");
            _userPage = new UserCreationPage(Hooks.Driver);
        }

        [When(@"I enter name ""(.*)""")]
        public void WhenIEnterName(string name) => _userPage.EnterName(name);

        [When(@"I enter age ""(.*)""")]
        public void WhenIEnterAge(string age) => _userPage.EnterAge(age);

        [When(@"I enter mailID ""(.*)""")]
        public void WhenIEnterMailID(string mailID) => _userPage.EnterMailID(mailID);

        [When(@"I enter occupation ""(.*)""")]
        public void WhenIEnterOccupation(string occupation) => _userPage.EnterOccupation(occupation);

        [When(@"I select gender ""(.*)""")]
        public void WhenISelectGender(string gender) => _userPage.SelectGender(gender);

        [When(@"I click the create button")]
        public void WhenIClickTheCreateButton() => _userPage.ClickCreate();

        [Then(@"the user should be created successfully")]
        public void ThenTheUserShouldBeCreatedSuccessfully()
        {
            Assert.IsTrue(_userPage.IsSuccessDisplayed());
        }

        [Then(@"the user creation should fail")]
        public void ThenTheUserCreationShouldFail()
        {
            Assert.IsTrue(_userPage.IsErrorDisplayed());
        }
    }
}
