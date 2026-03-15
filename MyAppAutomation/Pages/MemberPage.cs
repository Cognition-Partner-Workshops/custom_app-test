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
        public bool IsSuccessDisplayed() => SuccessMessage.Displayed;
    }
}
