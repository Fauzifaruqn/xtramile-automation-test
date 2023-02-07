using OpenQA.Selenium;
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
            public void SearchComputer(string computerName)
            {
                SearhboxComputer.SendKeys(computerName);
                BtnFilter.Click();

            }
        }
}
