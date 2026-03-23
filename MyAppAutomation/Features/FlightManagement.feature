Feature: Flight management
  As an airline administrator
  I want to manage flights
  So that passengers can book travel

  Scenario: Add a new flight
    Given I navigate to the flight page
    When I enter flight id "1", airline "Air India", source "Delhi", destination "Mumbai", price "5000", and seats "150"
    And I click the add flight button
    Then the flight should be added successfully

  Scenario: Add flight with empty airline
    Given I navigate to the flight page
    When I enter flight id "2", airline "", source "Delhi", destination "Mumbai", price "5000", and seats "150"
    And I click the add flight button
    Then the flight addition should fail

  Scenario: Add flight with same source and destination
    Given I navigate to the flight page
    When I enter flight id "3", airline "SpiceJet", source "Delhi", destination "Delhi", price "5000", and seats "150"
    And I click the add flight button
    Then the flight addition should fail

  Scenario: Add flight with negative price
    Given I navigate to the flight page
    When I enter flight id "4", airline "IndiGo", source "Chennai", destination "Kolkata", price "-500", and seats "150"
    And I click the add flight button
    Then the flight addition should fail

  Scenario: Add flight with zero seats
    Given I navigate to the flight page
    When I enter flight id "5", airline "Vistara", source "Hyderabad", destination "Pune", price "3000", and seats "0"
    And I click the add flight button
    Then the flight addition should fail

  Scenario: Add flight with duplicate id
    Given I navigate to the flight page
    When I enter flight id "1", airline "Duplicate", source "A", destination "B", price "1000", and seats "100"
    And I click the add flight button
    Then the flight addition should fail

  Scenario: Add flight with all fields empty
    Given I navigate to the flight page
    When I enter flight id "", airline "", source "", destination "", price "", and seats ""
    And I click the add flight button
    Then the flight addition should fail

  Scenario: View all flights
    Given I navigate to the flight page
    Then the flight list should be displayed

  Scenario: Search flight by id
    Given I navigate to the flight page
    When I search for flight by id "1"
    Then the flight details should be displayed

  Scenario: Search for non-existent flight
    Given I navigate to the flight page
    When I search for flight by id "999"
    Then the flight addition should fail
