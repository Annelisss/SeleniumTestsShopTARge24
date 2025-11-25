using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class CocktailsSearchTests : BaseTest
    {
        [TestMethod]
        public void CanSearchValidCocktail()
        {
            driver.Navigate().GoToUrl(BaseUrl);


            driver.FindElement(By.LinkText("Cocktails")).Click();

   
            var searchBox = driver.FindElement(By.Id("SearchCocktail"));
            searchBox.Clear();
            searchBox.SendKeys("Martini");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var searchButton = wait.Until(d =>
                d.FindElement(By.CssSelector("button[type='submit'], input[type='submit']")));
            searchButton.Click();


            StringAssert.Contains(driver.Url, "/Cocktails");


            var bodyText = driver.FindElement(By.TagName("body")).Text;
            StringAssert.Contains(bodyText, "Martini");
        }

        [TestMethod]
        public void CannotSearchInvalidCocktail()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.LinkText("Cocktails")).Click();

            var searchBox = driver.FindElement(By.Id("SearchCocktail"));
            searchBox.Clear();
            searchBox.SendKeys("EiOleSellistKokteili123");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var searchButton = wait.Until(d =>
                d.FindElement(By.CssSelector("button[type='submit'], input[type='submit']")));
            searchButton.Click();

 
            StringAssert.Contains(driver.Url, "/Cocktails");


            var bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.IsFalse(bodyText.Contains("EiOleSellistKokteili123"));
        }
    }
}
