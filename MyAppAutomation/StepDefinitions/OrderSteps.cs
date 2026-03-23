using TechTalk.SpecFlow;
using NUnit.Framework;
using OrderManagementAutomation.Pages;
using MyAppAutomation.Utilities;

namespace OrderManagementAutomation.StepDefinitions
{
    [Binding]
    public class OrderSteps
    {
        private OrderPage _orderPage;

        [Given(@"I navigate to the order page")]
        public void GivenINavigateToTheOrderPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/orders");
            _orderPage = new OrderPage(Hooks.Driver);
        }

        [When(@"I select customer id ""(.*)""")]
        public void WhenISelectCustomerId(string id) => _orderPage.EnterCustomerId(id);

        [When(@"I add product id ""(.*)""")]
        public void WhenIAddProductId(string id)
        {
            _orderPage.EnterProductId(id);
            _orderPage.ClickAddProduct();
        }

        [When(@"I click the place order button")]
        public void WhenIClickThePlaceOrderButton() => _orderPage.ClickPlaceOrder();

        [Then(@"the order should be placed successfully")]
        public void ThenTheOrderShouldBePlacedSuccessfully()
        {
            Assert.IsTrue(_orderPage.IsSuccessDisplayed());
        }

        [Then(@"the order should fail")]
        public void ThenTheOrderShouldFail()
        {
            Assert.IsTrue(_orderPage.IsErrorDisplayed());
        }

        [Then(@"the order list should be displayed")]
        public void ThenTheOrderListShouldBeDisplayed()
        {
            Assert.IsTrue(_orderPage.IsOrderListDisplayed());
        }

        [When(@"I search for order by id ""(.*)""")]
        public void WhenISearchForOrderById(string id) => _orderPage.SearchOrderById(id);

        [Then(@"the order details should be displayed")]
        public void ThenTheOrderDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_orderPage.IsOrderDetailsDisplayed());
        }
    }
}
