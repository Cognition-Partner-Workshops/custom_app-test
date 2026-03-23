using OpenQA.Selenium;

namespace DiagnosticTestAutomation.Pages
{
    public class PatientPage
    {
        private readonly IWebDriver _driver;
        public PatientPage(IWebDriver driver) => _driver = driver;

        private IWebElement PatientId => _driver.FindElement(By.Id("patientId"));
        private IWebElement PatientName => _driver.FindElement(By.Id("patientName"));
        private IWebElement Age => _driver.FindElement(By.Id("patientAge"));
        private IWebElement Email => _driver.FindElement(By.Id("patientEmail"));
        private IWebElement RegisterButton => _driver.FindElement(By.Id("registerPatientBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterPatientId(string id) => PatientId.SendKeys(id);
        public void EnterName(string name) => PatientName.SendKeys(name);
        public void EnterAge(string age) => Age.SendKeys(age);
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

        public bool IsPatientListDisplayed()
        {
            try { return _driver.FindElement(By.Id("patientList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchPatientById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchPatientId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchPatientBtn")).Click();
        }

        public bool IsPatientDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("patientDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
