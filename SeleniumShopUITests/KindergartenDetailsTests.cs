using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenDetailsTests : BaseTest
    {
        [TestMethod]
        public void CanOpenDetailsPage()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // List
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // First row -> Details
            driver.FindElement(By.LinkText("Details")).Click();

            // Wait for details page
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(x => x.Url.Contains("/Details"));

            // Basic check
            Assert.IsTrue(driver.Url.Contains("Details"));
        }
    }
}
