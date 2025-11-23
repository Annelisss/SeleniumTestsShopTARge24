using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenDeleteTests : BaseTest
    {
        [TestMethod]
        public void CanDeleteKindergarten()
        {
            // Open homepage and navigate to the Kindergarten (test) page
            driver.Navigate().GoToUrl(BaseUrl);
            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            // Get the first row from the table
            var rows = driver.FindElements(By.CssSelector("table tbody tr"));
            Assert.IsTrue(rows.Any(), "There are no rows in the Index table to delete.");

            var rowToDelete = rows.First();

            // Read the GroupName from the first cell (for verification after delete)
            var firstCell = rowToDelete.FindElements(By.TagName("td")).FirstOrDefault();
            var groupName = firstCell?.Text ?? "";

            // Open the Delete page
            var deleteLink = rowToDelete.FindElement(By.LinkText("Delete"));
            deleteLink.Click();

            // Confirm Delete (submit the Delete confirmation form)
            var deleteButton = driver.FindElement(By.CssSelector("input[type='submit']"));
            deleteButton.Click();

            // Wait until we return to the Index page
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url.Contains("/KindergartenTest"));

            // Verify that the deleted row is no longer in the table
            var pageSource = driver.PageSource;

            if (!string.IsNullOrWhiteSpace(groupName))
            {
                Assert.IsFalse(
                    pageSource.Contains(groupName),
                    "The deleted Kindergarten (GroupName = '" + groupName + "') is still visible in the Index table."
                );
            }
        }
    }
}
