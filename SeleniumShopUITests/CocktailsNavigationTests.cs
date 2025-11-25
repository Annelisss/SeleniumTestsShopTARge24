using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumShopUITests
{
    [TestClass]
    public class CocktailsNavigationTests : BaseTest
    {
        [TestMethod]
        public void CanNavigateToCocktailsIndex()
        {
            // Home
            driver.Navigate().GoToUrl(BaseUrl);

            // Menu
            driver.FindElement(By.LinkText("Cocktails")).Click();

            StringAssert.Contains(driver.Url, "/Cocktails");
        }
    }
}
