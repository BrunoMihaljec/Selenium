using OpenQA.Selenium;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;

namespace Selenium.PageObjects
{
    static class ShippingPageObjects
    {

        public static IWebElement chcbxIAgree => WebDriver.driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/div/p[2]/div/span"));


        public static IWebElement btnProccedToPayment => WebDriver.driver.FindElement(By.Name("processCarrier"));

        

        public static void GoToPayment()
        {
            try
            {
               
                SeleniumSetMethod.ElementPresent(chcbxIAgree);               
                SeleniumSetMethod.ElementEnabled(chcbxIAgree);
                SeleniumSetMethod.CheckBox(chcbxIAgree);

                SeleniumSetMethod.ElementPresent(btnProccedToPayment);
                SeleniumSetMethod.ElementEnabled(btnProccedToPayment);
                SeleniumSetMethod.Clicks(btnProccedToPayment);

                string urlAdress = WebDriver.driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(WebDriver.driver, 35);
                SeleniumGetMethods.PageLoaded(urlAdress, "shipping");
                Console.WriteLine("Procceded to payment successfully!");
            }
            catch (Exception e)
            {

                Console.WriteLine("Adding Product quantity failed: {0}", e);
            }
        }

        
    }
}
