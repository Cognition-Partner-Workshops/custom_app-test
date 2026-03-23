using OpenQA.Selenium;

namespace DiagnosticTestAutomation.Pages
{
    public class ResultPage
    {
        private readonly IWebDriver _driver;
        public ResultPage(IWebDriver driver) => _driver = driver;

        private IWebElement ResultId => _driver.FindElement(By.Id("resultId"));
        private IWebElement PatientId => _driver.FindElement(By.Id("resultPatientId"));
        private IWebElement TestId => _driver.FindElement(By.Id("resultTestId"));
        private IWebElement ResultValue => _driver.FindElement(By.Id("resultValue"));
        private IWebElement AddResultButton => _driver.FindElement(By.Id("addResultBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterResultId(string id) => ResultId.SendKeys(id);
        public void EnterPatientId(string id) => PatientId.SendKeys(id);
        public void EnterTestId(string id) => TestId.SendKeys(id);
        public void EnterResultValue(string value) => ResultValue.SendKeys(value);
        public void ClickAddResult() => AddResultButton.Click();

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

        public bool IsResultListDisplayed()
        {
            try { return _driver.FindElement(By.Id("resultList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchResultsByPatientId(string patientId)
        {
            var searchInput = _driver.FindElement(By.Id("searchResultPatientId"));
            searchInput.Clear();
            searchInput.SendKeys(patientId);
            _driver.FindElement(By.Id("searchResultBtn")).Click();
        }

        public bool IsResultDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("resultDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
