using AventStack.ExtentReports.Model;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using TestProjectSauceDemo.pageObjects;
using TestProjectSauceDemo.utilities;
using WebDriverManager.DriverConfigs.Impl;

namespace TestProjectSauceDemo.tests
{
    public class Tests : Base
    {


        [Test, TestCaseSource("AddTestDataConfig"), Category("Regression")]
        public void EndToEndFlow(string username, string password, string name, string surname, string postcode)
        {
            Log.Info("Username: " + username + "and Surname: " + surname + " will login");
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage = loginPage.validLogin(username, password);
            productPage.waitForProductPage();
            Log.Info("User successfully entired to the web site.");
            Log.Info("Products will be selected");
            productPage.selectProducts();
            Log.Info("Shop card link button will be clicked.");
            YourCardPage yourCardPage = productPage.clickShopCardLinkButton();
            Log.Info("Checkout button will be clicked.");
            CheckoutPage checkoutPage = yourCardPage.clickCheckoutButton();
            Log.Info("User Adress information will be written.");
            checkoutPage.enterYourInformation(name, surname, postcode);
            Log.Info("Contyinue button will be clicked");
            OverviewPage overviewPage = checkoutPage.clickContinueButton();
            Log.Info("Overview page will be opened.");
            overviewPage.waitforOverviewPage();
            Log.Info("Finish button will be clicked.");
            overviewPage.clickFinishButton();
            Log.Info("Order Completed message will be taken.");
            overviewPage.checkOrderCompletedMessage();
            Log.Info("Test is successfull.");

        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("password"), getDataParser().extractData("name"), getDataParser().extractData("surname"), getDataParser().extractData("postcode"));
            yield return new TestCaseData(getDataParser().extractData("performanceglitchuser"), getDataParser().extractData("password"), getDataParser().extractData("name"), getDataParser().extractData("surname"), getDataParser().extractData("postcode"));

        }


    }
}