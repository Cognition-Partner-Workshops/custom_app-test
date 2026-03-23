using TechTalk.SpecFlow;
using NUnit.Framework;
using FlightBookingAutomation.Pages;
using MyAppAutomation;
using MyAppAutomation.Utilities;

namespace FlightBookingAutomation.StepDefinitions
{
    [Binding]
    public class PassengerSteps
    {
        private PassengerPage _passengerPage;

        [Given(@"I navigate to the passenger page")]
        public void GivenINavigateToThePassengerPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/passengers");
            _passengerPage = new PassengerPage(Hooks.Driver);
        }

        [When(@"I enter passenger id ""(.*)"", name ""(.*)"", and email ""(.*)""")]
        public void WhenIEnterPassengerDetails(string id, string name, string email)
        {
            _passengerPage.EnterPassengerId(id);
            _passengerPage.EnterName(name);
            _passengerPage.EnterEmail(email);
        }

        [When(@"I click the register passenger button")]
        public void WhenIClickTheRegisterPassengerButton() => _passengerPage.ClickRegister();

        [Then(@"the passenger should be registered successfully")]
        public void ThenThePassengerShouldBeRegisteredSuccessfully()
        {
            Assert.IsTrue(_passengerPage.IsSuccessDisplayed());
        }

        [Then(@"the passenger registration should fail")]
        public void ThenThePassengerRegistrationShouldFail()
        {
            Assert.IsTrue(_passengerPage.IsErrorDisplayed());
        }

        [Then(@"the passenger list should be displayed")]
        public void ThenThePassengerListShouldBeDisplayed()
        {
            Assert.IsTrue(_passengerPage.IsPassengerListDisplayed());
        }

        [When(@"I search for passenger by id ""(.*)""")]
        public void WhenISearchForPassengerById(string id) => _passengerPage.SearchPassengerById(id);

        [Then(@"the passenger details should be displayed")]
        public void ThenThePassengerDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_passengerPage.IsPassengerDetailsDisplayed());
        }
    }
}
