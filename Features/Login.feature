Feature: Login

As a valid user
I want to login into OrangeHRM
So that I can access the Dashboard

@Smoke
Scenario: Verify successful login

    Given User launches the application
    When User enters username "Admin"
    And User enters password "admin123"
    And User clicks on Login button
    Then User should be navigated to Dashboard page