using OpenQA.Selenium;

namespace MyAppAutomation.Pages
{
    public class UserCreationPage
    {
        private readonly IWebDriver _driver;

        public UserCreationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Name => _driver.FindElement(By.Id("name"));
        private IWebElement Age => _driver.FindElement(By.Id("age"));
        private IWebElement MailID => _driver.FindElement(By.Id("mailID"));
        private IWebElement Occupation => _driver.FindElement(By.Id("occupation"));
        private IWebElement Gender => _driver.FindElement(By.Id("gender"));
        private IWebElement CreateButton => _driver.FindElement(By.Id("createBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterName(string name) => Name.SendKeys(name);
        public void EnterAge(string age) => Age.SendKeys(age);
        public void EnterMailID(string mailID) => MailID.SendKeys(mailID);
        public void EnterOccupation(string occupation) => Occupation.SendKeys(occupation);
        public void SelectGender(string gender) => Gender.SendKeys(gender);
        public void ClickCreate() => CreateButton.Click();

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
    }
}
