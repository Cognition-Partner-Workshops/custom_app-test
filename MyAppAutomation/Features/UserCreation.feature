Feature: User creation functionality
  As an admin
  I want to create a new user
  So that they can access the system

  Scenario: Create a new user successfully
    Given I navigate to the user creation page
    When I enter name "Alice"
    And I enter age "28"
    And I enter mailID "alice@example.com"
    And I enter occupation "Engineer"
    And I select gender "Female"
    And I click the create button
    Then the user should be created successfully

  Scenario: Create user with empty name
    Given I navigate to the user creation page
    When I enter name ""
    And I enter age "28"
    And I enter mailID "alice@example.com"
    And I enter occupation "Engineer"
    And I select gender "Female"
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with invalid email format
    Given I navigate to the user creation page
    When I enter name "Bob"
    And I enter age "30"
    And I enter mailID "invalid-email"
    And I enter occupation "Designer"
    And I select gender "Male"
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with negative age
    Given I navigate to the user creation page
    When I enter name "Charlie"
    And I enter age "-5"
    And I enter mailID "charlie@example.com"
    And I enter occupation "Teacher"
    And I select gender "Male"
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with zero age
    Given I navigate to the user creation page
    When I enter name "Diana"
    And I enter age "0"
    And I enter mailID "diana@example.com"
    And I enter occupation "Doctor"
    And I select gender "Female"
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with boundary age 150
    Given I navigate to the user creation page
    When I enter name "Elder"
    And I enter age "150"
    And I enter mailID "elder@example.com"
    And I enter occupation "Retired"
    And I select gender "Male"
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with all fields empty
    Given I navigate to the user creation page
    When I enter name ""
    And I enter age ""
    And I enter mailID ""
    And I enter occupation ""
    And I select gender ""
    And I click the create button
    Then the user creation should fail

  Scenario: Create user with duplicate email
    Given I navigate to the user creation page
    When I enter name "Alice Duplicate"
    And I enter age "28"
    And I enter mailID "alice@example.com"
    And I enter occupation "Engineer"
    And I select gender "Female"
    And I click the create button
    Then the user creation should fail
