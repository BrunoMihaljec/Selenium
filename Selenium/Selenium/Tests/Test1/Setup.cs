using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Web_Driver;
using Selenium.Methods;
using System;

namespace Selenium.Tests.Test1
{   
    public class Setup
    {
        [SetUp]
        public void Initialize()
        {
            WebDriver.driver = new ChromeDriver(@"C:\Users\mihal\OneDrive\Desktop\New folder (2)");           
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriver.driver.Close();
            Console.WriteLine("The Browser Closed");
        }
    }
}
