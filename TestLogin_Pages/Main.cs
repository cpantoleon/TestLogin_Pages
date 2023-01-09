using ceTe.DynamicPDF.PageElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using TestLogin_Pages.Pages;
using TestLogin_Pages.Usefull.Func;
using TestLogin_Pages.Usefull_Func;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using ceTe.DynamicPDF.Merger;
using System.IO;
using ceTe.DynamicPDF;
using iTextSharp.text.pdf;
using static iTextSharp.text.pdf.AcroFields;

namespace TestLogin_Pages
{

    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        private LoginPage loginCredentials;
        private LoginPage LoginBtn;

        private HomePage login;
        private HomePage Click;
        private HomePage terms;
        private HomePage NavigateScip;

        private PactPage FilterPact;
        private PactPage Table;
        private PactPage Details;

        private Verify VerifyText;
        private Verify VerifyAccount;
        private Verify VerifyMaterial;

        private ScipPage FilterScip;
        private ScipPage FilterSearch;
        private ScipPage Factsheet;
        private ScipPage Eyebtn;

        //Substance Pact
        private String Substsance = "(+)-N-(3-ethoxypropyl)-2,4-dihydroxy-3,3-dimethylbutyramide";

        //Substance SCIP
        private String ScipSub = "solenoid valve";
        private String ScipPart = "1381455 v1";

        //Verify Text
        private String MyAccountText = "My Account";
        private String Scip_Material_Text = "metal > brass";

        //Export files names
        private String PDF_Login_Name = "Login_Run";
        private String PDF_Execution_Name = "Pact_Execution_Run";
        private String PDF_Scip_Execution_Name = "Scip_Execution_Name";

        //--Validation
        //Create a Table
        private int[] ValNum = new int[] { 0, 0, 0, 0, 0, 0 };

        //private string[] ValString;
        List<string> ValString = new List<string>();
        List<int> ValFinal = new List<int>();

        //Error
        private String ex1 = "Error";

        [TestInitialize]
        public void Setup()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://echa.europa.eu/home");
            //driver.Manage().Window.Maximize();

            login = new HomePage(driver);
            loginCredentials = new LoginPage(driver);
            LoginBtn = new LoginPage(driver);
            Click = new HomePage(driver);
            terms = new HomePage(driver);
            NavigateScip = new HomePage(driver);
            FilterPact = new PactPage(driver);
            Table = new PactPage(driver);
            Details = new PactPage(driver);
            VerifyText = new Verify(driver);
            VerifyAccount = new Verify(driver);
            VerifyMaterial = new Verify(driver);
            FilterScip = new ScipPage(driver);
            FilterSearch = new ScipPage(driver);
            Factsheet = new ScipPage(driver);
            Eyebtn = new ScipPage(driver);

        }

        [TestMethod]
        public void Login()
        {
            try
            {
                ValString.Add("Yes"); // Passed
                login.GoToLogin();

                ValString.Add("Yes"); // Passed
                ThreadSleep.Run(2500);

                loginCredentials.LoginApplication("cpantoleon", "panchris%1");
                ValString.Add("Yes"); // Passed

                LoginBtn.LoginBtn();
                ValString.Add("Yes"); // Passed
                //Console.WriteLine("Success_Login");
                ThreadSleep.Run(3000);

                VerifyAccount.MyAccount(MyAccountText);
                ValString.Add("Yes"); // Passed

                Export.Login("Login to the ECHA Website", PDF_Login_Name, ValNum, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Login_Name + ".pdf");

                /*
                MergeDocument document = MergeDocument.Merge(Util.GetPath("Output/" + PDF_Login_Name + ".pdf"),
    Util.GetPath("Output/" + PDF_Scip_Execution_Name + ".pdf"));

                document.Draw(Util.GetPath("Output/test.pdf"));
                */

                ThreadSleep.Run(4000);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Failed");
                //Console.WriteLine(ex.ToString());

                ex1 = ex.ToString();

                ValString.Add("No");

                while (ValString.Count < 6)
                {
                    ValString.Add("Null");
                }

                String[] str = ValString.ToArray();

                /*
                foreach (var item in str)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.Write("\n\n");
                */

                //Console.WriteLine(ValString.Count);

                for (int i = 0; i < ValString.Count; i++)
                {
                    if (str[i] == "Yes")
                    {
                        ValFinal.Add(0);
                    }
                    else if (str[i] == "No")
                    {
                        ValFinal.Add(1);
                    }
                    else
                    {
                        ValFinal.Add(2);
                    }
                }

                int[] strFinal = ValFinal.ToArray();

                /*
                foreach (var item in strFinal)
                {
                    Console.WriteLine(item.ToString());
                }*/

                Export.Login("Login to the ECHA Website", PDF_Login_Name, strFinal, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Login_Name + ".pdf");

                driver.Quit();
            }
        }

        [TestMethod]
        public void PACT()
        {
            try
            {
                ValString.Add("Yes"); // Passed
                Click.NavigateToPact();
                ValString.Add("Yes"); // Passed
                terms.Terms();
                ThreadSleep.Run(2000);
                FilterPact.FilterCriteria();

                ThreadSleep.Run(2000);
                Table.Substance_Search(Substsance);
                ValString.Add("Yes"); // Passed

                ThreadSleep.Run(2000);
                Details.Results_Table();
                ValString.Add("Yes"); // Passed
                ThreadSleep.Run(2000);

                VerifyText.TextComp(Substsance);
                ValString.Add("Yes"); // Passed

                Export.Pact("From the ECHA homepage, Navigate to the PACT Page", PDF_Execution_Name, ValNum, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Execution_Name + ".pdf");

                ThreadSleep.Run(4000);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Failed");
                Console.WriteLine(ex.ToString());
                ex1 = ex.ToString();

                ValString.Add("No");

                while (ValString.Count < 5)
                {
                    ValString.Add("Null");
                }

                String[] str = ValString.ToArray();

                /*
                foreach (var item in str)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.Write("\n\n");
                */

                //Console.WriteLine(ValString.Count);

                for (int i = 0; i < ValString.Count; i++)
                {
                    if (str[i] == "Yes")
                    {
                        ValFinal.Add(0);
                    }
                    else if (str[i] == "No")
                    {
                        ValFinal.Add(1);
                    }
                    else
                    {
                        ValFinal.Add(2);
                    }
                }

                int[] strFinal = ValFinal.ToArray();

                /*
                foreach (var item in strFinal)
                {
                    Console.WriteLine(item.ToString());
                }*/

                Export.Pact("From the ECHA homepage, Navigate to the PACT Page", PDF_Execution_Name, strFinal, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Execution_Name + ".pdf");
                
                //Console.WriteLine("\n");

                driver.Quit();
            }
        }

        [TestMethod]
        public void SCIP()
        {
            try
            {
                ValString.Add("Yes"); // Passed

                NavigateScip.NavigateToSCIP();
                ThreadSleep.Run(2000);
                ValString.Add("Yes"); // Passed

                terms.Terms();
                ThreadSleep.Run(2000);

                FilterScip.FilterCriteria();
                ;
                ThreadSleep.Run(2000);
                FilterSearch.Results_Table(ScipSub, ScipPart);
                ValString.Add("Yes"); // Passed

                Eyebtn.eyebtn();
                ValString.Add("Yes"); // Passed

                ThreadSleep.Run(2000);
                var tabs = driver.WindowHandles;
                if (tabs.Count > 1)
                {
                    driver.SwitchTo().Window(tabs[1]);
                    //driver.Close();
                    //driver.SwitchTo().Window(tabs[1]);
                }

                Factsheet.factsheet(); 
                ValString.Add("Yes"); // Passed
                ThreadSleep.Run(4000);

                VerifyMaterial.Scip_Factsheet(Scip_Material_Text);
                ValString.Add("Yes"); // Passed

                /*
                foreach (var item in str)
                {
                    Console.WriteLine(item.ToString());
                }*/

                /*
                foreach (var item in ValNum)
                {
                    Console.WriteLine(item.ToString());
                }*/

                //Console.WriteLine(ValString);


                Export.Scip("From the ECHA homepage, Navigate to the SCIP Page", PDF_Scip_Execution_Name, ValNum, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Scip_Execution_Name + ".pdf");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Failed");
                //Console.WriteLine(ex.ToString());

                ex1 = ex.ToString();

                ValString.Add("No");

                while (ValString.Count < 6)
                {
                    ValString.Add("Null");
                }

                String[] str = ValString.ToArray();

                /*
                foreach (var item in str)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.Write("\n\n");
                */

                //Console.WriteLine(ValString.Count);

                for (int i = 0; i < ValString.Count; i++)
                {
                    if (str[i] == "Yes")
                    {
                        ValFinal.Add(0);
                    }
                    else if (str[i] == "No")
                    {
                        ValFinal.Add(1);
                    }
                    else
                    {
                        ValFinal.Add(2);
                    }
                }

                int[] strFinal = ValFinal.ToArray();

                /*
                foreach (var item in strFinal)
                {
                    Console.WriteLine(item.ToString());
                }*/

                Export.Scip("From the ECHA homepage, Navigate to the SCIP Page", PDF_Scip_Execution_Name, strFinal, ex1);
                //Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output\" + PDF_Scip_Execution_Name + ".pdf");

                driver.Quit();
            }
        }

        [TestCleanup] 
        public void Cleanup()
        {
            driver.Quit();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            DirectoryInfo d = new DirectoryInfo(Util.GetPath("Output/"));
            FileInfo[] Files = d.GetFiles("*.pdf"); //Getting pdf files
            string str = "";


            string time = DateTime.Now.ToString("dd-M-yyyy_h.mm_tt");
            Console.WriteLine(time.ToString());

            MergeDocument document = new MergeDocument();

            Page page = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(page);

            document.Draw(Util.GetPath("Draft/draft.pdf"));

            foreach (FileInfo file in Files)
            {
                str = str + ", " + file.Name;
            }

            int count = 0;
            Char panto = ',';

            foreach (var ch in str)
            {
                if (ch == panto)
                    count++;
            }

            foreach (FileInfo file in Files)
            {
                document.Append(Util.GetPath("Output/" + file.Name));
            }

            //Console.WriteLine(count);

            document.Draw(Util.GetPath("Draft/draft.pdf"));
            //MergeDocument document = new MergeDocument(str[0]);

            SelectPage.SelectPages(Util.GetPath("Draft/draft.pdf"), "2-" + (count + 1), Util.GetPath("Final/Final_Export_"+ time.ToString()+".pdf"));
            Process.Start(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Final\Final_Export_" + time.ToString() + ".pdf");

            //Console.WriteLine(str);

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Draft");

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            DirectoryInfo outp = new DirectoryInfo(@"C:\Users\cpantole\source\repos\TestLogin_Pages\TestLogin_Pages\Output");

            foreach (FileInfo file in outp.GetFiles())
            {
                file.Delete();
            }
        }
    }
}

