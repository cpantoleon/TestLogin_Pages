using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLogin_Pages.Usefull.Func;

namespace TestLogin_Pages.Pages
{
    internal class ScipPage
    {
        private IWebDriver driver;

        public ScipPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement FilterExpand => driver.FindElement(By.Id("searchIcon"));

        private IWebElement ArticlesIdBtn => driver.FindElement(By.XPath("//*[@id=\"articleIdentityPanel\"]/div[1]"));

        private IWebElement Substance => driver.FindElement(By.CssSelector("input[class ='field inputFieldNormalWidth identifier form-control']"));

        private IWebElement addbtn => driver.FindElement(By.ClassName("primaryBTN"));

        private IWebElement partnum => driver.FindElement(By.Id("identifier_1"));

        private IWebElement idtype => driver.FindElement(By.Id("identifierTypesSelect_1"));

        private IWebElement idtype_value => driver.FindElement(By.XPath("//*[@id=\"identifierTypesSelect_1\"]/option[11]"));

        private IWebElement search => driver.FindElement(By.CssSelector("button[class ='btn primaryBTN btn-primary btn-default']"));

        private IWebElement eyeicon => driver.FindElement(By.XPath("//*[@id=\"_diss_scip_portlet_articleTabularResultsSearchContainerSearchContainer\"]/table/tbody/tr[1]/td[5]/a"));

        private IWebElement Tree_1 => driver.FindElement(By.CssSelector("span[title ='Solenoid Valve']"));
        
        private IWebElement Tree_2 => driver.FindElement(By.CssSelector("span[title ='Cover']"));

        private IWebElement Tree_3 => driver.FindElement(By.CssSelector("span[title ='VALVE']"));

        private IWebElement Tree_4 => driver.FindElement(By.CssSelector("span[title ='Lead']"));

        private IWebElement Tree_5 => driver.FindElement(By.ClassName("accordionBtn"));

        public void FilterCriteria()
        {
            ThreadSleep.Run(2000);
            FilterExpand.Click();
        }

        public void Results_Table(string substance, string partnumber)
        {
            ThreadSleep.Run(1500);
            ArticlesIdBtn.Click();
            ThreadSleep.Run(1000);
            Substance.SendKeys(substance);
            ThreadSleep.Run(500);

            addbtn.Click();
            ThreadSleep.Run(500);
            partnum.SendKeys(partnumber);

  
            idtype.Click();
            ThreadSleep.Run(500);
            idtype_value.Click();
            ThreadSleep.Run(500);
            search.Click();

            ThreadSleep.Run(4000);
        }

        public void eyebtn()
        {
            eyeicon.Click();
            ThreadSleep.Run(4000);
        }

        public void factsheet()
        {
            Tree_1.Click();
            ThreadSleep.Run(1000);
            
            Tree_2.Click();
            ThreadSleep.Run(1500);

            Tree_3.Click();
            ThreadSleep.Run(1500);

            Tree_4.Click();
            ThreadSleep.Run(2000);
        }

    }
}
