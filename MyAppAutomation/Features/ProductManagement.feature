Feature: Product management
  As an admin
  I want to add products
  So that they can be ordered

  Scenario: Add a new product
    Given I navigate to the product page
    When I enter product id "1", name "Laptop", and price "75000"
    And I click the add product button
    Then the product should be added successfully

  Scenario: Add product with empty name
    Given I navigate to the product page
    When I enter product id "2", name "", and price "500"
    And I click the add product button
    Then the product addition should fail

  Scenario: Add product with negative price
    Given I navigate to the product page
    When I enter product id "3", name "Invalid Product", and price "-100"
    And I click the add product button
    Then the product addition should fail

  Scenario: Add product with zero price
    Given I navigate to the product page
    When I enter product id "4", name "Free Item", and price "0"
    And I click the add product button
    Then the product addition should fail

  Scenario: Add product with duplicate id
    Given I navigate to the product page
    When I enter product id "1", name "Duplicate", and price "100"
    And I click the add product button
    Then the product addition should fail

  Scenario: Add product with all fields empty
    Given I navigate to the product page
    When I enter product id "", name "", and price ""
    And I click the add product button
    Then the product addition should fail

  Scenario: View all products
    Given I navigate to the product page
    Then the product list should be displayed

  Scenario: Search product by id
    Given I navigate to the product page
    When I search for product by id "1"
    Then the product details should be displayed

  Scenario: Search for non-existent product
    Given I navigate to the product page
    When I search for product by id "999"
    Then the product addition should fail
