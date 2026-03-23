using OpenQA.Selenium;

namespace FlightBookingAutomation.Pages
{
    public class FlightPage
    {
        private readonly IWebDriver _driver;
        public FlightPage(IWebDriver driver) => _driver = driver;

        private IWebElement FlightId => _driver.FindElement(By.Id("flightId"));
        private IWebElement Airline => _driver.FindElement(By.Id("airline"));
        private IWebElement Source => _driver.FindElement(By.Id("source"));
        private IWebElement Destination => _driver.FindElement(By.Id("destination"));
        private IWebElement Price => _driver.FindElement(By.Id("flightPrice"));
        private IWebElement SeatsAvailable => _driver.FindElement(By.Id("seatsAvailable"));
        private IWebElement AddFlightButton => _driver.FindElement(By.Id("addFlightBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterFlightId(string id) => FlightId.SendKeys(id);
        public void EnterAirline(string airline) => Airline.SendKeys(airline);
        public void EnterSource(string source) => Source.SendKeys(source);
        public void EnterDestination(string destination) => Destination.SendKeys(destination);
        public void EnterPrice(string price) => Price.SendKeys(price);
        public void EnterSeatsAvailable(string seats) => SeatsAvailable.SendKeys(seats);
        public void ClickAddFlight() => AddFlightButton.Click();

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

        public bool IsFlightListDisplayed()
        {
            try { return _driver.FindElement(By.Id("flightList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchFlightById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchFlightId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchFlightBtn")).Click();
        }

        public bool IsFlightDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("flightDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
