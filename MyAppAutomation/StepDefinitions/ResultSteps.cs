using TechTalk.SpecFlow;
using NUnit.Framework;
using DiagnosticTestAutomation.Pages;
using MyAppAutomation.Utilities;

namespace DiagnosticTestAutomation.StepDefinitions
{
    [Binding]
    public class ResultSteps
    {
        private ResultPage _resultPage;

        [Given(@"I navigate to the result page")]
        public void GivenINavigateToTheResultPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/results");
            _resultPage = new ResultPage(Hooks.Driver);
        }

        [When(@"I enter result id ""(.*)"", patient id ""(.*)"", test id ""(.*)"", and result value ""(.*)""")]
        public void WhenIEnterResultDetails(string resultId, string patientId, string testId, string resultValue)
        {
            _resultPage.EnterResultId(resultId);
            _resultPage.EnterPatientId(patientId);
            _resultPage.EnterTestId(testId);
            _resultPage.EnterResultValue(resultValue);
        }

        [When(@"I click the add result button")]
        public void WhenIClickTheAddResultButton() => _resultPage.ClickAddResult();

        [Then(@"the result should be added successfully")]
        public void ThenTheResultShouldBeAddedSuccessfully()
        {
            Assert.IsTrue(_resultPage.IsSuccessDisplayed());
        }

        [Then(@"the result addition should fail")]
        public void ThenTheResultAdditionShouldFail()
        {
            Assert.IsTrue(_resultPage.IsErrorDisplayed());
        }

        [Then(@"the result list should be displayed")]
        public void ThenTheResultListShouldBeDisplayed()
        {
            Assert.IsTrue(_resultPage.IsResultListDisplayed());
        }

        [When(@"I search for results by patient id ""(.*)""")]
        public void WhenISearchForResultsByPatientId(string patientId) => _resultPage.SearchResultsByPatientId(patientId);

        [Then(@"the result details should be displayed")]
        public void ThenTheResultDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_resultPage.IsResultDetailsDisplayed());
        }
    }
}
