using OpenQA.Selenium;

namespace OrderManagementAutomation.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;
        public ProductPage(IWebDriver driver) => _driver = driver;

        private IWebElement ProductId => _driver.FindElement(By.Id("productId"));
        private IWebElement Name => _driver.FindElement(By.Id("productName"));
        private IWebElement Price => _driver.FindElement(By.Id("productPrice"));
        private IWebElement AddButton => _driver.FindElement(By.Id("addProductBtn"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterProductId(string id) => ProductId.SendKeys(id);
        public void EnterName(string name) => Name.SendKeys(name);
        public void EnterPrice(string price) => Price.SendKeys(price);
        public void ClickAddProduct() => AddButton.Click();

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

        public bool IsProductListDisplayed()
        {
            try { return _driver.FindElement(By.Id("productList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchProductById(string id)
        {
            var searchInput = _driver.FindElement(By.Id("searchProductId"));
            searchInput.Clear();
            searchInput.SendKeys(id);
            _driver.FindElement(By.Id("searchProductBtn")).Click();
        }

        public bool IsProductDetailsDisplayed()
        {
            try { return _driver.FindElement(By.Id("productDetails")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }
    }
}
