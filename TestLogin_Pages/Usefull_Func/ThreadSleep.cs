using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TestLogin_Pages.Usefull.Func
{
    internal class ThreadSleep
    {
        public static void Run(int Time)
        {
            Thread.Sleep(Time);
        }
    }
}
