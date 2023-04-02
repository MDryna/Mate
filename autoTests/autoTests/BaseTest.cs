using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Text;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using Faker;
using OpenQA.Selenium.Support.UI;

namespace autoTests
{
    public class BaseTest
    {
        protected IWebDriver driver; //можна визвати у будь-яких класах
        protected WebDriverWait webDriverWait;


        public void DriverManager()
        {
            webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(TestSettings.Wait_for_element_timeout));

        }


        [OneTimeSetUp]

        protected void DoBeforeAllTheTests() //виконується один раз перед запуском тестів
        {
            driver = new ChromeDriver();//ініціалізуємо вебдрайвер
          
        }


        [OneTimeTearDown]
        private void DoAfterAllTheTests() //виконуються один раз після усіх тестів
        {

        }

        [SetUp]
        protected void DobeforeEach()//виконуються перед кожним тестом
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Cookies.DeleteAllCookies();//чисти кукіси перд усіма тестами
            driver.Navigate().GoToUrl(TestSettings.HostUrl); //вказуємо UrІ, що збережено у файлі TestSettings 
            driver.Manage().Window.Maximize();  //команда для вивденя Chrome на весь екран монітору
                                              
        }

        [TearDown]
        protected void DoAfterEach()  //виконуються після кожного тесту
        {
            // driver.Quit(); //закриває браузер
        }

        ////очікування завантаження запитів
        //protected void WaitForAjax()
        //{
        //    var js = (IJavaScriptExecutor)driver;
        //    webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");

        //}

        ////не використовується 
        //protected void WaitUntilPageLoadsCompleately()
        //{
        //    var js = (IJavaScriptExecutor)driver;
        //    webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");

        //}
    }

}
