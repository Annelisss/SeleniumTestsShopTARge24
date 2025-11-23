using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenCreateTests : BaseTest
    {
        [TestMethod]
        public void CanCreateKindergartenWithValidData()
        {
            // Ava avaleht
            driver.Navigate().GoToUrl(BaseUrl);

            // Mine Kindergarten (test) lehele
            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            // Ava Create leht
            driver.FindElement(By.LinkText("Create new")).Click();

            // Täida vorm ÕIGETE andmetega
            driver.FindElement(By.Id("GroupName")).Clear();
            driver.FindElement(By.Id("GroupName")).SendKeys("SeleniumGroup1");

            driver.FindElement(By.Id("ChildrenCount")).Clear();
            driver.FindElement(By.Id("ChildrenCount")).SendKeys("25");

            driver.FindElement(By.Id("KindergartenName")).Clear();
            driver.FindElement(By.Id("KindergartenName")).SendKeys("Selenium Kindergarten");

            driver.FindElement(By.Id("TeacherName")).Clear();
            driver.FindElement(By.Id("TeacherName")).SendKeys("Test Teacher");

            // Saada vorm
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/KindergartenTest"));

            // Kontrolli, et tabelis on uus rida
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            var createdRow = rows.FirstOrDefault(r => r.Text.Contains("SeleniumGroup1"));

            Assert.IsNotNull(createdRow, "Loodud Kindergarten rida ei ilmunud Index tabelisse.");
        }

        [TestMethod]
        public void CannotCreateKindergartenWithInvalidChildrenNumber()
        {
            // Ava avaleht
            driver.Navigate().GoToUrl(BaseUrl);

            // Mine Kindergarten (test) lehele
            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            // Ava Create leht
            driver.FindElement(By.LinkText("Create new")).Click();

            // Täida vorm VALE TÜÜBI andmetega
            driver.FindElement(By.Id("GroupName")).SendKeys("InvalidGroup");
            driver.FindElement(By.Id("ChildrenCount")).SendKeys("ABC");    // vale tüüp
            driver.FindElement(By.Id("KindergartenName")).SendKeys("Invalid Kindergarten");
            driver.FindElement(By.Id("TeacherName")).SendKeys("Invalid Teacher");

            // Saada vorm
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/KindergartenTest/Create"));

            // MVC lisab <span asp-validation-for="ChildrenCount">
            var errorSpan = driver.FindElement(By.CssSelector("span[data-valmsg-for='ChildrenCount']"));

            Assert.IsTrue(
                errorSpan.Displayed && !string.IsNullOrWhiteSpace(errorSpan.Text),
                "Ootasime veateadet ChildrenCount väljale, kuid seda ei kuvata."
            );
        }
    }
}
