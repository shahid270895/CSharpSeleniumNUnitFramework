using System.Linq;
using LearningNUnit2026.Base;
using OpenQA.Selenium;

namespace LearningNUnit2026.Pages;

public class DashboardPage : BasePage
{
    public DashboardPage(IWebDriver driver)
        : base(driver)
    {
        this.driver = driver;
    }

    private readonly By dashboardHeaderText = By.XPath("//h6");

    private readonly By userProfileDropdownButton = By.XPath("//p//parent::span//i");

    private readonly By searchField = By.XPath("//input[@placeholder='Search']");

    private readonly By searchResultList = By.XPath("//ul[@class='oxd-main-menu']//li");

    private readonly By logoutButton = By.XPath("//ul//li//a[text()='Logout']");

    public bool DashboardTextDisplayed()
    {
        bool isPresent = IsDisplayed(dashboardHeaderText);
        return isPresent;
    }

    public void ClickOnUserProfileDropdownButton()
    {
        ClickOnElement(userProfileDropdownButton);
    }

    public void ClickOnLogoutButton()
    {
        ClickOnElement(logoutButton);
    }

    public void EnterTextInSearchField(string searchText)
    {
        EnterText(searchField, searchText);
    }

    public void VerifyFilteredSearchedResult(string searchText)
    {
        List<string> values = GetListValues(searchResultList);
        Assert.That(values.Count, Is.GreaterThan(0), "No items are displayed.");
        foreach (string value in values)
        {
            Assert.That(
                value.Contains(searchText, StringComparison.OrdinalIgnoreCase),
                Is.True,
                "Searched item is present."
            );
        }
    }
}
