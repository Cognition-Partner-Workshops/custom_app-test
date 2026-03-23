using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyAppAutomation.Utilities
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForElement(By locator)
        {
            return Wait.Until(d =>
            {
                var element = d.FindElement(locator);
                return element.Displayed ? element : null;
            });
        }

        protected bool IsElementDisplayed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        protected void ClearAndType(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        protected void NavigateTo(string path)
        {
            Driver.Navigate().GoToUrl($"{AppSettings.BaseUrl}{path}");
        }

        public bool IsSuccessDisplayed()
        {
            return IsElementDisplayed(By.Id("successMsg"));
        }

        public bool IsErrorDisplayed()
        {
            return IsElementDisplayed(By.Id("errorMsg"));
        }

        public string GetSuccessMessage()
        {
            try
            {
                return Driver.FindElement(By.Id("successMsg")).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }

        public string GetErrorMessage()
        {
            try
            {
                return Driver.FindElement(By.Id("errorMsg")).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
