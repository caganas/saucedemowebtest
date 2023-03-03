using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;

namespace TestProjectSauceDemo.utilities
{
    public class Base
    {

        public IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            //Configuration
            String browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.saucedemo.com/";
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            //Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            //driver.Navigate().GoToUrl("https://www.saucedemo.com/");
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
                    break;


            }

        }

        [TearDown]
        public void AfterTest()
        {
            driver.Quit();
        }


    }
}
