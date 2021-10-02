using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using TechTalk.SpecFlow;


namespace test
{
    [Binding]
    public class OrderSteps
    {
        public IWebDriver driver;
        public Actions act;

        public OrderSteps()
        {
            driver = new ChromeDriver();
            act = new Actions(driver);
        }

        [Given(@"i'm in the menu page")]
        public void GivenIMInTheMenuPage()
        {
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Navigate().GoToUrl("https://localhost:44355/");
            driver.Manage().Window.Maximize();
        }
        
        [Then(@"l click order button")]
        public void ThenLClickOrderButton()
        { 
            //order some pizza with different quantities to test the cart  
            var ss = driver.FindElement(By.Name("Order"));
            act.DoubleClick(ss).Build().Perform();
            Thread.Sleep(2000);

            var s = driver.FindElement(By.XPath("/html/body/div/main/div/div/div[5]/div/div/input"));
            act.DoubleClick(s).Perform();
            Thread.Sleep(2000);

            driver.FindElement(By.XPath("/html/body/div/main/div/div/div[2]/div/div/input")).Click();
            Thread.Sleep(2000);

        }
        
        [Then(@"i click the cart link")]
        public void ThenIClickTheCartLink()
        {      
            //go to the cart to view the orders
            driver.FindElement(By.LinkText("Cart")).Click();
        }
        
        [Then(@"i click the remove button")]
        public void ThenIClickTheRemoveButton()
        {
            //testing the remove button in the cart
            driver.FindElement(By.Name("Remove")).Click();
            driver.Navigate().Refresh();
            Thread.Sleep(10000);
        }
        
        [Then(@"i click the Confirm Order")]
        public void ThenIClickTheConfirmOrder()
        {
            //Confirm The Order
            driver.FindElement(By.Name("Confirm Order")).Click();
        }
        
        [Then(@"i should go to the order Confirm page")]
        public void ThenIShouldGoToTheOrderConfirmPage()
        {
            Assert.That(driver.FindElement(By.XPath("/html/body/div/main/div/form/div/div/h2")).Displayed);
        }

        [Then(@"Close the browser")]
        public void ThenCloseTheBrowser()
        {
            Thread.Sleep(10000);
            driver.Close();
        }

    }
}
