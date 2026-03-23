using TechTalk.SpecFlow;
using NUnit.Framework;
using FlightBookingAutomation.Pages;
using MyAppAutomation.Utilities;

namespace FlightBookingAutomation.StepDefinitions
{
    [Binding]
    public class FlightSteps
    {
        private FlightPage _flightPage;

        [Given(@"I navigate to the flight page")]
        public void GivenINavigateToTheFlightPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/flights");
            _flightPage = new FlightPage(Hooks.Driver);
        }

        [When(@"I enter flight id ""(.*)"", airline ""(.*)"", source ""(.*)"", destination ""(.*)"", price ""(.*)"", and seats ""(.*)""")]
        public void WhenIEnterFlightDetails(string id, string airline, string source, string destination, string price, string seats)
        {
            _flightPage.EnterFlightId(id);
            _flightPage.EnterAirline(airline);
            _flightPage.EnterSource(source);
            _flightPage.EnterDestination(destination);
            _flightPage.EnterPrice(price);
            _flightPage.EnterSeatsAvailable(seats);
        }

        [When(@"I click the add flight button")]
        public void WhenIClickTheAddFlightButton() => _flightPage.ClickAddFlight();

        [Then(@"the flight should be added successfully")]
        public void ThenTheFlightShouldBeAddedSuccessfully()
        {
            Assert.IsTrue(_flightPage.IsSuccessDisplayed());
        }

        [Then(@"the flight addition should fail")]
        public void ThenTheFlightAdditionShouldFail()
        {
            Assert.IsTrue(_flightPage.IsErrorDisplayed());
        }

        [Then(@"the flight list should be displayed")]
        public void ThenTheFlightListShouldBeDisplayed()
        {
            Assert.IsTrue(_flightPage.IsFlightListDisplayed());
        }

        [When(@"I search for flight by id ""(.*)""")]
        public void WhenISearchForFlightById(string id) => _flightPage.SearchFlightById(id);

        [Then(@"the flight details should be displayed")]
        public void ThenTheFlightDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_flightPage.IsFlightDetailsDisplayed());
        }
    }
}
