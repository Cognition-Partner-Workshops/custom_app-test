using OpenQA.Selenium;

namespace LibraryAppAutomation.Pages
{
    public class BookPage
    {
        private readonly IWebDriver _driver;
        public BookPage(IWebDriver driver) => _driver = driver;

        private IWebElement Title => _driver.FindElement(By.Id("title"));
        private IWebElement Author => _driver.FindElement(By.Id("author"));
        private IWebElement AddButton => _driver.FindElement(By.Id("addBookBtn"));
        private IWebElement BorrowButton(string title) => _driver.FindElement(By.XPath($"//button[@data-title='{title}' and @class='borrow']"));
        private IWebElement ReturnButton(string title) => _driver.FindElement(By.XPath($"//button[@data-title='{title}' and @class='return']"));
        private IWebElement SuccessMessage => _driver.FindElement(By.Id("successMsg"));

        public void EnterTitle(string title) => Title.SendKeys(title);
        public void EnterAuthor(string author) => Author.SendKeys(author);
        public void ClickAddBook() => AddButton.Click();
        public void ClickBorrowBook(string title) => BorrowButton(title).Click();
        public void ClickReturnBook(string title) => ReturnButton(title).Click();

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

        public bool IsBookListDisplayed()
        {
            try { return _driver.FindElement(By.Id("bookList")).Displayed; }
            catch (NoSuchElementException) { return false; }
        }

        public void SearchBook(string title)
        {
            var searchInput = _driver.FindElement(By.Id("searchBook"));
            searchInput.Clear();
            searchInput.SendKeys(title);
            _driver.FindElement(By.Id("searchBookBtn")).Click();
        }
    }
}
