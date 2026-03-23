using TechTalk.SpecFlow;
using NUnit.Framework;
using LibraryAppAutomation.Pages;
using MyAppAutomation.Utilities;

namespace LibraryAppAutomation.StepDefinitions
{
    [Binding]
    public class MemberSteps
    {
        private MemberPage _memberPage;

        [Given(@"I navigate to the member registration page")]
        public void GivenINavigateToTheMemberRegistrationPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/members");
            _memberPage = new MemberPage(Hooks.Driver);
        }

        [When(@"I enter member name ""(.*)"" and ID ""(.*)""")]
        public void WhenIEnterMemberNameAndID(string name, string id)
        {
            _memberPage.EnterName(name);
            _memberPage.EnterMemberId(id);
        }

        [When(@"I click the register button")]
        public void WhenIClickTheRegisterButton() => _memberPage.ClickRegister();

        [Then(@"the member should be registered successfully")]
        public void ThenTheMemberShouldBeRegisteredSuccessfully()
        {
            Assert.IsTrue(_memberPage.IsSuccessDisplayed());
        }

        [Then(@"the member registration should fail")]
        public void ThenTheMemberRegistrationShouldFail()
        {
            Assert.IsTrue(_memberPage.IsErrorDisplayed());
        }

        [When(@"I search for member by id ""(.*)""")]
        public void WhenISearchForMemberById(string id) => _memberPage.SearchMemberById(id);

        [Then(@"the member details should be displayed")]
        public void ThenTheMemberDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_memberPage.IsMemberDetailsDisplayed());
        }
    }
}
