using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Web_Driver;
using Selenium.Methods;
using System;

namespace Selenium.Tests.Test1
{
    public class TearDown
    {
        [TearDown]

        public void CleanUp()
        {
            WebDriver.driver.Close();
            Console.WriteLine("The Browser Closed");

        }
    }
}
