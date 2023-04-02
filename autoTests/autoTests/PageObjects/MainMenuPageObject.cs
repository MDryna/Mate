using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Faker;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.Support.UI;


namespace autoTests.PageObjects
{
    class MainMenuPageObject 
    {
        private IWebDriver driver;


        private readonly By _signInButton = By.XPath("//div[@class='show-for-medium']");
        private readonly By _buttonCourses = By.XPath("//button[@class='Button_gray__A8i5Z Button_large__rIMVg HeaderCoursesDropdown_triggerButton__9_0nV Button_button__bwept Button_withIcon__o4QSd']");
        public readonly By _popperWithCourses = By.XPath("//ul[@class='DropdownCoursesList_coursesList__xjALB']/li");

        public MainMenuPageObject(IWebDriver driver)
        {
            this.driver = driver;

        }


        // метод кліку на _signInButton
        public AuthorizationPageObject SignIn() 
        {
            driver.FindElement(_signInButton).Click();
            Thread.Sleep(3000);
            return new AuthorizationPageObject(driver);
        }



        //метод зберігає відкритий url у змінну 
        public string OpenURL() 
        {
            string url = driver.Url;
            return url;
        }


        public bool CheckPopperWithCoursesDisplayed()
        {
            try
            {
                driver.FindElement(_buttonCourses).Click();
                driver.FindElement(_popperWithCourses);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        //перевіряємо, що юзер перенаправляється на сторінку із курсами
        public CoursePageObject RedirectingToCourses(string courseName)
        {
            driver.FindElement(_buttonCourses).Click();
            var courses = driver.FindElements(_popperWithCourses).First(x => x.Text == courseName); //LINQ звіряємо по тексту кнопок курсів
            courses.Click();

            return new CoursePageObject(driver);
        }




    }
}
