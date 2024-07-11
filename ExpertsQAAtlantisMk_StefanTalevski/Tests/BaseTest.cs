using ExpertsQAAtlantisMk_StefanTalevski.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExpertsQAAtlantisMk_StefanTalevski.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected BasePage BasePage;
        protected HomePage HomePage;
        protected ResultsPage ResultsPage;

        [SetUp]
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            BasePage = new BasePage(Driver);
            HomePage = new HomePage(Driver);
            ResultsPage = new ResultsPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}
