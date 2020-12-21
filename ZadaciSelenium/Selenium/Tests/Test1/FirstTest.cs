using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Web_Driver;
using Selenium.Methods;
using System;
using Selenium.PageObjects;

namespace Selenium.Tests.Test1
{
    public class FirstTest
    {
        [Test]

        public void ExecuteTest()
        {
            LogInPageObject pagelogin = new LogInPageObject(WebDriver.driver);
            pagelogin.LogIn("mihaljecbruno@gmail.com", "LigaLegendi");
            Console.WriteLine("Logged in the page!");

            SearchPageObject pageSearch = new SearchPageObject(WebDriver.driver);
            pageSearch.EnterProduct("shirt");
            Console.WriteLine("Searched page for 'shirt'.");

            ShoppingPageObjects pageShopping = new ShoppingPageObjects(WebDriver.driver);
            pageShopping.SortAndSelectProduct("In stock");
            Console.WriteLine("Sorted by 'in stock' and going to product page.");

            ProductPageObjects pageProduct = new ProductPageObjects(WebDriver.driver);
            pageProduct.AddToCart();
            Console.WriteLine("Product bought.");

            ShoppingCartPageObjects pageShoppingCart = new ShoppingCartPageObjects(WebDriver.driver);
            pageShoppingCart.AddQuantity("2");
            Console.WriteLine("Two more shirts added to the cart. ");

            AddressPageObjects pageAdress = new AddressPageObjects(WebDriver.driver);
            pageAdress.AddComment("Your page is very good.");
            Console.WriteLine("Commented the page");


            ShippingPageObjects pageShipping = new ShippingPageObjects(WebDriver.driver);
            pageShipping.GoToPayment();
            Console.WriteLine("Executed Test!");

        }

    }
}
