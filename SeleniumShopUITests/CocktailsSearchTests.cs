using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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


            searchBox.SendKeys(Keys.Enter);


            StringAssert.Contains(driver.Url, "/Cocktails");
        }

        [TestMethod]
        public void CanSearchInvalidCocktailAndStayOnPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.LinkText("Cocktails")).Click();

            var searchBox = driver.FindElement(By.Id("SearchCocktail"));
            searchBox.Clear();
            searchBox.SendKeys("EiOleSellistKokteili123");


            searchBox.SendKeys(Keys.Enter);

            StringAssert.Contains(driver.Url, "/Cocktails");
        }
    }
}
