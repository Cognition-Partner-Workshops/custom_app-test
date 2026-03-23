using TechTalk.SpecFlow;
using NUnit.Framework;
using OrderManagementAutomation.Pages;
using MyAppAutomation.Utilities;

namespace OrderManagementAutomation.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private ProductPage _productPage;

        [Given(@"I navigate to the product page")]
        public void GivenINavigateToTheProductPage()
        {
            Hooks.Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}/products");
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

        [Then(@"the product addition should fail")]
        public void ThenTheProductAdditionShouldFail()
        {
            Assert.IsTrue(_productPage.IsErrorDisplayed());
        }

        [Then(@"the product list should be displayed")]
        public void ThenTheProductListShouldBeDisplayed()
        {
            Assert.IsTrue(_productPage.IsProductListDisplayed());
        }

        [When(@"I search for product by id ""(.*)""")]
        public void WhenISearchForProductById(string id) => _productPage.SearchProductById(id);

        [Then(@"the product details should be displayed")]
        public void ThenTheProductDetailsShouldBeDisplayed()
        {
            Assert.IsTrue(_productPage.IsProductDetailsDisplayed());
        }
    }
}
