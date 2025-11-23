using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumShopUITests
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;

        protected const string BaseUrl = "https://localhost:7282";

        [TestInitialize]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
