Feature: Login functionality
  As a registered user
  I want to login to the application
  So that I can access my account

  Scenario: Successful login with valid credentials
    Given I navigate to the login page
    When I enter username "testUser" and password "password123"
    And I click the login button
    Then I should be logged in successfully

  Scenario: Failed login with invalid credentials
    Given I navigate to the login page
    When I enter username "testUser" and password "wrongpass"
    And I click the login button
    Then I should see an error message

  Scenario: Failed login with empty username
    Given I navigate to the login page
    When I enter username "" and password "password123"
    And I click the login button
    Then I should see a validation message

  Scenario: Failed login with empty password
    Given I navigate to the login page
    When I enter username "testUser" and password ""
    And I click the login button
    Then I should see a validation message

  Scenario: Failed login with both fields empty
    Given I navigate to the login page
    When I enter username "" and password ""
    And I click the login button
    Then I should see a validation message

  Scenario: Failed login with non-existent user
    Given I navigate to the login page
    When I enter username "nonExistentUser" and password "password123"
    And I click the login button
    Then I should see an error message

  Scenario: Login with special characters in username
    Given I navigate to the login page
    When I enter username "test@#$%User" and password "password123"
    And I click the login button
    Then I should see an error message

  Scenario: Login with SQL injection attempt
    Given I navigate to the login page
    When I enter username "' OR 1=1 --" and password "password"
    And I click the login button
    Then I should see an error message
