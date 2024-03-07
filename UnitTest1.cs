using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestPj;

public class Tests
{
    private IWebDriver _driver;
    [SetUp]
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
        String ProjectName = "Test Project";
        //wait for the page to be fully loaded
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        try
        {
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > button"))); 
            var newProjectButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > button"));
            newProjectButton?.Click();
        }
        catch(Exception)
        {
        }
        
        //get textfield and create button
        var name = _driver.FindElement(By.Name("name"));
        var url = _driver.FindElement(By.Name("homepageUrl"));
        var createProjectButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div.sc-bypJrT.jRa-dIJ.backdrop > div > form > div.sc-hIUJlX.eyypRo > button.sc-tagGq.fxwkFr.sc-fXSgeo.cLzWpS"));
        name.SendKeys(ProjectName);
        url.SendKeys("http://www.dummy.com");
        createProjectButton.Click();

        //wait for new page to be loaded
        try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > form > div.sc-hIUJlX.eyypRo > button.sc-tagGq.fxwkFr.sc-fXSgeo.cLzWpS > div > div.sc-kdBSHD.iMxwCe.sc-hknOHE.ffpPwl")));
            var x = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > button"));
            x.Click();
        }
        catch(Exception)
        {
            Assert.Fail(message: "timeout");
        }


        try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > aside > div > div.sc-jRGJub.hwDTTO > div > div")));
            var title = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > aside > div > div.sc-jRGJub.hwDTTO > div > div"));
            Assert.AreEqual(ProjectName,title.Text);//successfully create a preject with expected name
        }
        catch
        {
            Assert.Fail(message: "timeout");
        }
    }

    [Test]
    public void CreateTest()
    {
        //wait for the page to be fully loaded
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
       
        EnterFirstProject();
        IWebElement newTestButton;
        try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-fifgRP.loMJFf > header > div > div.sc-bCosJw.LHlLZ > div > button")));
            newTestButton = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-fifgRP.loMJFf > header > div > div.sc-bCosJw.LHlLZ > div > button"));
            newTestButton.Click();
        }
        catch(Exception)
        {
        }

        Random random = new Random();
        String testName = "Test "+ random.Next();
        var name = _driver.FindElement(By.Name("name"));
        name.SendKeys(testName);
        var create = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > form > div.sc-hIUJlX.eyypRo > button.sc-tagGq.fxwkFr.sc-fXSgeo.cLzWpS"));
        create.Click();

        try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div")));
           _driver.Navigate().Back();
        }
        catch(Exception)
        {
            Assert.Fail(message: "timeout");
        }

       try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-fifgRP.loMJFf > header > div > div.sc-bCosJw.LHlLZ > div > button")));
            var x = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > button"));
            x.Click();
        }
        catch(Exception)
        {
            Assert.Fail(message: "timeout");
        }

        String titleName = "";
        try
        {
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-jiDjCn.dyxyMx > div.sc-cbZHsQ.UhcVs > div > div > div > a:nth-child(1) > div:nth-child(2) > span")));
            var title = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-jiDjCn.dyxyMx > div.sc-cbZHsQ.UhcVs > div > div > div > a:nth-child(1) > div:nth-child(2) > span"));
            titleName = title.Text;
        }
        catch(Exception)
        {
        }

        Assert.AreEqual(titleName, testName);
    }

    //Notice: this test should only be tested after CreateTest is done without an error
    [Test]
    public void DeleteTest()
    {
        CreateTest();
        var option = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > section > div > div > div > div > div.sc-jiDjCn.dyxyMx > div.sc-cbZHsQ.UhcVs > div > div > div > a:nth-child(1) > div:nth-child(4) > div > div:nth-child(2) > div > button"));
        Actions builder = new Actions(_driver);
        builder.MoveToElement(option).Perform();
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(1));
        option.Click();

    }

    [TearDown]
    public void TearDown()
    {
        // _driver.Quit();
    }

    private void EnterFirstProject()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        try
        {
            wait.Until(c => c.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > button"))); 
        }
        catch(Exception)
        {
            Assert.Fail(message: "timeout");
        }
        try
        {
            var project = _driver.FindElement(By.CssSelector("#app > div > div.sc-gytJtb.hDufxA > div > div > div > div.sc-NsUQg.cZERUX > div > a:nth-child(2)"));
            project.Click();
        }
        catch(Exception)
        {
        }
    }
}