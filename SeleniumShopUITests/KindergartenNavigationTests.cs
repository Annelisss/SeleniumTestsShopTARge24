using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumShopUITests
{
    [TestClass]
    public class KindergartenNavigationTests : BaseTest
    {
        [TestMethod]
        public void CanNavigateToKindergartenTestIndex()
        {
            // Ava avaleht
            driver.Navigate().GoToUrl(BaseUrl);

            var kindergartenTestLink =
                driver.FindElement(By.LinkText("Kindergarten (test)"));
            kindergartenTestLink.Click();
            
            // Leia lehe pealkiri
            var header = driver.FindElement(By.TagName("h1"));

            Assert.AreEqual("Kindergarten", header.Text,
                "Kindergarten (test) lehe pealkiri ei ole oodatud.");
        }
    }
}
