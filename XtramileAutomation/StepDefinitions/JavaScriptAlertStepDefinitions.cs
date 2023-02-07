using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using XtramileAutomation.Pages;

namespace XtramileAutomation.StepDefinitions
{
    [Binding]
    public sealed class JavaScriptAlertStepDefinitions
    {
        private IWebDriver driver;
        private JavascriptAlertPage javascriptAlertPage;

        public JavaScriptAlertStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"I go to Javascript Alert Page")]
        public void GivenIGoToJavascriptAlertPage()
        {

            javascriptAlertPage = new JavascriptAlertPage(driver);
            string BASE_URL = "https://the-internet.herokuapp.com/javascript_alerts";
            driver.Navigate().GoToUrl(BASE_URL);
            string actualURL = driver.Url;


            Assert.AreEqual(BASE_URL, actualURL, "The actual URL does not match the expected URL.");
        }

        [When(@"I click on the ""([^""]*)"" button")]
        public void WhenIClickOnTheButton(string p0)
        {
            javascriptAlertPage.ClickButton(p0);
        }

        [Then(@"I should see an alert message with text ""([^""]*)""")]
        public void ThenIShouldSeeAnAlertMessageWithText(string alertText)
        {
            string actualAlert = javascriptAlertPage.GetAlertText();
            Assert.AreEqual(alertText, actualAlert);
        }

        [Then(@"I accept the alert")]
        public void ThenIAcceptTheAlert()
        {
            javascriptAlertPage.AcceptAlert();
        }

        [Then(@"I should see an confirm message with text ""([^""]*)""")]
        public void ThenIShouldSeeAnConfirmMessageWithText(string confirmText)
        {
            string actualConfirm = javascriptAlertPage.GetAlertText();
            Assert.AreEqual(confirmText, actualConfirm);
        }

        [Then(@"I click Ok in the confirm")]
        public void ClickOkeConfirmPopup()
        {
            javascriptAlertPage.AcceptConfirm();
        }

        [Then(@"I cancel the confirm")]
        public void ClickCancelConfirmPopip()
        {
            javascriptAlertPage.CancelConfirm();
        }

        [Then(@"I should see the message ""([^""]*)""")]
        public void ThenIShouldSeeTheMessage(string message)
        {
            string actualMessage = javascriptAlertPage.GetResultText();
            Assert.AreEqual(message, actualMessage);
        }
        [Then(@"I type ""(.*)"" in the prompt and press OK")]
        public void ThenITypeInThePromptAndPressOK(string input)
        {
            javascriptAlertPage.TypeInPromptAndAccept(input);
        }
    }
}
