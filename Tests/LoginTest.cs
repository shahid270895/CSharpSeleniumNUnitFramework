using LearningNUnit2026.Base;
using LearningNUnit2026.Pages;
using LearningNUnit2026.Utilities;
using OpenQA.Selenium;

namespace LearningNUnit2026.Tests;


[Parallelizable(ParallelScope.All)]
class LoginTest : BaseTest
{
    [Test]
    [RetryAnalyzer]
    public void VerifyValidLogin()
    {
        loginPage.OpenApplication();
        loginPage.WaitForPageTitle("OrangeHRM");
        Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
        //loginPage.EnterUsername("Admin");
        loginPage.EnterUsername(JsonDataReader.GetValue("ValidLogin", "Username"));
        //loginPage.EnterPassword("admin123");
        loginPage.EnterPassword(JsonDataReader.GetValue("ValidLogin", "Password"));
        Thread.Sleep(2000);
        loginPage.ClickLoginButton();
        Thread.Sleep(5000);
    }
    [Test]
    [RetryAnalyzer]
    public void VerifyInvalidLogin()
    {
        loginPage.OpenApplication();
        loginPage.WaitForPageTitle("OrangeHRM");
        Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
        loginPage.EnterUsername(JsonDataReader.GetValue("InvalidLogin", "Username"));
        loginPage.EnterPassword(JsonDataReader.GetValue("InvalidLogin", "Password"));
        loginPage.ClickLoginButton();
        Thread.Sleep(2000);
        Assert.That(loginPage.GetErrorText() == "Invalid credentials");
        Thread.Sleep(2000);
    }

}