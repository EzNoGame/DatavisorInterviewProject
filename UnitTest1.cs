using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestPj;

public class Tests
{
    private IWebDriver _driver;
    [OneTimeSetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://app.bugbug.io/sign-in");
    
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        //login
        var emailField = _driver.FindElement(By.Name("email"));
        var passwordField = _driver.FindElement(By.Name("password"));
        var loginButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div.sc-fTFjTM.chMxjh > form > button"));
    
        emailField.SendKeys("eddie.zhang@mail.mcgill.ca");
        passwordField.SendKeys("Doudou1126!");
        loginButton.Click();
    }

    [Test]
    public void CreateProject()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > button")));

        var newProjectButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > button"));
        newProjectButton.Click();

        var name = _driver.FindElement(By.Name("name"));
        var url = _driver.FindElement(By.Name("homepageUrl"));
        var createProjectButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div.sc-bypJrT.jRa-dIJ.backdrop > div > form > div.sc-hIUJlX.eyypRo > button.sc-tagGq.fxwkFr.sc-fXSgeo.cLzWpS"));
        name.SendKeys("Test Project");
        url.SendKeys("http://www.google.com");
        createProjectButton.Click();

        wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > form")));

        var popup = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > form"));
        Assert.That(popup, Is.Not.EqualTo(null));
    }

    [TearDown]
    public void TearDown()
    {
        // Close the browser
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        // _driver.Quit();
    }
}