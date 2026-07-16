using SpecFlowAutomationFramework2026.Pages;
using SpecFlowAutomationFramework2026.Utilities;
using TechTalk.SpecFlow;

namespace SpecFlowAutomationFramework2026.StepDefinitions;

[Binding]
public class LoginSteps
{
    private readonly LoginPage loginPage;
    private readonly DashboardPage dashboardPage;

    public LoginSteps()
    {
        loginPage = new LoginPage(DriverFactory.Driver);
        dashboardPage = new DashboardPage(DriverFactory.Driver);
    }

    [Given(@"User launches the application")]
    public void GivenUserLaunchesTheApplication()
    {
        loginPage.OpenApplication();
    }

    [When(@"User enters ""(.*)"" credentials")]
    public void WhenUserEntersCredentials(string userType)
    {
        string username = JsonDataReader.GetValue(userType, "Username");
        string password = JsonDataReader.GetValue(userType, "Password");

        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
    }

    [When(@"User clicks on Login button")]
    public void WhenUserClicksOnLoginButton()
    {
        loginPage.ClickLoginButton();
    }

    [Then(@"User should see ""(.*)""")]
    public void ThenUserShouldSee(string expectedResult)
    {
        switch (expectedResult)
        {
            case "Dashboard":

                Assert.That(dashboardPage.GetDashboardHeader(), Is.EqualTo("Dashboard"));

                break;

            case "Invalid Login":

                Assert.That(
                    loginPage.GetInvalidCredentialMessage(),
                    Is.EqualTo("Invalid credentials")
                );

                break;

            case "Validation":

                Assert.That(loginPage.GetRequiredFieldMessage(), Is.EqualTo("Required"));

                break;

            default:

                Assert.Fail($"Unknown Expected Result : {expectedResult}");

                break;
        }
    }
}
