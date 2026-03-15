using TechTalk.SpecFlow;
using NUnit.Framework;
using OrderManagementAutomation.Pages;

namespace OrderManagementAutomation.StepDefinitions
{
    [Binding]
    public class CustomerSteps
    {
        private CustomerPage _customerPage;

        [Given(@"I navigate to the customer page")]
        public void GivenINavigateToTheCustomerPage()
        {
            Hooks.Driver.Navigate().GoToUrl("http://localhost:5000/customers");
            _customerPage = new CustomerPage(Hooks.Driver);
        }

        [When(@"I enter customer id ""(.*)"", name ""(.*)"", and email ""(.*)""")]
        public void WhenIEnterCustomerDetails(string id, string name, string email)
        {
            _customerPage.EnterCustomerId(id);
            _customerPage.EnterName(name);
            _customerPage.EnterEmail(email);
        }

        [When(@"I click the register customer button")]
        public void WhenIClickTheRegisterCustomerButton() => _customerPage.ClickRegister();

        [Then(@"the customer should be registered successfully")]
        public void ThenTheCustomerShouldBeRegisteredSuccessfully()
        {
            Assert.IsTrue(_customerPage.IsSuccessDisplayed());
        }
    }
}
