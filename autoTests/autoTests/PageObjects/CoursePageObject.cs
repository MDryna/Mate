using System;
using OpenQA.Selenium;
using System.Threading;
using System.Text;


namespace autoTests.PageObjects
{
	public class CoursePageObject
	{
        private IWebDriver driver;

        private readonly By _FullStackTitle = By.CssSelector("div[class='small-mb-32']");

        public CoursePageObject(IWebDriver driver)
        {
            this.driver = driver;

        }
           
        public CoursePageObject ValiadateTitle()
        {
            var title = driver.FindElement(_FullStackTitle).Text; // змінна title містить текс елемента 
            return this;
        }

    }
}

