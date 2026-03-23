Feature: Test result management
  As a lab technician
  I want to record and manage test results
  So that patients can view their diagnostic outcomes

  Scenario: Add a new test result
    Given I navigate to the result page
    When I enter result id "1", patient id "1", test id "1", and result value "Normal"
    And I click the add result button
    Then the result should be added successfully

  Scenario: Add result with empty result value
    Given I navigate to the result page
    When I enter result id "2", patient id "1", test id "1", and result value ""
    And I click the add result button
    Then the result addition should fail

  Scenario: Add result with non-existent patient
    Given I navigate to the result page
    When I enter result id "3", patient id "999", test id "1", and result value "Normal"
    And I click the add result button
    Then the result addition should fail

  Scenario: Add result with non-existent test
    Given I navigate to the result page
    When I enter result id "4", patient id "1", test id "999", and result value "Normal"
    And I click the add result button
    Then the result addition should fail

  Scenario: Add result with all fields empty
    Given I navigate to the result page
    When I enter result id "", patient id "", test id "", and result value ""
    And I click the add result button
    Then the result addition should fail

  Scenario: View results by patient
    Given I navigate to the result page
    When I search for results by patient id "1"
    Then the result list should be displayed

  Scenario: Search results for non-existent patient
    Given I navigate to the result page
    When I search for results by patient id "999"
    Then the result addition should fail
