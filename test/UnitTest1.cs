using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace test
{
    public class Tests
    {            
        public IWebDriver driver;
        public Actions act;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
             act = new Actions(driver);
        }

        [Test]
        public void Test1()
        {        
            
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Navigate().GoToUrl("https://localhost:44355/");
            driver.Manage().Window.Maximize();


            var ss=driver.FindElement(By.Name("Order"));
            act.DoubleClick(ss).Build().Perform();
            Thread.Sleep(2000);

            var s= driver.FindElement(By.XPath("/html/body/div/main/div/div/div[5]/div/div/input"));
            act.DoubleClick(s).Perform();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/main/div/div/div[2]/div/div/input")).Click();
            Thread.Sleep(2000);


            driver.FindElement(By.LinkText("Cart")).Click();

            /* ;
             IWebElement wb2 = 
             act.DoubleClick(wb2);
            // Driver.FindElements(By.XPath("input[onclick=AddToCart(2)]"));

                         IList <IWebElement> orderButtons = Driver.FindElements(By.CssSelector("input[onclick=AddToCart(2)]"));
                         foreach(IWebElement t in orderButtons)
                         {
                             t.Click();
                         }


                         Thread.Sleep(10000);
                         Driver.Close();*/

            Assert.Pass();
        }
    }
}

