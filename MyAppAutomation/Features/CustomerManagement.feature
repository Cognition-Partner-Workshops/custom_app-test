Feature: Customer management
  As an admin
  I want to register customers
  So that they can place orders

  Scenario: Register a new customer
    Given I navigate to the customer page
    When I enter customer id "1", name "Shakthi", and email "shakthi@example.com"
    And I click the register customer button
    Then the customer should be registered successfully
