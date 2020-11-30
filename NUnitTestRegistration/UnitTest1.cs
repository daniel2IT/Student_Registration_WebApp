using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace NUnitTestRegistration
{
    public class Tests
    {

        [Test]
        public void Test1()
        {

            IWebDriver driver = new ChromeDriver(Environment.CurrentDirectory);
            driver.Url = "https://localhost:44369/Register";

            IWebElement element = driver.FindElement(By.Id("MainContent_nameField"));
            element.SendKeys("Daniel2IT");

            // driver.Url real URL
            string url = driver.Url;

            IWebElement button = driver.FindElement(By.Id("MainContent_registerButton"));
            button.Click();

            // Redirected(changed URL) or no ? after button click
            Assert.AreEqual(url, driver.Url);

            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}