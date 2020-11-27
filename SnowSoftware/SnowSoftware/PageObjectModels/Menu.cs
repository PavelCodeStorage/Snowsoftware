using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SnowSoftware.Driver;

namespace SnowSoftware
{
    public class Menu
    {

        private IWebDriver driver;
        private WebDriverWait wait;

        private By successButton = By.XPath("//li[contains(@class,'menu-columns-3')][1]//*[contains(text(), 'Success')]");
        private By SnowGlobeCommunityButton = By.XPath("//li[@class='menu-item '][2]/a[contains(@href,'community')]");

        public Menu()
        {
            driver = WebDriver.GetDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [Obsolete]
        public Menu ClickOnSuccessMenu()
        {
            IWebElement element = driver.FindElement(successButton);

            Point successLocation = element.Location;

            int x = successLocation.X;
            int y = successLocation.Y;

            Actions action = new Actions(driver);

            action.MoveByOffset(x, y).Perform();

            return this;
        }

        [Obsolete]
        public Menu ClickSnowGlobeCommunity()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(SnowGlobeCommunityButton));
            driver.FindElement(SnowGlobeCommunityButton).Click();

            return this;
        }
    }
}
