using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestPj;

public class Tests
{
    private IWebDriver _driver;
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Navigate().GoToUrl("https://bugbug.io/v2");
    
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

       
    }

    [Test]
    public void Test1()
    {
        var loginButton = _driver.FindElement(By.LinkText("https://app.bugbug.io/sign-in/"));

        Console.WriteLine(loginButton.Text);
        loginButton.Click();
        Assert.Equals(loginButton.Text, "Login");
    }
}