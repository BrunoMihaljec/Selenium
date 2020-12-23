using OpenQA.Selenium;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Selenium.PageObjects
{
     static class AddressPageObjects
     {
        private static IWebDriver driver = WebDriver.driver;


        public static IWebElement txtComment = WebDriver.driver.FindElement(By.Name("message"));


        public static IWebElement btnProcedToAddress = WebDriver.driver.FindElement(By.Name("processAddress"));



        public static void AddComment(string comment)
        {
            try
            {
                SeleniumSetMethod.ElementPresent(txtComment);
                SeleniumSetMethod.ElementEnabled(txtComment);
                txtComment.Clear();
                SeleniumSetMethod.ElementEmpty(txtComment);
                SeleniumSetMethod.EnterText(txtComment, comment);

                SeleniumSetMethod.ElementPresent(btnProcedToAddress);
                SeleniumSetMethod.ElementEnabled(btnProcedToAddress);
                SeleniumSetMethod.Clicks(btnProcedToAddress);

                string urlAdress = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 50);
                SeleniumGetMethods.PageLoaded(urlAdress, "order");
                Console.WriteLine("Comment added successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding comment failed: {0}", e);
            }
        }
    }
}
