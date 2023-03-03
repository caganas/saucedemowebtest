using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSauceDemo.pageObjects
{
    internal class ProductsPage
    {

        double waitTime = 10;

        private IWebDriver driver;

        public ProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PageObjectFactory
        [FindsBy(How = How.Name, Using = "add-to-cart-sauce-labs-backpack")]
        private IWebElement productOne;
        [FindsBy(How = How.Name, Using = "add-to-cart-sauce-labs-fleece-jacket")]
        private IWebElement productTwo;
        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        private IWebElement shoppingCardLinkButton;


        public void selectProducts()
        {
            productOne.Click();
            productTwo.Click();
            Thread.Sleep(4000);

        }

        public YourCardPage clickShopCardLinkButton()
        {
            shoppingCardLinkButton.Click();
            Thread.Sleep(4000);
            return new YourCardPage(driver);
        }
    
        public void waitForProductPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("inventory_container")));
        }


    }




}
