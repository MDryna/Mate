using System;
using System.Collections.Concurrent;
using System.Text;
using Faker;
using OpenQA.Selenium;

namespace autoTests
{
	public class TestSettings

	{
        private IWebDriver driver;

        public static string HostUrl = "https://mate.academy/";
        public const string login = "mm_dryna@ukr.net";
        public const string password = "0105Maria!";
        public static string mail = "@gmail.com";

        public static string courseFE { get; } = "Frontend";
        public static string courseQA { get; } = "QA";
        public static string courseFULL { get; } = "Fullstack";
        public static string courseJava { get; } = "Java";
        public static string courseUIUX { get; } = "UI/UX Design";
        public static string coursePython { get; } = "Python";

        public const int Wait_for_element_timeout = 40;
        //private IWebElement _loginInputEmail => driver.FindElement(By.CssSelector("input[type='email']"));

        //public IWebElement signInButton => driver.FindElement(By.XPath("//div[@class='show-for-medium']"));
    }
}

