Feature: Member management
  As a librarian
  I want to register members
  So that they can borrow books

  Scenario: Register a new member
    Given I navigate to the member registration page
    When I enter member name "Alice" and ID "1"
    And I click the register button
    Then the member should be registered successfully

  Scenario: Register member with empty name
    Given I navigate to the member registration page
    When I enter member name "" and ID "2"
    And I click the register button
    Then the member registration should fail

  Scenario: Register member with empty id
    Given I navigate to the member registration page
    When I enter member name "Bob" and ID ""
    And I click the register button
    Then the member registration should fail

  Scenario: Register member with duplicate id
    Given I navigate to the member registration page
    When I enter member name "Charlie" and ID "1"
    And I click the register button
    Then the member registration should fail

  Scenario: Register member with all fields empty
    Given I navigate to the member registration page
    When I enter member name "" and ID ""
    And I click the register button
    Then the member registration should fail

  Scenario: Search member by id
    Given I navigate to the member registration page
    When I search for member by id "1"
    Then the member details should be displayed

  Scenario: Search for non-existent member
    Given I navigate to the member registration page
    When I search for member by id "999"
    Then the member registration should fail
