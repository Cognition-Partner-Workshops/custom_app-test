Feature: Book management
  As a librarian
  I want to manage books
  So that members can borrow and return them

  Scenario: Add a new book
    Given I navigate to the book management page
    When I enter book title "C# Basics" and author "John Doe"
    And I click the add book button
    Then the book should be added successfully

  Scenario: Borrow a book
    Given I navigate to the book management page
    When I borrow the book "C# Basics"
    Then the book should not be available

  Scenario: Return a book
    Given I navigate to the book management page
    When I return the book "C# Basics"
    Then the book should be available again
