using TechTalk.SpecFlow;
using NUnit.Framework;
using LibraryAppAutomation.Pages;

namespace LibraryAppAutomation.StepDefinitions
{
    [Binding]
    public class MemberSteps
    {
        private MemberPage _memberPage;

        [Given(@"I navigate to the member registration page")]
        public void GivenINavigateToTheMemberRegistrationPage()
        {
            Hooks.Driver.Navigate().GoToUrl("http://localhost:5000/members");
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
    }
}
