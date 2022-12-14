using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TestLogin_Pages.Usefull.Func;

namespace TestLogin_Pages
{
    class HomePage
    {

        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement btnlogin => driver.FindElement(By.LinkText("Sign In"));

        private IWebElement information => driver.FindElement(By.XPath("//span[text()='Information on Chemicals']"));

        private IWebElement PactBlock => driver.FindElement(By.ClassName("lfr-panel-title-other"));

        private IWebElement PactBtn => driver.FindElement(By.LinkText("PACT - Public Activities Coordination Tool"));

        private IWebElement TermsBtn => driver.FindElement(By.ClassName("lfr-btn-label"));
        
        private IWebElement SCIPBlock => driver.FindElement(By.XPath("//*[@id=\"portlet_com_liferay_journal_content_web_portlet_JournalContentPortlet_INSTANCE_GBJYyg4m5pJo\"]"));

        private IWebElement SCIPBtn => driver.FindElement(By.LinkText("SCIP Database"));
        
        public void GoToLogin()
        {
            btnlogin.SendKeys(Keys.Enter);
        }

        public void NavigateToPact()
        {
            information.Click();
            ThreadSleep.Run(1500);
            PactBlock.Click();
            ThreadSleep.Run(1500);
            PactBtn.Click();
            ThreadSleep.Run(1500);
        }

        public void NavigateToSCIP()
        {
            information.Click();
            ThreadSleep.Run(2000);
            SCIPBlock.Click();
            ThreadSleep.Run(1500);
            SCIPBtn.Click();
            ThreadSleep.Run(1500);
        }
        public void Terms()
        {
            ThreadSleep.Run(1500);
            TermsBtn.Click();
        }
    }
}
