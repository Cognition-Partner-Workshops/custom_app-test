Feature: Order management
  As a customer
  I want to place orders
  So that I can buy products

  Scenario: Place a new order
    Given I navigate to the order page
    When I select customer id "1"
    And I add product id "1"
    And I add product id "2"
    And I click the place order button
    Then the order should be placed successfully
