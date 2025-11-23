using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenEditTests : BaseTest
    {
        [TestMethod]
        public void CanEditKindergartenWithValidData()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            Assert.IsTrue(rows.Any(), "Index tabelis ei ole ühtegi rida, mida muuta.");

            var rowToEdit = rows.First();

            // Open Edit
            var editLink = rowToEdit.FindElement(By.LinkText("Edit"));
            editLink.Click();

            // Change TeacherName value
            var newTeacher = "EditedTeacher123";
            var teacherInput = driver.FindElement(By.Id("TeacherName"));
            teacherInput.Clear();
            teacherInput.SendKeys(newTeacher);

            // Save
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/KindergartenTest"));

            var pageSource = driver.PageSource;
            Assert.IsTrue(pageSource.Contains(newTeacher),
                "Muudetud TeacherName väärtus ei ole Index tabelis näha.");
        }

        [TestMethod]
        public void CannotEditKindergartenWithInvalidChildrenNumber()
        {

            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            Assert.IsTrue(rows.Any(), "Index tabelis ei ole ühtegi rida, mida muuta.");

            var rowToEdit = rows.First();

            // Open Edit
            var editLink = rowToEdit.FindElement(By.LinkText("Edit"));
            editLink.Click();

            var childrenInput = driver.FindElement(By.Id("ChildrenCount"));
            childrenInput.Clear();
            childrenInput.SendKeys("ABC");

            // Save
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();

  
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/KindergartenTest/Edit"));

            var errorSpan = driver.FindElement(By.CssSelector("span[data-valmsg-for='ChildrenCount']"));

            Assert.IsTrue(
                errorSpan.Displayed && !string.IsNullOrWhiteSpace(errorSpan.Text),
                "Ootasime veateadet ChildrenCount väljale, kuid seda ei kuvata Edit vormil."
            );
        }
    }
}
