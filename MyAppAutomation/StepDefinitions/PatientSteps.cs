using TechTalk.SpecFlow;
using NUnit.Framework;
using DiagnosticTestAutomation.Pages;
using MyAppAutomation.Utilities;

namespace DiagnosticTestAutomation.StepDefinitions
{
    [Binding]
    public class PatientSteps
    {
        private PatientPage _patientPage;

        [Given(@"I navigate to the patient page")]
        public void GivenINavigateToThePatientPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/patients");
            _patientPage = new PatientPage(Hooks.Driver);
        }

        [When(@"I enter patient id ""(.*)"", name ""(.*)"", age ""(.*)"", and email ""(.*)""")]
        public void WhenIEnterPatientDetails(string id, string name, string age, string email)
        {
            _patientPage.EnterPatientId(id);
            _patientPage.EnterName(name);
            _patientPage.EnterAge(age);
            _patientPage.EnterEmail(email);
        }

        [When(@"I click the register patient button")]
        public void WhenIClickTheRegisterPatientButton() => _patientPage.ClickRegister();

        [Then(@"the patient should be registered successfully")]
        public void ThenThePatientShouldBeRegisteredSuccessfully()
        {
            Assert.IsTrue(_patientPage.IsSuccessDisplayed());
        }

        [Then(@"the patient registration should fail")]
        public void ThenThePatientRegistrationShouldFail()
        {
            Assert.IsTrue(_patientPage.IsErrorDisplayed());
        }

        [Then(@"the patient list should be displayed")]
        public void ThenThePatientListShouldBeDisplayed()
        {
            Assert.IsTrue(_patientPage.IsPatientListDisplayed());
        }

        [When(@"I search for patient by id ""(.*)""")]
        public void WhenISearchForPatientById(string id) => _patientPage.SearchPatientById(id);

        [Then(@"the patient details should be displayed")]
        public void ThenThePatientDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_patientPage.IsPatientDetailsDisplayed());
        }
    }
}
