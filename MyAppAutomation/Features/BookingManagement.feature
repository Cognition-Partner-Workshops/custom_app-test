Feature: Booking management
  As a passenger
  I want to book flights
  So that I can travel to my destination

  Scenario: Place a new booking
    Given I navigate to the booking page
    When I enter booking id "1", passenger id "1", and flight id "1"
    And I click the place booking button
    Then the booking should be placed successfully

  Scenario: Place booking with non-existent passenger
    Given I navigate to the booking page
    When I enter booking id "2", passenger id "999", and flight id "1"
    And I click the place booking button
    Then the booking should fail

  Scenario: Place booking with non-existent flight
    Given I navigate to the booking page
    When I enter booking id "3", passenger id "1", and flight id "999"
    And I click the place booking button
    Then the booking should fail

  Scenario: Place booking when no seats available
    Given I navigate to the booking page
    When I enter booking id "4", passenger id "1", and flight id "1"
    And I click the place booking button
    Then I should see a no seats available error

  Scenario: Place booking with all fields empty
    Given I navigate to the booking page
    When I enter booking id "", passenger id "", and flight id ""
    And I click the place booking button
    Then the booking should fail

  Scenario: Place booking with duplicate id
    Given I navigate to the booking page
    When I enter booking id "1", passenger id "1", and flight id "1"
    And I click the place booking button
    Then the booking should fail

  Scenario: View all bookings
    Given I navigate to the booking page
    Then the booking list should be displayed

  Scenario: Search booking by id
    Given I navigate to the booking page
    When I search for booking by id "1"
    Then the booking details should be displayed

  Scenario: Search for non-existent booking
    Given I navigate to the booking page
    When I search for booking by id "999"
    Then the booking should fail
