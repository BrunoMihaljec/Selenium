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
    static class LogInPageObject
    {

        private static IWebElement txtEmailAdress => WebDriver.driver.FindElement(By.Name("email"));


        public static IWebElement  txtPassword => WebDriver.driver.FindElement(By.Name("passwd"));


        public static IWebElement btnSignIn => WebDriver.driver.FindElement(By.Name("SubmitLogin"));


        public static void LogIn(string emailadress, string password)
        {
            try
            {
                SeleniumSetMethod.ElementPresent(txtEmailAdress);
                SeleniumSetMethod.ElementEnabled(txtEmailAdress);
                SeleniumSetMethod.ElementEmpty(txtEmailAdress);
                txtEmailAdress.Clear();
                SeleniumSetMethod.EnterText(txtEmailAdress, emailadress);

                SeleniumSetMethod.ElementPresent(txtPassword);
                SeleniumSetMethod.ElementEnabled(txtPassword);
                SeleniumSetMethod.ElementEmpty(txtPassword);
                txtPassword.Clear();
                SeleniumSetMethod.EnterText(txtPassword, password);

                SeleniumSetMethod.ElementPresent(btnSignIn);
                SeleniumSetMethod.ElementEnabled(btnSignIn);
                SeleniumSetMethod.Submits(btnSignIn);

                string urlSearch = WebDriver.driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(WebDriver.driver, 35);
                SeleniumGetMethods.PageLoaded(urlSearch, "account");
                Console.WriteLine("Login successful!");
            }
            catch (Exception e)
            {
                
                Console.WriteLine("LogIn failed: {0}", e);
            }
        }

    }
}
