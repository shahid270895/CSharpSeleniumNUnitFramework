using OpenQA.Selenium;
using SpecFlowAutomationFramework2026.Utilities;

namespace SpecFlowAutomationFramework2026.Pages;

public class LoginPage : CommonSeleniumAction
{
    public LoginPage(IWebDriver driver)
        : base(driver)
    {
        this.driver = driver;
    }

    private readonly By loginHeaderText = By.XPath("//h5");

    private readonly By usernameField = By.Name("username");

    private readonly By passwordField = By.Name("password");

    private readonly By loginButton = By.XPath("//button");

    private readonly By invalidCredentialMessage = By.XPath("//p[text()='Invalid credentials']");

    private readonly By requiredFieldMessage = By.XPath("//span[text()='Required']");

    public bool LoginTextDisplayed()
    {
        return IsDisplayed(loginHeaderText);
    }

    public void EnterUsername(string username)
    {
        EnterText(usernameField, username);
    }

    public void EnterPassword(string password)
    {
        EnterText(passwordField, password);
    }

    public void ClickLoginButton()
    {
        ClickOnElement(loginButton);
    }

    public string GetInvalidCredentialMessage()
    {
        return GetElementText(invalidCredentialMessage);
    }

    public string GetRequiredFieldMessage()
    {
        return GetElementText(requiredFieldMessage);
    }
}
