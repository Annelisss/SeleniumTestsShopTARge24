using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenEditTests : BaseTest
    {
        [TestMethod]
        public void CanEditKindergartenWithValidData()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // List
            driver.FindElement(By.LinkText("Kindergarten")).Click();

            // Edit
            driver.FindElement(By.LinkText("Edit")).Click();

            // Group
            driver.FindElement(By.Id("GroupName")).Clear();
            driver.FindElement(By.Id("GroupName")).SendKeys("EditedGroup");

            // Children
            driver.FindElement(By.Id("ChildrenCount")).Clear();
            driver.FindElement(By.Id("ChildrenCount")).SendKeys("30");

            // Kindergarten
            driver.FindElement(By.Id("KindergartenName")).Clear();
            driver.FindElement(By.Id("KindergartenName")).SendKeys("Edited Kindergarten");

            // Teacher
            driver.FindElement(By.Id("TeacherName")).Clear();
            driver.FindElement(By.Id("TeacherName")).SendKeys("Edited Teacher");

            // Save
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var saveButton = wait.Until(d =>
                d.FindElement(By.CssSelector("button[type='submit'], input[type='submit']")));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", saveButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", saveButton);

            // Wait
            wait.Until(d => d.Url.Contains("/Kindergarten"));
        }
    }
}
