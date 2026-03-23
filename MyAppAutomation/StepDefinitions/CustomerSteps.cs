using TechTalk.SpecFlow;
using NUnit.Framework;
using OrderManagementAutomation.Pages;
using MyAppAutomation.Utilities;

namespace OrderManagementAutomation.StepDefinitions
{
    [Binding]
    public class CustomerSteps
    {
        private CustomerPage _customerPage;

        [Given(@"I navigate to the customer page")]
        public void GivenINavigateToTheCustomerPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/customers");
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

        [Then(@"the customer registration should fail")]
        public void ThenTheCustomerRegistrationShouldFail()
        {
            Assert.IsTrue(_customerPage.IsErrorDisplayed());
        }

        [Then(@"the customer list should be displayed")]
        public void ThenTheCustomerListShouldBeDisplayed()
        {
            Assert.IsTrue(_customerPage.IsCustomerListDisplayed());
        }

        [When(@"I search for customer by id ""(.*)""")]
        public void WhenISearchForCustomerById(string id) => _customerPage.SearchCustomerById(id);

        [Then(@"the customer details should be displayed")]
        public void ThenTheCustomerDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_customerPage.IsCustomerDetailsDisplayed());
        }
    }
}
