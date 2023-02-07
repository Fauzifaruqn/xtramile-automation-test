using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtramileAutomation.Pages
{
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

        public void SearchComputer(string computerName)
        {
            SearhboxComputer.SendKeys(computerName);
            BtnFilter.Click();

        }

        public void ButtonAddComputer()
        {
            IWebElement button = driver.FindElement(By.XPath("//a[contains(text(), 'Add a new computer')]"));
            button.Click();
            Assert.AreEqual("Add a computer", titleFormAddComputer.Text);
        }
        public void inputToField(string field, string value)
        {
            IWebElement fieldCreation = driver.FindElement(By.Id($"{field}"));
            fieldCreation.SendKeys(value);
        }

        public void SelectCompany(string company)
        {
            var selectElement = new SelectElement(driver.FindElement(By.Id("company")));
            selectElement.SelectByText(company);
        }

        public void ButtonCreateComputer()
        {
            IWebElement button = driver.FindElement(By.XPath("//input[contains(@value,'Create this computer')]"));
            button.Click();
           
        }
    }
}
