using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using TestProjectSauceDemo.pageObjects;
using TestProjectSauceDemo.utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectSauceDemo.tests
{
    public class Tests : Base
    {


        [Test, TestCaseSource("AddTestDataConfig")]
        public void EndToEndFlow(string username, string password, string name, string surname, string postcode)
        {
          
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage= loginPage.validLogin(username,password);
            productPage.waitForProductPage();
            productPage.selectProducts();
            YourCardPage yourCardPage= productPage.clickShopCardLinkButton();
            CheckoutPage checkoutPage=yourCardPage.clickCheckoutButton();
            Thread.Sleep(4000);
            checkoutPage.enterYourInformation(name, surname, postcode);
            OverviewPage overviewPage=checkoutPage.clickContinueButton();
            overviewPage.waitforOverviewPage();
            overviewPage.clickFinishButton();
            overviewPage.checkOrderCompletedMessage();


        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username") , getDataParser().extractData("password"), getDataParser().extractData("name"), getDataParser().extractData("surname"), getDataParser().extractData("postcode"));
            yield return new TestCaseData(getDataParser().extractData("performanceglitchuser"), getDataParser().extractData("password"), getDataParser().extractData("name"), getDataParser().extractData("surname"), getDataParser().extractData("postcode"));

        }


    }
}