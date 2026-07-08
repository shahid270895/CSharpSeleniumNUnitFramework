using OpenQA.Selenium;
using LearningNUnit2026.Base;

namespace LearningNUnit2026.Pages;

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }

    private By usernameField = By.Name("username");

    private By passwordField = By.Name("password");

    private By loginButton = By.XPath("//button");

    private By errorText = By.XPath("//p[text()='Invalid credentials']");

    public void EnterUsername(string username)
    {
        //driver.FindElement(txtUsername).SendKeys(username);
        EnterText(usernameField, username);
    }

    public void EnterPassword(string password)
    {
        //driver.FindElement(txtPassword).SendKeys(password);
        EnterText(passwordField, password);
    }

    public void ClickLoginButton()
    {
        //driver.FindElement(btnLogin).Click();
        ClickOnElement(loginButton);
    }

    public string GetErrorText()
    {
        string errorTextValue = GetElementText(errorText);
        return errorTextValue;
    }



}