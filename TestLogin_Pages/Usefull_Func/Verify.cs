using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLogin_Pages.Usefull_Func
{
    internal class Verify
    {

        private IWebDriver driver;

        public Verify(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement VerifyText => driver.FindElement(By.CssSelector("h4[class ='substanceNameDetails'"));

        private IWebElement Verifylogin => driver.FindElement(By.CssSelector("a[id ='communityMyAccountURL'"));

        private IWebElement Material => driver.FindElement(By.XPath("//*[@id=\"factSheetDetails\"]/div/div/div[2]/ol/li[1]"));

        public void TextComp(String Sub)
        {
           Assert.IsTrue(VerifyText.Text.Equals(Sub));
        }

        public void MyAccount(String Text)
        {
            Assert.IsTrue(Verifylogin.Text.Equals(Text));
        }

        public void Scip_Factsheet(String Text)
        {
            Assert.IsTrue(Material.Text.Equals(Text));
        }
    }
}
