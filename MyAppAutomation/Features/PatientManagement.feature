Feature: Patient management
  As a lab administrator
  I want to register and manage patients
  So that their diagnostic tests can be tracked

  Scenario: Register a new patient
    Given I navigate to the patient page
    When I enter patient id "1", name "John Smith", age "35", and email "john@example.com"
    And I click the register patient button
    Then the patient should be registered successfully

  Scenario: Register patient with empty name
    Given I navigate to the patient page
    When I enter patient id "2", name "", age "30", and email "test@example.com"
    And I click the register patient button
    Then the patient registration should fail

  Scenario: Register patient with invalid email
    Given I navigate to the patient page
    When I enter patient id "3", name "Jane Doe", age "28", and email "invalid-email"
    And I click the register patient button
    Then the patient registration should fail

  Scenario: Register patient with negative age
    Given I navigate to the patient page
    When I enter patient id "4", name "Invalid Patient", age "-5", and email "neg@example.com"
    And I click the register patient button
    Then the patient registration should fail

  Scenario: Register patient with zero age
    Given I navigate to the patient page
    When I enter patient id "5", name "Baby", age "0", and email "baby@example.com"
    And I click the register patient button
    Then the patient registration should fail

  Scenario: Register patient with duplicate id
    Given I navigate to the patient page
    When I enter patient id "1", name "Duplicate", age "40", and email "dup@example.com"
    And I click the register patient button
    Then the patient registration should fail

  Scenario: Register patient with all fields empty
    Given I navigate to the patient page
    When I enter patient id "", name "", age "", and email ""
    And I click the register patient button
    Then the patient registration should fail

  Scenario: View all patients
    Given I navigate to the patient page
    Then the patient list should be displayed

  Scenario: Search patient by id
    Given I navigate to the patient page
    When I search for patient by id "1"
    Then the patient details should be displayed

  Scenario: Search for non-existent patient
    Given I navigate to the patient page
    When I search for patient by id "999"
    Then the patient registration should fail
