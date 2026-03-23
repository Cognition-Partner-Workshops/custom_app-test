using OpenQA.Selenium;

namespace MyAppAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Username => _driver.FindElement(By.Id("username"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("loginBtn"));
        private IWebElement ErrorMessage => _driver.FindElement(By.Id("errorMsg"));

        public void EnterUsername(string username) => Username.SendKeys(username);
        public void EnterPassword(string password) => Password.SendKeys(password);
        public void ClickLogin() => LoginButton.Click();

        public bool IsErrorDisplayed()
        {
            try { return ErrorMessage.Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public bool IsValidationDisplayed()
        {
            try { return _driver.FindElement(By.Id("validationMsg")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void ClearUsername() => Username.Clear();
        public void ClearPassword() => Password.Clear();
    }
}
