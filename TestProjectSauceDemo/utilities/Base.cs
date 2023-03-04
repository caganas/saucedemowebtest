using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectSauceDemo.utilities;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using ICSharpCode.SharpZipLib.Zip;
using System.Data;
using log4net;

namespace TestProjectSauceDemo.utilities
{
    public class Base
    {
        public ILog Log;
        public ExtentReports extent;
        public ExtentTest test;
        String browserName;
        public IWebDriver driver;

        //reporting
        [OneTimeSetUp]
        public void Setup()
        {
            Log = LogManager.GetLogger(GetType());

            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string reportPath = projectDirectory + "//index.html";
            var htmlReporter= new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Username", "Galip Cagan Nasuhoglu");
        }

        [SetUp]
        public void StartBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Configuration
            browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
        }


        public IWebDriver getDriver() { return driver; }

        public void InitBrowser(String browserName)

        {
            switch (browserName)
            {

                case "Firefox":

                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;



                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("-no-sandbox");
                    break;


            }

        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();

        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot"+ time.ToString("h_mm_ss")+".png";
            if(status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenhot(driver,fileName));
                test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
            }
            else if(status==NUnit.Framework.Interfaces.TestStatus.Passed)
            {

            }

            extent.Flush();
            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenhot (IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts=(ITakesScreenshot)driver;
            var screenshot= ts.GetScreenshot().AsBase64EncodedString;
           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }


    }
}
