using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenNavigationTests : BaseTest
    {
        [TestMethod]
        public void CanNavigateToKindergartenPage()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // Open list
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // Wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/Kindergarten"));

            // Check
            Assert.IsTrue(driver.Url.Contains("/Kindergarten"));
        }

        [TestMethod]
        public void CanOpenCreatePageFromNavbar()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // List
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // Create
            driver.FindElement(By.LinkText("Create new")).Click();

            // Wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/Create"));

            // Check
            Assert.IsTrue(driver.Url.Contains("Create"));
        }
    }
}
