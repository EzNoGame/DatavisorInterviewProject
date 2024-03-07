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
        _driver.Navigate().GoToUrl("https://bugbug.io/v2");
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}