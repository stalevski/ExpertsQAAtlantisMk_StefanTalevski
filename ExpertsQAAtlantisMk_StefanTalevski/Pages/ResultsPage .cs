using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace ExpertsQAAtlantisMk_StefanTalevski.Pages
{
    public class ResultsPage : BasePage
    {
        private readonly By BalkanHolidaysAir = By.XPath("//td[text()='Balkan Holidays Air']");

        public ResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public void VerifyBalkanHolidaysAirIsShown()
        {
            WaitForElementToBeVisible(BalkanHolidaysAir);
            ClassicAssert.IsTrue(IsElementVisible(BalkanHolidaysAir), "Search result not shown");
            
        }
    }
}
