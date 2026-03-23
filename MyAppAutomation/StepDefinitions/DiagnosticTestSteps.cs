using TechTalk.SpecFlow;
using NUnit.Framework;
using DiagnosticTestAutomation.Pages;
using MyAppAutomation.Utilities;

namespace DiagnosticTestAutomation.StepDefinitions
{
    [Binding]
    public class DiagnosticTestSteps
    {
        private DiagnosticTestPage _testPage;

        [Given(@"I navigate to the diagnostic test page")]
        public void GivenINavigateToTheDiagnosticTestPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/diagnosticTests");
            _testPage = new DiagnosticTestPage(Hooks.Driver);
        }

        [When(@"I enter test id ""(.*)"", test name ""(.*)"", and cost ""(.*)""")]
        public void WhenIEnterTestDetails(string id, string name, string cost)
        {
            _testPage.EnterTestId(id);
            _testPage.EnterTestName(name);
            _testPage.EnterCost(cost);
        }

        [When(@"I click the add test button")]
        public void WhenIClickTheAddTestButton() => _testPage.ClickAddTest();

        [Then(@"the test should be added successfully")]
        public void ThenTheTestShouldBeAddedSuccessfully()
        {
            Assert.IsTrue(_testPage.IsSuccessDisplayed());
        }

        [Then(@"the test addition should fail")]
        public void ThenTheTestAdditionShouldFail()
        {
            Assert.IsTrue(_testPage.IsErrorDisplayed());
        }

        [Then(@"the test list should be displayed")]
        public void ThenTheTestListShouldBeDisplayed()
        {
            Assert.IsTrue(_testPage.IsTestListDisplayed());
        }

        [When(@"I search for test by id ""(.*)""")]
        public void WhenISearchForTestById(string id) => _testPage.SearchTestById(id);

        [Then(@"the test details should be displayed")]
        public void ThenTheTestDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_testPage.IsTestDetailsDisplayed());
        }
    }
}
