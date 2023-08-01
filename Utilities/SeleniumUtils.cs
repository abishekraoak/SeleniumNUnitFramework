using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace SeleniumNUnitFramework.Utilities
{
	public static class SeleniumUtils
	{
        public static IWebElement WaitUntilElementDisplayed(IWebDriver webDriver, By elementLocator, string elementName, Logger logger, int timeOutInSec = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeOutInSec));
                return wait.Until(ele => ele.FindElement(elementLocator).Displayed ? ele.FindElement(elementLocator) : null);
            }
            catch (WebDriverTimeoutException)
            {
                logger.LogError($"{elementName} is not displayed withing specified time");
                Console.WriteLine($"{elementName} is not displayed withing specified time");
                return null;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error Occured while waiting for the element {elementName} - {ex.Message}");
                Console.WriteLine($"Error Occured while waiting for the element {elementName} - {ex.Message}");
                return null;
            }

        }

        public static void PressKeyDownArrow(IWebDriver webDriver, int timesToPress)
        {
            for (int i = 0; i <= timesToPress; i++)
            {
                Actions action = new Actions(webDriver).KeyDown(Keys.ArrowDown).KeyUp(Keys.ArrowDown);
                action.Build().Perform();
            }
        }
    }
}

