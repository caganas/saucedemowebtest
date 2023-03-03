using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace TestProjectSauceDemo.pageObjects
{
    internal class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver) 
        {
            this.driver=driver;
            PageFactory.InitElements(driver, this);

        }

        //PageObjectFactory

        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "login-button")]
        private IWebElement loginButton;


        public ProductsPage validLogin(string user,string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            loginButton.Click();
            return new ProductsPage(driver);
        }



        public IWebElement getUserName()
        { return username; }

        public IWebElement getPassword() { return password;}
        public IWebElement getLoginButton() {  return loginButton;} 

    }
}
