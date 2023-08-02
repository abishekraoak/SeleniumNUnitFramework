using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumNUnitFramework.SpanishPointWebPages;
using SeleniumNUnitFramework.Utilities;

namespace SeleniumNUnitFramework;

public class Tests
{
    private IWebDriver webDriver;
    private Configuration config;
    private Logger logger;


    [SetUp]
    public void Setup()
    {
        config = Configuration.Load(Path.Combine(Directory.GetCurrentDirectory(), "config.json"));
        logger = new Logger(Directory.GetCurrentDirectory(), "TestLog");
        logger.LogBreakers();

        logger.LogInfo("Execution Started");
        logger.LogInfo("Initialising Chrome Driver");
        string chromeDriverPath = Path.Combine(Directory.GetCurrentDirectory(), "chromedriver");
        webDriver = new ChromeDriver(chromeDriverPath);
        webDriver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        logger.LogInfo("Quitting Chrome Driver");
        webDriver.Quit();
        logger.LogInfo("Dispose Logger");
        logger.LogInfo("Execution Started");
        logger.LogBreakers();
        logger.Dispose();
    }

    [Test]
    public void VerifyContentAndCollaborationTab()
    {
        try
        {
            HomePage homePage = new HomePage(webDriver, logger);
            string spanishPointURL = config.SpanishPointURL;
            string contentCollabHeaderText = config.ContentCollabHeaderText;
            string paragraphText = config.ParagraphText;

            ModernWorkPage modernWorkPage = homePage
                        .VisitSpanishPointHomePage(spanishPointURL)
                        .ExpandSolutionsAndServices()
                        .ClickContentAndCollaborationTab();

            Assert.IsTrue(modernWorkPage.GetAndVerifyHeaderText(contentCollabHeaderText), "Content & Collaboration header is not displayed");
            logger.LogInfo("Header with the text ‘Content & Collaboration’ is displayed");

            Assert.IsTrue(modernWorkPage.GetAndVerifyParagraphText(paragraphText),
                "Content & Collaboration paragraph is not displayed");
            logger.LogInfo("Paragraph in panel ‘Content & Collaboration’ starts with is - " +
                "Spanish Point customers tell us that people are their most important asset.");
            logger.LogInfo("Test Executed successfully");
        }
        catch (AssertionException ex)
        {
            logger.LogError($"Test Failed. Exception details - {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error Occured - Exception details - {ex.Message}");
            throw;
        }
    }
}
