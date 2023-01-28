using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameMarketSiteTests
{
    internal class TestUtils
    {
        private const string WEB_URL = "https://localhost:7137/";

        public static void LoginUser(WebDriver _webDriver)
        {
            _webDriver.Navigate().GoToUrl($"{WEB_URL}account/login");
            _webDriver.FindElement(By.Id("txtUsername")).SendKeys("Testing1");
            _webDriver.FindElement(By.Id("txtPassword")).SendKeys("admin");
/*            _webDriver.FindElement(By.Id("txtUsername")).SendKeys("ivy");
			_webDriver.FindElement(By.Id("txtPassword")).SendKeys("cycegeKbll");*/
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
        }

        public static void LoginAdmin(WebDriver _webDriver)
        {
            _webDriver.Navigate().GoToUrl($"{WEB_URL}account/login");
            _webDriver.FindElement(By.Id("txtUsername")).SendKeys("admin");
            _webDriver.FindElement(By.Id("txtPassword")).SendKeys("admin");
			_webDriver.FindElement(By.Id("btnSubmit")).Click();
        }
    }
}
