using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium;
using System;
using Selenium.Web_Driver;
using Selenium.Methods;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Selenium.PageObjects
{
    public class LogInPageObject
    {
        private IWebDriver driver;


        public LogInPageObject(IWebDriver _driver) => driver = _driver;


        public IWebElement txtEmailAdress => driver.FindElement(By.Name("email"));


        public IWebElement txtPassword => driver.FindElement(By.Name("passwd"));


        public IWebElement btnSignIn => driver.FindElement(By.Name("SubmitLogin"));


        public void ElementPresent(IWebElement element)
        {
            try
            {
                //Print message if assert pass
                Assert.IsTrue(element.Displayed);
                Console.WriteLine("Element is displayed!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element does not exist: {0}", e);
            }
        }

        public void ElementEmpty(IWebElement element)
        {

            string text = element.GetAttribute("value");

            try
            {
                //Print message if assert pass
                Assert.IsEmpty(text);
                Console.WriteLine("Element is empty!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element is not empty: {0}", e);
            }
        }

        public void ElementEnabled(IWebElement element)
        {
            try
            {
                //Print message if assert pass
                Assert.IsTrue(element.Enabled);
                Console.WriteLine("Element is enabled!");
            }
            catch (Exception e)
            {
                //Printing message if assert is fails
                Console.WriteLine("Element is not enabled: " + e);
            }

        }




        public void LogIn(string emailadress, string password)
        {
            try
            {
                ElementPresent(txtEmailAdress);
                ElementEnabled(txtEmailAdress);
                ElementEmpty(txtEmailAdress);
                txtEmailAdress.Clear();
                SeleniumSetMethod.EnterText(txtEmailAdress, emailadress);

                ElementPresent(txtPassword);
                ElementEnabled(txtPassword);
                ElementEmpty(txtPassword);
                txtPassword.Clear();
                SeleniumSetMethod.EnterText(txtPassword, password);

                ElementPresent(btnSignIn);
                ElementEnabled(btnSignIn);
                SeleniumSetMethod.Submits(btnSignIn);

                string urlSearch = driver.Url;
                SeleniumSetMethod.WaitForPageToLoad(driver, 35);
                SeleniumGetMethods.PageLoaded(urlSearch, "My account - My Store");
                Console.WriteLine("Login successful!");
            }
            catch (Exception e)
            {
                
                Console.WriteLine("LogIn failed: {0}", e);
            }
        }

    }
}
