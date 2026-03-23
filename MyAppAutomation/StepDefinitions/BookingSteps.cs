using TechTalk.SpecFlow;
using NUnit.Framework;
using FlightBookingAutomation.Pages;
using MyAppAutomation;
using MyAppAutomation.Utilities;

namespace FlightBookingAutomation.StepDefinitions
{
    [Binding]
    public class BookingSteps
    {
        private BookingPage _bookingPage;

        [Given(@"I navigate to the booking page")]
        public void GivenINavigateToTheBookingPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/bookings");
            _bookingPage = new BookingPage(Hooks.Driver);
        }

        [When(@"I enter booking id ""(.*)"", passenger id ""(.*)"", and flight id ""(.*)""")]
        public void WhenIEnterBookingDetails(string bookingId, string passengerId, string flightId)
        {
            _bookingPage.EnterBookingId(bookingId);
            _bookingPage.EnterPassengerId(passengerId);
            _bookingPage.EnterFlightId(flightId);
        }

        [When(@"I click the place booking button")]
        public void WhenIClickThePlaceBookingButton() => _bookingPage.ClickPlaceBooking();

        [Then(@"the booking should be placed successfully")]
        public void ThenTheBookingShouldBePlacedSuccessfully()
        {
            Assert.IsTrue(_bookingPage.IsSuccessDisplayed());
        }

        [Then(@"the booking should fail")]
        public void ThenTheBookingShouldFail()
        {
            Assert.IsTrue(_bookingPage.IsErrorDisplayed());
        }

        [Then(@"I should see a no seats available error")]
        public void ThenIShouldSeeANoSeatsAvailableError()
        {
            Assert.IsTrue(_bookingPage.IsNoSeatsErrorDisplayed());
        }

        [Then(@"the booking list should be displayed")]
        public void ThenTheBookingListShouldBeDisplayed()
        {
            Assert.IsTrue(_bookingPage.IsBookingListDisplayed());
        }

        [When(@"I search for booking by id ""(.*)""")]
        public void WhenISearchForBookingById(string id) => _bookingPage.SearchBookingById(id);

        [Then(@"the booking details should be displayed")]
        public void ThenTheBookingDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_bookingPage.IsBookingDetailsDisplayed());
        }
    }
}
