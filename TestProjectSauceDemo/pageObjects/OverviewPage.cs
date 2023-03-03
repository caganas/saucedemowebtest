using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace TestProjectSauceDemo.pageObjects
{
    public class OverviewPage
    {
        private IWebDriver driver;
        double waitTime = 10;
        public OverviewPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void waitforOverviewPage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(waitTime));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("checkout_summary_container")));
            
        }

        [FindsBy(How = How.Id, Using = "finish")]
        private IWebElement finishButton;

        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Thank you for your order!')]")]
        private IWebElement orderCompleteMessage;

        public void clickFinishButton()
        {
            finishButton.Click();
            Thread.Sleep(4000);
        }

        public void checkOrderCompletedMessage()
        {
            Thread.Sleep(4000);
            string text = orderCompleteMessage.Text;
            string expectedTitle = "Thank you for your order!";
            StringAssert.Contains(expectedTitle, text);
            TestContext.Progress.WriteLine(text);
        }

    }
}
