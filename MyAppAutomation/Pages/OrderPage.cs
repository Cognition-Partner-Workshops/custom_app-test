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

        public bool IsOrderListDisplayed()
        {
            try { return _driver.FindElement(By.Id("orderList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchOrderById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchOrderId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchOrderBtn")).Click();
        }

        public bool IsOrderDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("orderDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
