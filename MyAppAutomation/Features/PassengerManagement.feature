Feature: Passenger management
  As an airline administrator
  I want to register and manage passengers
  So that they can book flights

  Scenario: Register a new passenger
    Given I navigate to the passenger page
    When I enter passenger id "1", name "Rahul Kumar", and email "rahul@example.com"
    And I click the register passenger button
    Then the passenger should be registered successfully

  Scenario: Register passenger with empty name
    Given I navigate to the passenger page
    When I enter passenger id "2", name "", and email "test@example.com"
    And I click the register passenger button
    Then the passenger registration should fail

  Scenario: Register passenger with invalid email
    Given I navigate to the passenger page
    When I enter passenger id "3", name "Invalid Email", and email "invalid-email"
    And I click the register passenger button
    Then the passenger registration should fail

  Scenario: Register passenger with duplicate id
    Given I navigate to the passenger page
    When I enter passenger id "1", name "Duplicate", and email "dup@example.com"
    And I click the register passenger button
    Then the passenger registration should fail

  Scenario: Register passenger with all fields empty
    Given I navigate to the passenger page
    When I enter passenger id "", name "", and email ""
    And I click the register passenger button
    Then the passenger registration should fail

  Scenario: View all passengers
    Given I navigate to the passenger page
    Then the passenger list should be displayed

  Scenario: Search passenger by id
    Given I navigate to the passenger page
    When I search for passenger by id "1"
    Then the passenger details should be displayed

  Scenario: Search for non-existent passenger
    Given I navigate to the passenger page
    When I search for passenger by id "999"
    Then the passenger registration should fail
