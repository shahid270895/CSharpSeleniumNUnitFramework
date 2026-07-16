Feature: Login

As a valid user
I want to login into OrangeHRM
So that I can access the Dashboard

@Smoke
Scenario Outline: Verify login with different users

    Given User launches the application
    When User enters "<UserType>" credentials
    And User clicks on Login button
    Then User should see "<ExpectedResult>"
    
Examples:

| UserType    | ExpectedResult |
| ValidUser   | Dashboard      |
| InvalidUser | Invalid Login  |
| BlankUser   | Validation     |