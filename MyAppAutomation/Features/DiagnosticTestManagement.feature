Feature: Diagnostic test management
  As a lab administrator
  I want to manage diagnostic tests
  So that patients can be tested for various conditions

  Scenario: Add a new diagnostic test
    Given I navigate to the diagnostic test page
    When I enter test id "1", test name "Blood Test", and cost "500"
    And I click the add test button
    Then the test should be added successfully

  Scenario: Add diagnostic test with empty name
    Given I navigate to the diagnostic test page
    When I enter test id "2", test name "", and cost "300"
    And I click the add test button
    Then the test addition should fail

  Scenario: Add diagnostic test with negative cost
    Given I navigate to the diagnostic test page
    When I enter test id "3", test name "X-Ray", and cost "-100"
    And I click the add test button
    Then the test addition should fail

  Scenario: Add diagnostic test with zero cost
    Given I navigate to the diagnostic test page
    When I enter test id "4", test name "Free Test", and cost "0"
    And I click the add test button
    Then the test addition should fail

  Scenario: Add diagnostic test with duplicate id
    Given I navigate to the diagnostic test page
    When I enter test id "1", test name "Duplicate", and cost "100"
    And I click the add test button
    Then the test addition should fail

  Scenario: Add diagnostic test with all fields empty
    Given I navigate to the diagnostic test page
    When I enter test id "", test name "", and cost ""
    And I click the add test button
    Then the test addition should fail

  Scenario: View all diagnostic tests
    Given I navigate to the diagnostic test page
    Then the test list should be displayed

  Scenario: Search diagnostic test by id
    Given I navigate to the diagnostic test page
    When I search for test by id "1"
    Then the test details should be displayed

  Scenario: Search for non-existent diagnostic test
    Given I navigate to the diagnostic test page
    When I search for test by id "999"
    Then the test addition should fail
