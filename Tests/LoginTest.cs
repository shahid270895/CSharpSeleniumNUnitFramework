// using SpecFlowAutomationFramework2026.Base;
// using SpecFlowAutomationFramework2026.Pages;
// using SpecFlowAutomationFramework2026.Utilities;
// using OpenQA.Selenium;

// namespace SpecFlowAutomationFramework2026.Tests;

// [Parallelizable(ParallelScope.All)]
// class LoginTest : BaseTest
// {
//     [Test]
//     [RetryAnalyzer]
//     [Category("Smoke")]
//     [Category("Regression")]
//     public void VerifyValidLogin()
//     {
//         loginPage.OpenApplication();
//         loginPage.WaitForPageTitle("OrangeHRM");
//         Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
//         loginPage.EnterUsername(JsonDataReader.GetValue("ValidLogin", "Username"));
//         loginPage.EnterPassword(JsonDataReader.GetValue("ValidLogin", "Password"));
//         Thread.Sleep(1000);
//         loginPage.ClickLoginButton();
//         Assert.That(dashboardPage.GetDashboardHeader(), Is.EqualTo("Dashboard"));
//         Thread.Sleep(2000);
//     }

//     [Test]
//     [RetryAnalyzer]
//     [Category("Regression")]
//     [Category("Sanity")]
//     public void VerifyInvalidLogin()
//     {
//         loginPage.OpenApplication();
//         Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
//         loginPage.EnterUsername(JsonDataReader.GetValue("InvalidLogin", "Username"));
//         loginPage.EnterPassword(JsonDataReader.GetValue("InvalidLogin", "Password"));
//         loginPage.ClickLoginButton();
//         Thread.Sleep(2000);
//         Assert.That(loginPage.GetErrorText() == "Invalid credentials");
//         Thread.Sleep(2000);
//     }

//     [Test]
//     [RetryAnalyzer]
//     [Category("Smoke")]
//     [Category("Regression")]
//     public void VerifyUserLogout()
//     {
//         loginPage.OpenApplication();
//         Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
//         loginPage.EnterUsername(JsonDataReader.GetValue("ValidLogin", "Username"));
//         loginPage.EnterPassword(JsonDataReader.GetValue("ValidLogin", "Password"));
//         Thread.Sleep(1000);
//         loginPage.ClickLoginButton();
//         Assert.That(dashboardPage.GetDashboardHeader(), Is.EqualTo("Dashboard"));
//         Thread.Sleep(2000);
//         dashboardPage.ClickOnUserProfileDropdownButton();
//         Thread.Sleep(1000);
//         dashboardPage.ClickOnLogoutButton();
//         Thread.Sleep(2000);
//         Assert.That(loginPage.LoginTextDisplayed(), Is.True);
//         Thread.Sleep(1000);
//     }

//     [Test]
//     [RetryAnalyzer]
//     [Category("Sanity")]
//     [Category("Regression")]
//     public void VerifyDashboardSearchOption()
//     {
//         loginPage.OpenApplication();
//         Assert.That(loginPage.GetPageTitle() == "OrangeHRM");
//         loginPage.EnterUsername(JsonDataReader.GetValue("ValidLogin", "Username"));
//         loginPage.EnterPassword(JsonDataReader.GetValue("ValidLogin", "Password"));
//         Thread.Sleep(1000);
//         loginPage.ClickLoginButton();
//         Assert.That(dashboardPage.GetDashboardHeader(), Is.EqualTo("Dashboard"));
//         Thread.Sleep(2000);
//         dashboardPage.EnterTextInSearchField("d");
//         dashboardPage.VerifyFilteredSearchedResult("d");
//         Thread.Sleep(1000);
//     }
// }
