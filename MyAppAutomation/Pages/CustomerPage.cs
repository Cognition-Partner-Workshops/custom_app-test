using OpenQA.Selenium;

namespace OrderManagementAutomation.Pages
{
    public class CustomerPage
    {
        private readonly IWebDriver _driver;
        public CustomerPage(IWebDriver driver) => _driver = driver;

        private IWebElement CustomerId => _driver.FindElement(By.Id("customerId"));
        private IWebElement Name => _driver.FindElement(By.Id("customerName"));
        private IWebElement Email => _driver.FindElement(By.Id("customerEmail"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("registerCustomerBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterCustomerId(string id) => CustomerId.SendKeys(id);
        public void EnterName(string name) => Name.SendKeys(name);
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

        public bool IsCustomerListDisplayed()
        {
            try { return _driver.FindElement(By.Id("customerList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchCustomerById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchCustomerId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchCustomerBtn")).Click();
        }

        public bool IsCustomerDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("customerDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
