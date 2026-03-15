Feature: Member management
  As a librarian
  I want to register members
  So that they can borrow books

  Scenario: Register a new member
    Given I navigate to the member registration page
    When I enter member name "Alice" and ID "1"
    And I click the register button
    Then the member should be registered successfully
