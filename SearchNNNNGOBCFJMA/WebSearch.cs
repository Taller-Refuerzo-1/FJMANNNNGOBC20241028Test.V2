using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchNNNNGOBCFJMA
{
    [TestClass]
    public class WebSearch
    {
        private IWebDriver driver;

        public WebSearch()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void SearchInWebSearchGoogle()
        {
            driver.Navigate().GoToUrl("https://localhost:7121/Customer");
            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("F");
            searchBox.Submit();
            System.Threading.Thread.Sleep(1000);
            Assert.IsTrue(driver.Title.Contains("F"), "El titulo no contiene F");

        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}

