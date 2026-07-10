using SpecFlowAutomationFramework2026.Pages;
using SpecFlowAutomationFramework2026.Utilities;
using NUnit.Framework;
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

    [When(@"User enters username ""(.*)""")]
    public void WhenUserEntersUsername(string username)
    {
        loginPage.EnterUsername(username);
    }

    [When(@"User enters password ""(.*)""")]
    public void WhenUserEntersPassword(string password)
    {
        loginPage.EnterPassword(password);
    }

    [When(@"User clicks on Login button")]
    public void WhenUserClicksOnLoginButton()
    {
        loginPage.ClickLoginButton();
    }

    [Then(@"User should be navigated to Dashboard page")]
    public void ThenUserShouldBeNavigatedToDashboardPage()
    {
        Assert.That(dashboardPage.GetDashboardHeader(), Is.EqualTo("Dashboard"));
    }
}
