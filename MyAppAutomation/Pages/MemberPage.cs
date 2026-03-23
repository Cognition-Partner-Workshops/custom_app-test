using OpenQA.Selenium;

namespace LibraryAppAutomation.Pages
{
    public class MemberPage
    {
        private readonly IWebDriver _driver;
        public MemberPage(IWebDriver driver) => _driver = driver;

        private IWebElement Name => _driver.FindElement(By.Id("memberName"));
        private IWebElement MemberId => _driver.FindElement(By.Id("memberId"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("registerBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterName(string name) => Name.SendKeys(name);
        public void EnterMemberId(string id) => MemberId.SendKeys(id);
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

        public void SearchMemberById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchMemberId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchMemberBtn")).Click();
        }

        public bool IsMemberDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("memberDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
