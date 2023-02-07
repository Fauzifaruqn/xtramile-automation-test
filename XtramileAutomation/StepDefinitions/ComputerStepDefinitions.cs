﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XtramileAutomation.Pages;

namespace XtramileAutomation.StepDefinitions
{
    [Binding]
    public sealed class ComputerStepDefinitions
    {
        private IWebDriver driver;
        private ComputerPage computerPage;
        private string computerName;


        public ComputerStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
       

        [Given(@"I go to Computer Database Page")]
        public void GivenGotoComputerPage()
        {
            computerPage = new ComputerPage(driver);
            string BASE_URL = "https://computer-database.gatling.io/computers";
            driver.Navigate().GoToUrl(BASE_URL);
            string actualURL = driver.Url;
            

            Assert.AreEqual(BASE_URL, actualURL, "The actual URL does not match the expected URL.");

        }

        [When(@"I Type ""(.*)"" in Computer Search Box")]
        public void WhenITypeInComputerSearchBox(string computerName)
        {
            computerPage.SearchComputer(computerName);
        }

        [Then(@"in the table computer contains")]
        public void ThenInTheTableComputerContains(Table table)
        {
            ComputerPage computerPage = new ComputerPage(driver);
            var rows = computerPage.RowtableComputer;
        

            // Loop through each row in the table
            foreach (var row in rows)
            {
                // Get the values for each column in the row
                var computerName = row.FindElement(By.XPath("//table[contains(@class,'computers zebra-striped')]/tbody/tr/td[1]")).Text;
                var introduced = row.FindElement(By.XPath("//table[contains(@class,'computers zebra-striped')]/tbody/tr/td[2]")).Text;
                var discontinued = row.FindElement(By.XPath("//table[contains(@class,'computers zebra-striped')]/tbody/tr/td[3]")).Text;
                var company = row.FindElement(By.XPath("//table[contains(@class,'computers zebra-striped')]/tbody/tr/td[4]")).Text;

                // Check if the values match the expected values
                var expectedComputerName = table.Rows[0]["computer name"];
                var expectedIntroduced = table.Rows[0]["introduced"];
                var expectedDiscontinued = table.Rows[0]["discontinued"];
                var expectedCompany = table.Rows[0]["company"];

                Assert.AreEqual(expectedComputerName, computerName);
                Assert.AreEqual(expectedIntroduced, introduced);
                Assert.AreEqual(expectedDiscontinued, discontinued);
                Assert.AreEqual(expectedCompany, company);
            }
        }

        [Then(@"the table should contain message Nothing to display")]
        public void VerifyComputerNotFound()
        {
            var message =computerPage.msgNothing.Text;
            Assert.AreEqual("Nothing to display", message);
        }

        [When(@"I click Add a new computer button")]
        public void ClickButtonComputer()
        {
            computerPage.ButtonAddComputer();
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

        [When(@"I click on the Create this computer button")]

        public void ClickCreateComputer()
        {
            computerPage.ButtonCreateComputer();
        }

        [Then(@"a new computer successfully created")]

        public void ComputerCreated()
        {
            Console.WriteLine("Computer Name: " + computerName);

            string actualMessage = computerPage.succesMsg.Text;

            // Use Assert.AreEqual to verify the actual message against the expected message
            Assert.AreEqual($"Done ! Computer {computerName} has been created", actualMessage);
        }
    }
}
