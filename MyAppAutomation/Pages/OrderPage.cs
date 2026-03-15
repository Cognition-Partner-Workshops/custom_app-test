using OpenQA.Selenium;

namespace OrderManagementAutomation.Pages
{
    public class OrderPage
    {
        private readonly IWebDriver _driver;
        public OrderPage(IWebDriver driver) => _driver = driver;

        private IWebElement CustomerId => _driver.FindElement(By.Id("orderCustomerId"));
        private IWebElement ProductId => _driver.FindElement(By.Id("orderProductId"));
        private IWebElement AddProductButton => _driver.FindElement(By.Id("addProductBtn"));
        private IWebElement PlaceOrderButton => _driver.FindElement(By.Id("placeOrderBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterCustomerId(string id) => CustomerId.SendKeys(id);
        public void EnterProductId(string id) => ProductId.SendKeys(id);
        public void ClickAddProduct() => AddProductButton.Click();
        public void ClickPlaceOrder() => PlaceOrderButton.Click();
        public bool IsSuccessDisplayed() => SuccessMessage.Displayed;
    }
}
