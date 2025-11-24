using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenDeleteTests : BaseTest
    {
        [TestMethod]
        public void CanDeleteKindergarten()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // List
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // Delete
            driver.FindElement(By.LinkText("Delete")).Click();

            // Confirm
            // Confirm
            driver.FindElement(By.CssSelector("button[type='submit'], input[type='submit']")).Click();

            // Wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/Kindergarten"));
        }
    }
}
