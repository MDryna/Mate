using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using Faker;
using System.Linq;
using OpenQA.Selenium.Support.UI;

namespace autoTests.PageObjects
{
    class AuthorizationPageObject
    {
        private IWebDriver driver;

        private readonly By _loginInputEmail = By.CssSelector("input[type='email']");
        private readonly By _loginInputPassword = By.XPath("//input[@type='password']");
        private readonly By _submitLogIn = By.XPath("//button[@type='submit']");
        private readonly By _errormessage = By.XPath("//div[@class='message-list']");
        private readonly string _validationError = "message-list";

        public AuthorizationPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MainMenuPageObject Login(string login, string password)
        {

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(_loginInputEmail).SendKeys(login);
            driver.FindElement(_loginInputPassword).SendKeys(password);
            Thread.Sleep(1000);
            driver.FindElement(_submitLogIn).Click();

            return new MainMenuPageObject(driver);

        }

        public MainMenuPageObject LogInFailed(string randomEmail, string randomPassword)
        {
            driver.FindElement(_loginInputEmail).SendKeys(randomEmail);
            Thread.Sleep(1000);
            driver.FindElement(_loginInputPassword).SendKeys(randomPassword);
            driver.FindElement(_submitLogIn).Click();
            driver.FindElement(_errormessage);//шукає елемент але не має Assert на цю перевірку ??


            return new MainMenuPageObject(driver);
        }
        
    }

}

