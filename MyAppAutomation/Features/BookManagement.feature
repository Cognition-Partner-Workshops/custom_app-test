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

  Scenario: Add a book with empty title
    Given I navigate to the book management page
    When I enter book title "" and author "John Doe"
    And I click the add book button
    Then I should see a book error message

  Scenario: Add a book with empty author
    Given I navigate to the book management page
    When I enter book title "Test Book" and author ""
    And I click the add book button
    Then I should see a book error message

  Scenario: Add a book with both fields empty
    Given I navigate to the book management page
    When I enter book title "" and author ""
    And I click the add book button
    Then I should see a book error message

  Scenario: Borrow an already borrowed book
    Given I navigate to the book management page
    When I borrow the book "C# Basics"
    Then I should see a book error message

  Scenario: Return a book that is not borrowed
    Given I navigate to the book management page
    When I return the book "C# Basics"
    Then I should see a book error message

  Scenario: View available books list
    Given I navigate to the book management page
    Then the book list should be displayed

  Scenario: Search for a book by title
    Given I navigate to the book management page
    When I search for book "C# Basics"
    Then the book list should be displayed
