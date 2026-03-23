Feature: Customer management
  As an admin
  I want to register customers
  So that they can place orders

  Scenario: Register a new customer
    Given I navigate to the customer page
    When I enter customer id "1", name "Shakthi", and email "shakthi@example.com"
    And I click the register customer button
    Then the customer should be registered successfully

  Scenario: Register customer with empty name
    Given I navigate to the customer page
    When I enter customer id "2", name "", and email "test@example.com"
    And I click the register customer button
    Then the customer registration should fail

  Scenario: Register customer with invalid email
    Given I navigate to the customer page
    When I enter customer id "3", name "Test User", and email "invalid-email"
    And I click the register customer button
    Then the customer registration should fail

  Scenario: Register customer with duplicate id
    Given I navigate to the customer page
    When I enter customer id "1", name "Duplicate", and email "dup@example.com"
    And I click the register customer button
    Then the customer registration should fail

  Scenario: Register customer with all fields empty
    Given I navigate to the customer page
    When I enter customer id "", name "", and email ""
    And I click the register customer button
    Then the customer registration should fail

  Scenario: View all customers
    Given I navigate to the customer page
    Then the customer list should be displayed

  Scenario: Search customer by id
    Given I navigate to the customer page
    When I search for customer by id "1"
    Then the customer details should be displayed

  Scenario: Search for non-existent customer
    Given I navigate to the customer page
    When I search for customer by id "999"
    Then the customer registration should fail
