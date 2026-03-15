using TechTalk.SpecFlow;
using NUnit.Framework;
using OrderManagementAutomation.Pages;

namespace OrderManagementAutomation.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private ProductPage _productPage;

        [Given(@"I navigate to the product page")]
        public void GivenINavigateToTheProductPage()
        {
            Hooks.Driver.Navigate().GoToUrl("http://localhost:5000/products");
            _productPage = new ProductPage(Hooks.Driver);
        }

        [When(@"I enter product id ""(.*)"", name ""(.*)"", and price ""(.*)""")]
        public void WhenIEnterProductDetails(string id, string name, string price)
        {
            _productPage.EnterProductId(id);
            _productPage.EnterName(name);
            _productPage.EnterPrice(price);
        }

        [When(@"I click the add product button")]
        public void WhenIClickTheAddProductButton() => _productPage.ClickAddProduct();

        [Then(@"the product should be added successfully")]
        public void ThenTheProductShouldBeAddedSuccessfully()
        {
            Assert.IsTrue(_productPage.IsSuccessDisplayed());
        }
    }
}
