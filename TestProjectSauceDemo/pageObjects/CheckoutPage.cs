using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSauceDemo.pageObjects
{
    public class CheckoutPage
    {


        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "first-name")]
        private IWebElement firstName;
        [FindsBy(How = How.Id, Using = "last-name")]
        private IWebElement lastName;
        [FindsBy(How = How.Id, Using = "postal-code")]
        private IWebElement postalCode;
        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement continueButton;


        public void enterYourInformation(string name, string surname,string address)    
        {
            firstName.SendKeys(name);
            lastName.SendKeys(surname);
            postalCode.SendKeys(address);
        }

        public OverviewPage clickContinueButton() 
        {
        continueButton.Click();
            Thread.Sleep(4000);
            return new OverviewPage (driver);
        }





    }
}
