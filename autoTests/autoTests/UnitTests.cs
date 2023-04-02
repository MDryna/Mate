using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using System.Text;
using System;
using autoTests.PageObjects;
using Faker;
using OpenQA.Selenium.Support.UI;


namespace autoTests
{
  class Tests : BaseTest 
    {

       //перевірка що після логіну відкривається юрл кабінету користувача
        [Test]
        public void TestUserCanSuccessfullyLogIn()
        {

            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn()
                .Login(TestSettings.login, TestSettings.password)
                .OpenURL();
                

            Thread.Sleep(10000);
            string currentUrl = mainMenu.OpenURL();
            Thread.Sleep(5000);
            Assert.AreEqual(currentUrl, "https://mate.academy/learn?course=all_courses", "URL is wrong or Enter wasn't completed");

        }


        //перевірка тайтла у веб вкладці
        [Test]
        public void TestWebTitleOnUserAccount()
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn()
                .Login(TestSettings.login, TestSettings.password);

            Thread.Sleep(5000);

            Assert.That(driver.Title, Is.EqualTo("Learn | Mate academy"));
        }

        [Test]
        public void TestLogInFailedWith_Non_Existing_Credentials()
        {

            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .SignIn()
                .LogInFailed(RandomData.GenereteRandomEmail(TestSettings.mail), RandomData.GenereteRandomPassword());


            string currentUrl = mainMenu.OpenURL();
            Assert.AreEqual(currentUrl, "https://mate.academy/learn?course=all_courses", "Failed test, url doesn't match with /sign-in");

        }


        [Test]
        public void TestMainPopperWithCourses()
        {
            var mainMenu = new MainMenuPageObject(driver);
               
            Assert.IsTrue(mainMenu.CheckPopperWithCoursesDisplayed());


        }

        [Test]
        public void TestCourseFEopens()  //LINQ
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .RedirectingToCourses(TestSettings.courseFE);
        }

        [Test]
        public void TestCourseQAopens()  //LINQ
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .RedirectingToCourses(TestSettings.courseQA);
        }

        [Test]
        public void TestCourseJavaOpens()  //LINQ
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .RedirectingToCourses(TestSettings.courseJava);
        }

        [Test]
        public void TestCourseUIUXOpens()  //LINQ
        {
            var mainMenu = new MainMenuPageObject(driver);
            mainMenu
                .RedirectingToCourses(TestSettings.courseUIUX);
        }


        [Test]
        public void ValiadateTitleFullStack()
        {
            var main = new MainMenuPageObject(driver);
            main
                .RedirectingToCourses(TestSettings.courseFULL); //LINQ


            Thread.Sleep(3000);
            var title = driver.FindElement(By.CssSelector("div[class='small-mb-32']")); //????перенести в окрему змінну
            Assert.That(title.Text, Is.EqualTo("КУРС FULLSTACK JAVASCRIPT DEVELOPMENT"));// перевіряємо що тайтл == даним у лапках
        }

 



    }
}
