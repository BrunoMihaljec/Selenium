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

            WebDriver.driver = new ChromeDriver();

            WebDriver.driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
            WebDriver.driver.Manage().Window.Maximize();
            Console.WriteLine("Opened URL");
        }
    }
}
