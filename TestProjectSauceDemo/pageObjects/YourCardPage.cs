using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSauceDemo.pageObjects
{
    public class YourCardPage
    {
        private IWebDriver driver;

        public YourCardPage(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "checkout")]
        private IWebElement checkOutButton;

        public CheckoutPage clickCheckoutButton()
        {
            checkOutButton.Click();
            Thread.Sleep(4000);
            return new CheckoutPage(driver);
        }


    }
}
