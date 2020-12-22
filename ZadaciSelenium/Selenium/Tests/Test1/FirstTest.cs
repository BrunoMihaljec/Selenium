using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Web_Driver;
using Selenium.Methods;
using System;
using Selenium.PageObjects;

namespace Selenium.Tests.Test1
{
    public class FirstTest : Setup
    {
        [Test]
        public void ExecuteTest()
        {
            LogInPageObject.LogIn("mihaljecbruno@gmail.com", "LigaLegendi");
            Console.WriteLine("Logged in the page!");

            SearchPageObject.EnterProduct("shirt");            
            Console.WriteLine("Searched page for 'shirt'.");

            ShoppingPageObjects.SelectProduct();
            Console.WriteLine("Going to product page.");

            ProductPageObjects.AddToCart();
            Console.WriteLine("Product bought.");

            ShoppingCartPageObjects.AddQuantity("2");
            Console.WriteLine("Two more shirts added to the cart. ");

            AddressPageObjects.AddComment("Your page is very good.");           
            Console.WriteLine("Commented the page");


            ShippingPageObjects.GoToPayment();
            Console.WriteLine("Executed Test!");

        }

        [TearDown]
        public void CleanUp()
        {
            WebDriver.driver.Close();
            Console.WriteLine("The Browser Closed");

        }

    }
}
