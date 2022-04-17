using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace HomeTask_1
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com.ua/");
            IWebElement searchMenu = driver.FindElement(By.Name("q"));
            searchMenu.SendKeys("Dog");
            searchMenu.Submit();
            Thread.Sleep(5);
            IWebElement pictureButton = driver.FindElement(By.XPath("//a[@data-hveid='CAIQAw']"));
            pictureButton.Click();
            Assert.IsTrue(driver.FindElement(By.Id("islrg")).Displayed);
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            driver.Quit();
        }
    }
}