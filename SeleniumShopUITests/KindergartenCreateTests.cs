using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenCreateTests : BaseTest
    {
        [TestMethod]
        public void CanCreateKindergartenWithValidData()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // List
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // Create
            driver.FindElement(By.LinkText("Create new")).Click();

            // Group
            driver.FindElement(By.Id("GroupName")).Clear();
            driver.FindElement(By.Id("GroupName")).SendKeys("SeleniumGroup1");

            // Children
            driver.FindElement(By.Id("ChildrenCount")).Clear();
            driver.FindElement(By.Id("ChildrenCount")).SendKeys("25");

            // Kindergarten
            driver.FindElement(By.Id("KindergartenName")).Clear();
            driver.FindElement(By.Id("KindergartenName")).SendKeys("Selenium Kindergarten");

            // Teacher
            driver.FindElement(By.Id("TeacherName")).Clear();
            driver.FindElement(By.Id("TeacherName")).SendKeys("Test Teacher");

            // Save
            // Save
            driver.FindElement(By.CssSelector("button[type='submit'], input[type='submit']")).Click();

            // Wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/Kindergarten"));
        }
    }
}
