using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace UnidaysHomework.Tests.Acceptance
{
    public static class WebDriverExtensions
    {
        public static void Url(this RemoteWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
            driver.WaitForNavigationToComplete();
        }

        public static void Refresh(this RemoteWebDriver driver)
        {
            driver.Navigate().Refresh();
            driver.WaitForNavigationToComplete();
        }

        public static void WaitForNavigationToComplete(this RemoteWebDriver driver)
        {
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30.00));

            wait.Until(driver1 =>
                ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public static void SetTextForId(this RemoteWebDriver driver, string elementId, string textToSet, bool deleteAllFirst = false)
        {
            var e = driver.FindElementById(elementId);

            if (deleteAllFirst)
            {
                e.Clear();
            }

            e.SendKeys(textToSet);
        }

        public static void ClickButtonWithId(this RemoteWebDriver driver, string buttonId)
        {
            var button = driver.FindElementById(buttonId);
            button.Click();
        }

        public static void Submit(this RemoteWebDriver driver)
        {
            driver.ClickButtonWithId("btnSubmit");
        }

        public static void Wait(this RemoteWebDriver driver, int ms)
        {
            Thread.Sleep(ms * 4);
        }
    }
}