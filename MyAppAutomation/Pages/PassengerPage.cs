using OpenQA.Selenium;

namespace FlightBookingAutomation.Pages
{
    public class PassengerPage
    {
        private readonly IWebDriver _driver;
        public PassengerPage(IWebDriver driver) => _driver = driver;

        private IWebElement PassengerId => _driver.FindElement(By.Id("passengerId"));
        private IWebElement PassengerName => _driver.FindElement(By.Id("passengerName"));
        private IWebElement Email => _driver.FindElement(By.Id("passengerEmail"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("registerPassengerBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterPassengerId(string id) => PassengerId.SendKeys(id);
        public void EnterName(string name) => PassengerName.SendKeys(name);
        public void EnterEmail(string email) => Email.SendKeys(email);
        public void ClickRegister() => RegisterButton.Click();

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

        public bool IsPassengerListDisplayed()
        {
            try { return _driver.FindElement(By.Id("passengerList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchPassengerById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchPassengerId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchPassengerBtn")).Click();
        }

        public bool IsPassengerDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("passengerDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
