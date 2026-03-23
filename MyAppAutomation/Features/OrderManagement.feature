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

  Scenario: Place order without customer id
    Given I navigate to the order page
    When I select customer id ""
    And I add product id "1"
    And I click the place order button
    Then the order should fail

  Scenario: Place order without any products
    Given I navigate to the order page
    When I select customer id "1"
    And I click the place order button
    Then the order should fail

  Scenario: Place order with non-existent customer
    Given I navigate to the order page
    When I select customer id "999"
    And I add product id "1"
    And I click the place order button
    Then the order should fail

  Scenario: Place order with non-existent product
    Given I navigate to the order page
    When I select customer id "1"
    And I add product id "999"
    And I click the place order button
    Then the order should fail

  Scenario: View all orders
    Given I navigate to the order page
    Then the order list should be displayed

  Scenario: Search order by id
    Given I navigate to the order page
    When I search for order by id "1"
    Then the order details should be displayed

  Scenario: Search for non-existent order
    Given I navigate to the order page
    When I search for order by id "999"
    Then the order should fail
