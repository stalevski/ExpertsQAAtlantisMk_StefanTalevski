using OpenQA.Selenium;

namespace ExpertsQAAtlantisMk_StefanTalevski.Pages
{
    public class ResultsPage : BasePage
    {
        private readonly By BalkanHolidaysAir = By.XPath("/html/body/div[8]/div/div[2]/div[1]/div[3]/table/tbody/tr[2]/td[2]");

        public ResultsPage(IWebDriver driver) : base(driver)
        {
        }

        public bool VerifyBalkanHolidaysAirIsShown()
        {
            WaitForElementToBeVisible(BalkanHolidaysAir);
            if (IsElementVisible(BalkanHolidaysAir))
            { return true; }
            return false;
        }
    }
}
