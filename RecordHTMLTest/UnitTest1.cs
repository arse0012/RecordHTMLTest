using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace RecordHTMLTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\Users\\seleniumDrivers";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver= new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }
        [TestMethod]
        public void GetAllRecordsTest()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            string title = _driver.Title;
            Assert.AreEqual("Hello app",title);

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            //IWebElement recordList = _driver.FindElement(By.Id("recordlist"));

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.IsTrue(recordList.Text.Contains("1997"));
        }
    }
}
