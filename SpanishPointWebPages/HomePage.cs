using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;

namespace SeleniumNUnitFramework.SpanishPointWebPages
{
	public class HomePage
	{
        private readonly IWebDriver webDriver;
        private Logger logger;

        public HomePage(IWebDriver webdriver, Logger logger)
        {
            this.webDriver = webdriver;
            this.logger = logger;
        }

        private By logoSpanishPoint = By.CssSelector(".navbar-brand img");
        private By tabSolutionsAndServices = By.XPath("//li[contains(@class,'menu-item-has-children')]/a/span[text()='Solutions & Services']");
        private By btnRejectCookies = By.CssSelector("a#wt-cli-reject-btn");
        private By menuItemModernWork = By.XPath("//li[contains(@class,'menu-item-type-post_type')]/a/span[text()='Modern Work']");

        public HomePage VisitSpanishPointHomePage()
        {
            logger.LogInfo("Navigating to Spanish Point URL");
            webDriver.Navigate().GoToUrl("https://www.spanishpoint.ie/");

            IWebElement eleRejectCookies = SeleniumUtils.WaitUntilElementDisplayed(webDriver, btnRejectCookies,
                "Cookies Dialog", logger, 5);
            if (eleRejectCookies != null)
            {
                logger.LogInfo("Cookies Policy Dialog is displayed, Clicking on Reject Cookies button");
                eleRejectCookies.Click();
                Thread.Sleep(2000);
            }

            IWebElement eleLogo = SeleniumUtils.WaitUntilElementDisplayed(webDriver, logoSpanishPoint,
                "Spanish Point Home page", logger);
            if (eleLogo != null)
            {
                logger.LogInfo("Spanish Point Homepage is displayed");
                Console.WriteLine("Spanish Point Homepage is displayed");
                return this;

            }
            else
            {
                logger.LogError("Spanish Point Homepage is not displayed");
                Console.WriteLine("Spanish Point Homepage is not displayed");
                throw new Exception("Home Page not displayed");
            }
        }

        public ModernWorkPage ExpandSolutionsAndServices()
        {
            webDriver.FindElement(tabSolutionsAndServices).Click();
            IWebElement eleModernWork = SeleniumUtils.WaitUntilElementDisplayed(webDriver, menuItemModernWork,
                "Modern Work Menu Item", logger);
            if (eleModernWork != null)
            {
                logger.LogInfo("Expanded Solutions & Services.Selecting Modern Work");
                Console.WriteLine("Expanded Solutions & Services. Selecting Modern Work");
                eleModernWork.Click();
                return new ModernWorkPage(webDriver, logger);
            }
            else
            {
                logger.LogError("Expand Solutions & Services operation failed");
                Console.WriteLine("Expand Solutions & Services operation failed");
                throw new Exception("Expand Solutions & Services operation failed");
            }
        }
    }
}

