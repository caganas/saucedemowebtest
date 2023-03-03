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


        [Test]
        public void EndToEndFlow()
        {
          
            LoginPage loginPage = new LoginPage(getDriver());
            ProductsPage productPage= loginPage.validLogin("standard_user", "secret_sauce");
            productPage.waitForProductPage();
            productPage.selectProducts();
            YourCardPage yourCardPage= productPage.clickShopCardLinkButton();
            CheckoutPage checkoutPage=yourCardPage.clickCheckoutButton();
            Thread.Sleep(4000);
            checkoutPage.enterYourInformation("Galip Cagan", "Nasuhoglu", "34840");
            OverviewPage overviewPage=checkoutPage.clickContinueButton();
            overviewPage.waitforOverviewPage();
            overviewPage.clickFinishButton();
            overviewPage.checkOrderCompletedMessage();


        }

       
    }
}