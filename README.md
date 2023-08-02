# SeleniumNUnitFramework

SeleniumNUnitFramework is an automation test framework for testing the functionality of the Spanish Point website (https://www.spanishpoint.ie/). 
The framework is built using Selenium WebDriver with C# and follows the Page Object Model (POM) design pattern for enhanced maintainability and modularity.

## Project Structure

The project is organized into the following folders:

- **SeleniumNUnitFramework**: This folder contains the test project.
  - **SpanishPointTest**: Contains Test classes for the website.

    - **ContentAndCollaboration.cs**: Represents the test class containing test methods for Content and Collaboration section
       of the Spanish Point website.
  
  - **SpanishPointWebPages**: Contains Page Object Model (POM) classes for different pages of the website.

    - **HomePage.cs**: Represents the home page of the Spanish Point website.
    - **ModernWorkPage.cs**: Represents the Modern Work page under Solutions & Services.

  - **Utilities**: Contains utility classes used by the test framework.
    
    - **Configuration.cs**: Provides configuration values such as SpanishPointURL, ContentCollabHeaderText and ParagraphText.
    - **Logger.cs**: Provides logging functionality and stores the output log file in //SeleniumNUnitFramework/bin/Debug/net7.0/Logs.
    - **SeleniumUtils.cs**: Contains comman selenium functions.

  - **config.json**: Json file containing test data used by the tests such as URL, header text and paragraph text

## Dependencies

- NUnit: Testing framework for running the test cases.
- NUnit3TestAdapter: Adapter for executing NUnit tests in Visual Studio.
- Selenium.WebDriver: To Interact with browser elements
- Selenium.Support: To Interact with browser elements
- Selenium.WebDriver.Chrome: To Interact with chrome browser elements

## Setup and Execution

1. Clone the repository to your local machine.

2. Build the solution using Visual Studio or your preferred IDE.

3. The project uses the Chrome browser for running tests. Make sure you have Google Chrome installed on the test machine.

4. The tests can be executed using any test runner that supports NUnit, such as Visual Studio Test Explorer or NUnit Console Runner.

5. Test reports will be generated in a log file and saved in //SeleniumNUnitFramework/bin/Debug/net7.0/Logs.

6. Please place config.json under //SeleniumNUnitFramework/bin/Debug/net7.0 folder 
