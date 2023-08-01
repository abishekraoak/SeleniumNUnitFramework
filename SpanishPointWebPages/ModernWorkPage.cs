using OpenQA.Selenium;
using SeleniumNUnitFramework.Utilities;

namespace SeleniumNUnitFramework.SpanishPointWebPages
{
	public class ModernWorkPage
	{
        private readonly IWebDriver webDriver;
        private Logger logger;

        public ModernWorkPage(IWebDriver webDriver, Logger logger)
        {
            this.webDriver = webDriver;
            this.logger = logger;
        }

        private By headerModerWorkplaceSolutions = By.XPath("//div[contains(@class,'wpb_wrapper')]/h2[text()='Modern Workplace Solutions']");
        private By tabContentAndCollaboration = By.XPath("//div[contains(@class,'vc_tta-container')]/div/div/ul/li/a/span[text()='Content & Collaboration']");
        private By headerContentAndCollaboration = By.XPath("//div[contains(@class,'vc_active')]/div[contains(@class,'vc_tta-panel-body')]//div[contains(@class,'wpb_wrapper')]/h3");
        private By paragraphContentAndCollaboration = By.XPath("//div[contains(@class,'vc_active')]/div[contains(@class,'vc_tta-panel-body')]//div[contains(@class,'wpb_wrapper')]/p");

        public ModernWorkPage ClickContentAndCollaborationTab()
        {
            logger.LogInfo("Performing page down operation using Down Arrow, so to make Market Workplace section visible");
            SeleniumUtils.PressKeyDownArrow(webDriver, 5);

            IWebElement eleModerWorkplaceSol = SeleniumUtils.WaitUntilElementDisplayed(webDriver, headerModerWorkplaceSolutions,
                "Modern Workplace Solutions Section", logger);

            if (eleModerWorkplaceSol != null)
            {
                logger.LogInfo("Modern Workplace Solutions header is displayed");
                Console.WriteLine("Modern Workplace Solutions header is displayed");

                IWebElement eleConAndcolab = SeleniumUtils.WaitUntilElementDisplayed(webDriver, tabContentAndCollaboration,
                "Content & Collaboration tab", logger);
                if (eleConAndcolab != null)
                {
                    logger.LogInfo("Clicking on Content & Collaboration tab");
                    eleConAndcolab.Click();
                    return this;
                }
                else
                {
                    logger.LogError("Content & Collaboration tab not displayed");
                    Console.WriteLine("Content & Collaboration tab not displayed");
                    throw new Exception("Content & Collaboration tab not displayed");
                }
            }
            else
            {
                logger.LogError("Modern Workplace Solutions header not displayed");
                Console.WriteLine("Modern Workplace Solutions header not displayed");
                throw new Exception("Modern Workplace Solutions header not displayed");
            }
        }

        public bool GetAndVerifyHeaderText(string headerText)
        {
            IWebElement eleHeaderText = SeleniumUtils.WaitUntilElementDisplayed(webDriver, headerContentAndCollaboration,
                "Content & Collaboration header", logger);

            if (eleHeaderText != null)
            {
                logger.LogInfo("Content & Collaboration header is visible");
                string actualText = eleHeaderText.Text.Trim();
                logger.LogInfo($"Header displayed in Content & Collaboration section - {actualText}");
                logger.LogInfo($"Expected Header in Content & Collaboration section - {headerText}");

                if (headerText.Equals(actualText))
                    return true;
                else
                    return false;
            }
            else
            {
                logger.LogError("Content & Collaboration header is visible");
                Console.WriteLine("Content & Collaboration header text is not displayed");
                throw new Exception("Content & Collaboration header text is not displayed");
            }
        }

        public bool GetAndVerifyParagraphText(string expectedText)
        {
            IWebElement eleParaText = SeleniumUtils.WaitUntilElementDisplayed(webDriver, paragraphContentAndCollaboration,
                "Content & Collaboration paragraph", logger);

            if (eleParaText != null)
            {
                logger.LogInfo("Content & Collaboration paragraph is visible");
                string actualText = eleParaText.Text.Trim().Split(".")[0] + ".";
                logger.LogInfo($"Paragraph displayed in Content & Collaboration section - {actualText}");
                logger.LogInfo($"Expected Paragraph that should start in Content & Collaboration section - {expectedText}");

                if (expectedText.Equals(actualText))
                    return true;
                else
                    return false;
            }
            else
            {
                logger.LogError("Content & Collaboration paragraph is visible");
                Console.WriteLine("Content & Collaboration paragraph text is not displayed");
                throw new Exception("Content & Collaboration paragraph text is not displayed");
            }
        }
    }
}

