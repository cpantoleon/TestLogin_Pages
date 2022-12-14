using OpenQA.Selenium;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestLogin_Pages.Usefull.Func;

namespace TestLogin_Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement Username => driver.FindElement(By.CssSelector("input[id ='j_username']"));

        private IWebElement Password => driver.FindElement(By.CssSelector("input[id ='j_password'"));

        private IWebElement btnlogin => driver.FindElement(By.Id("submit"));


        public void LoginApplication(string username, string password)
        {
            Username.SendKeys(username);
            Password.SendKeys(password);
        }

        public void LoginBtn()
        {
            btnlogin.Click();
        }
    }
}
