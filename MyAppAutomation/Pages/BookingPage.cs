using OpenQA.Selenium;

namespace FlightBookingAutomation.Pages
{
    public class BookingPage
    {
        private readonly IWebDriver _driver;
        public BookingPage(IWebDriver driver) => _driver = driver;

        private IWebElement BookingId => _driver.FindElement(By.Id("bookingId"));
        private IWebElement PassengerId => _driver.FindElement(By.Id("bookingPassengerId"));
        private IWebElement FlightId => _driver.FindElement(By.Id("bookingFlightId"));
        private IWebElement PlaceBookingButton => _driver.FindElement(By.Id("placeBookingBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterBookingId(string id) => BookingId.SendKeys(id);
        public void EnterPassengerId(string id) => PassengerId.SendKeys(id);
        public void EnterFlightId(string id) => FlightId.SendKeys(id);
        public void ClickPlaceBooking() => PlaceBookingButton.Click();

        public bool IsSuccessDisplayed()
        {
            try { return SuccessMessage.Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public bool IsErrorDisplayed()
        {
            try { return _driver.FindElement(By.Id("errorMsg")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public bool IsBookingListDisplayed()
        {
            try { return _driver.FindElement(By.Id("bookingList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchBookingById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchBookingId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchBookingBtn")).Click();
        }

        public bool IsBookingDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("bookingDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public bool IsNoSeatsErrorDisplayed()
        {
            try { return _driver.FindElement(By.Id("noSeatsError")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
