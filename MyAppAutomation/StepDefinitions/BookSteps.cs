using TechTalk.SpecFlow;
using NUnit.Framework;
using LibraryAppAutomation.Pages;

namespace LibraryAppAutomation.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        private BookPage _bookPage;

        [Given(@"I navigate to the book management page")]
        public void GivenINavigateToTheBookManagementPage()
        {
            Hooks.Driver.Navigate().GoToUrl("http://localhost:5000/books");
            _bookPage = new BookPage(Hooks.Driver);
        }

        [When(@"I enter book title ""(.*)"" and author ""(.*)""")]
        public void WhenIEnterBookTitleAndAuthor(string title, string author)
        {
            _bookPage.EnterTitle(title);
            _bookPage.EnterAuthor(author);
        }

        [When(@"I click the add book button")]
        public void WhenIClickTheAddBookButton() => _bookPage.ClickAddBook();

        [Then(@"the book should be added successfully")]
        public void ThenTheBookShouldBeAddedSuccessfully()
        {
            Assert.IsTrue(_bookPage.IsSuccessDisplayed());
        }

        [When(@"I borrow the book ""(.*)""")]
        public void WhenIBorrowTheBook(string title) => _bookPage.ClickBorrowBook(title);

        [Then(@"the book should not be available")]
        public void ThenTheBookShouldNotBeAvailable()
        {
            Assert.IsFalse(_bookPage.IsSuccessDisplayed()); // Example check
        }

        [When(@"I return the book ""(.*)""")]
        public void WhenIReturnTheBook(string title) => _bookPage.ClickReturnBook(title);

        [Then(@"the book should be available again")]
        public void ThenTheBookShouldBeAvailableAgain()
        {
            Assert.IsTrue(_bookPage.IsSuccessDisplayed());
        }
    }
}
