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
        public bool IsSuccessDisplayed() => SuccessMessage.Displayed;
    }
}
