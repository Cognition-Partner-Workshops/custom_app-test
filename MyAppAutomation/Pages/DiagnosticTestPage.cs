using OpenQA.Selenium;

namespace DiagnosticTestAutomation.Pages
{
    public class DiagnosticTestPage
    {
        private readonly IWebDriver _driver;
        public DiagnosticTestPage(IWebDriver driver) => _driver = driver;

        private IWebElement TestId => _driver.FindElement(By.Id("testId"));
        private IWebElement TestName => _driver.FindElement(By.Id("testName"));
        private IWebElement Cost => _driver.FindElement(By.Id("testCost"));
        private IWebElement AddTestButton => _driver.FindElement(By.Id("addTestBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterTestId(string id) => TestId.SendKeys(id);
        public void EnterTestName(string name) => TestName.SendKeys(name);
        public void EnterCost(string cost) => Cost.SendKeys(cost);
        public void ClickAddTest() => AddTestButton.Click();

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

        public bool IsTestListDisplayed()
        {
            try { return _driver.FindElement(By.Id("testList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchTestById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchTestId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchTestBtn")).Click();
        }

        public bool IsTestDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("testDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
