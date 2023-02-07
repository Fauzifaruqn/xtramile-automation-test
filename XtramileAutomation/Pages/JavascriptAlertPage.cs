using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XtramileAutomation.Pages
{
    public class JavascriptAlertPage
    {
        private IWebDriver driver;

        public JavascriptAlertPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement TitlePage => driver.FindElement(By.XPath("//div[contains(@class,'example')]/h3"));
        public IWebElement ResultText => driver.FindElement(By.Id("result"));


        public void ClickButton(string textbutton)
        {
            IWebElement button = driver.FindElement(By.XPath($"//li/descendant::button[contains(text(),'{textbutton}')]"));
            button.Click();
        }

        public string GetAlertText()
        {
            IAlert alert = driver.SwitchTo().Alert();
            return alert.Text;
        }
        public void AcceptAlert()
        {
           driver.SwitchTo().Alert().Accept();
        }
        public string GetResultText()
        {
            return ResultText.Text;
        }

        public void AcceptConfirm()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void CancelConfirm()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public void TypeInPromptAndAccept(string input)
        {
            driver.SwitchTo().Alert().SendKeys(input);
            driver.SwitchTo().Alert().Accept(); 
            
        }
    }
}
