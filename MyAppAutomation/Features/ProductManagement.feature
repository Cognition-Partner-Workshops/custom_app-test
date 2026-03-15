Feature: Product management
  As an admin
  I want to add products
  So that they can be ordered

  Scenario: Add a new product
    Given I navigate to the product page
    When I enter product id "1", name "Laptop", and price "75000"
    And I click the add product button
    Then the product should be added successfully
