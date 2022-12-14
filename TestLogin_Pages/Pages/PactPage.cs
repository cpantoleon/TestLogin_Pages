using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestLogin_Pages.Usefull.Func;

namespace TestLogin_Pages.Pages
{
    class PactPage
    {
        private IWebDriver driver;

        public PactPage(IWebDriver browser)
        {
            driver = browser;
        }
      
        private IWebElement FilterExpand => driver.FindElement(By.ClassName("title-text"));

        //private IWebElement DetailsBtn => driver.FindElement(By.XPath("//*[@id=\"_disspact_WAR_disspactportlet_dislistOverviewSearchResultVOsSearchContainerSearchContainer\"]/table/tbody/tr[1]/td[13]/a"));

        private IWebElement DetailsBtn => driver.FindElement(By.ClassName("details"));

        private IWebElement Substance => driver.FindElement(By.CssSelector("input[id ='_disspact_WAR_disspactportlet_substance_identifier_field_key']"));

        private IWebElement FilterBtn => driver.FindElement(By.Id("_disspact_WAR_disspactportlet_searchButton"));

        public void FilterCriteria()
        {
            ThreadSleep.Run(1500);
            FilterExpand.Click();
        }

        public void Substance_Search(string substance)
        {
            ThreadSleep.Run(1500);
            Substance.SendKeys(substance);
            ThreadSleep.Run(1500);
            FilterBtn.Click();
        }

        public void Results_Table()
        {
            ThreadSleep.Run(1500);
            DetailsBtn.Click();
        }
    }
}
