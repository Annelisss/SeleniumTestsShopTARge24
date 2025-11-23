using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Linq;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenDetailsTests : BaseTest
    {
        [TestMethod]
        public void CanOpenKindergartenDetails()
        {
            // Open the home page
            driver.Navigate().GoToUrl(BaseUrl);

            driver.FindElement(By.LinkText("Kindergarten (test)")).Click();

            // Take the first row from the table
            var firstRow = driver.FindElements(By.CssSelector("table tbody tr")).FirstOrDefault();
            Assert.IsNotNull(firstRow, "Index table does not contain any rows!");

 
            var detailsLink = firstRow.FindElement(By.LinkText("Details"));
            detailsLink.Click();

            // Check that the Details page is opened
            var header = driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual("Details", header, "Details page header is not as expected.");
        }
    }
}
