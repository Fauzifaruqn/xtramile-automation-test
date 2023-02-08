# Xtramile-automation-test
### Table of Contents

- Introduction
- What we need to install
- Implement Cucumber / BDD with Specflow
- Implement Page Object Model
- UI Automation Result

Development technical documentation : https://docs.google.com/document/d/15-NXKKpoOH8KTTAHmJS88gpc-pdqII8WXurc82ToUrY/edit?usp=sharing


#### 1. Introduction
This is a repository for implementing UI automation regarding computer databases and JavaScript alerts. The tools used are Selenium C#. Additionally implementing Cucumber/BDD using Specflow https://specflow.org/ and Page Object Model. And the following is the Test Scenario that I use <br />

Test Case (for test cases the computer database and javascript alerts are in the same file, on different sheets)  : https://docs.google.com/spreadsheets/d/14jhD1yJJL-UnR8uW3IDqAD0d7Yc1d5Kq1zvc8lKVpVo/edit?usp=sharing 


#### 2. What we need to install
- Install Visual Studio https://visualstudio.microsoft.com/ and use .Net 6
- Install Selenium , You can install the Selenium WebDriver packages using NuGet Package Manager in Visual Studio.
- Install SpecFlow: SpecFlow is a BDD (Behavior Driven Development) tool that helps you to write and manage your automation test cases in a readable and understandable format. You can install the SpecFlow packages using NuGet Package Manager in Visual Studio.
- Create a New Project: In Visual Studio

#### 3. Implement Cucumber / BDD with Specflow
SpecFlow is a BDD (Behavior Driven Development) framework for .NET that helps define, manage, and execute human-readable acceptance tests in .NET projects. It's designed to work with Visual Studio and integrate with the existing testing tools and frameworks like NUnit, XUnit, MSTest, and Selenium.

Example
```
Feature: Computer_database

As a user, I want to be able to view and manage a list of computers.

@positive_case @search_computer
Scenario: User should be able to search a computer database
	Given I go to Computer Database Page
	When I Type "ASCI Purple" in Computer Search Box
	Then in the table computer contains 
  | computer name | introduced | discontinued | company    |
  | ASCI Purple   | 01 Jan 2005| 01 Jan 2006  | IBM|

```

#### 4. Implement Page Object Model
Page Object Model (POM) is a design pattern that is commonly used in software testing to represent a page or a section of a page in a web application.Create a separate class for each page of the application. Use the Page Object Model to define the elements on the page and their actions
Example
```
    public class ComputerPage
    {
        private IWebDriver driver;


        public ComputerPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        IWebElement SearhboxComputer => driver.FindElement(By.XPath("//input[contains(@id,'searchbox')]"));
        public IWebElement BtnFilter => driver.FindElement(By.Id("searchsubmit"));
        public IList<IWebElement> RowtableComputer => driver.FindElements(By.XPath("//table[contains(@class,'computers zebra-striped')]/tbody/tr"));
        public IWebElement msgNothing => driver.FindElement(By.XPath("//div[contains(@class,'well')]"));
        IWebElement titleFormAddComputer => driver.FindElement(By.XPath("//section[contains(@id,'main')]/h1"));
        public IWebElement succesMsg => driver.FindElement(By.ClassName("alert-message"));

        public IWebElement errorWrongDates => driver.FindElement(By.XPath("//span[contains(@class, 'help-inline') and contains(text(),'Failed to decode date')]"));

        

        public void SearchComputer(string computerName)
        {
            SearhboxComputer.SendKeys(computerName);
            BtnFilter.Click();

        }
   }

```

In this example, we have a ComputerPage class that encapsulates the details of the computer page in our application. The class provides methods to interact with the page, such as visiting the page, filtering, create and update computer.

Here's an example of how we can use the ComputerPage in our tests:

```
        [When(@"I Type ""(.*)"" in Computer Search Box")]
        public void WhenITypeInComputerSearchBox(string computerName)
        {
            computerPage.SearchComputer(computerName);
        }
        
        [When(@"I enter the following details")]
        public void EnterFormComputer(Table table)
        {

            computerName = table.Rows[0]["computer name"];
            var introducedDate = table.Rows[0]["introduced"];
            var discontinuedDate = table.Rows[0]["discontinued"];
            var companyName = table.Rows[0]["company"];
        
            computerPage.inputToField("name", computerName);
            computerPage.inputToField("introduced", introducedDate);
            computerPage.inputToField("discontinued", discontinuedDate);
            computerPage.SelectCompany(companyName);
        }

```

#### 5. UI Automation Result

for now the total Scenario that has been automated is

Computer Database : 11 Test Case, and Passed Percentage : 100%
Javascript Alert : 4 Test Case, and Passed Percentage : 100%

I have generated a report using Specflow Livingdoc, https://specflow.org/tools/living-doc/
Run the following Command
`
   dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
`

Generate the Living Documentation from SpecFlow test assembly:

`
livingdoc test-assembly C:\Work\MyProject.Specs\bin\Debug\netcoreapp3.1\MyProject.Specs.dll -t C:\Work\MyProject.Specs\bin\debug\netcoreapp3.1\TestExecution.json
`

To see the UI automation result html file from this project, you can see it in the following link https://drive.google.com/drive/folders/1IvHF76QHwhtHPl4V_p-4aw2E5IQhxmfW?usp=sharing
