using LearningNUnit2026.Base;
using OpenQA.Selenium;

namespace LearningNUnit2026.Pages;

public class LoginPage : BasePage
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

    private readonly By errorText = By.XPath("//p[text()='Invalid credentials']");

    public bool LoginTextDisplayed()
    {
        bool isPresent = IsDisplayed(loginHeaderText);
        return isPresent;
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

    public string GetErrorText()
    {
        string errorTextValue = GetElementText(errorText);
        return errorTextValue;
    }
}
