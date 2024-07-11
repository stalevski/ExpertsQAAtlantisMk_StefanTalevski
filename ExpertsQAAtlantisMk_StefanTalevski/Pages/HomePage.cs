using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace ExpertsQAAtlantisMk_StefanTalevski.Pages
{
    public class HomePage : BasePage
    {
        private readonly By Departure = By.Id("packageDeparturev2");
        private readonly By Arrival = By.Id("packageArrivalv2");
        private readonly By VacationLength = By.Id("packageDayv2");
        private readonly By NumberOfPeople = By.XPath("/html/body/div[4]/div[2]/div/div/div[1]/div[2]/table/tbody/tr/td[5]/div/div[1]");
        private readonly By NumberOfPeopleNewBoxAdultCount = By.Id("multipackageAdultv2");
        private readonly By NumberOfPeopleNewBoxChildrenCount = By.Id("multipackageChildv2");
        private readonly By SearchButton = By.ClassName("searchButton");
        private readonly By DepartureDate = By.Id("packageDepartureDatev2");
        private readonly By AcceptCookiesButton = By.XPath("/html/body/div[2]/div/div[3]/button[1]");
        private readonly By ErrorMessageNoDEstinationAndDateText = By.Id("warningPopupText");

        public HomePage(IWebDriver driver) : base(driver)
        {
            NavigateTo("https://www.atlantis.mk/");
        }

        public void AcceptCookies()
        {
            if (IsElementVisible(AcceptCookiesButton) && IsElementClickable(AcceptCookiesButton))
            {
                ClickElement(AcceptCookiesButton);
            }
        }

        public void SetDeparture(string departure)
        {
            SelectFromDropdown(Departure, departure);
        }

        public void SetArrival(string arrival)
        {
            SelectFromDropdown(Arrival, arrival);
        }

        public void SetVacationLength(string length)
        {
            SelectFromDropdown(VacationLength, length);
        }

        public void SetNumberOfPeople(int adults, int children)
        {
            WaitForElementToBeClickable(NumberOfPeople);
            ClickElement(NumberOfPeople);
            EnterText(NumberOfPeopleNewBoxAdultCount, adults.ToString());
            EnterText(NumberOfPeopleNewBoxChildrenCount, children.ToString());
        }

        public void SetDepartureDate(string date)
        {
            SetDate(DepartureDate, date);
        }

        public ResultsPage ClickSearchButton()
        {
            WaitForElementToBeClickable(SearchButton);
            ClickElement(SearchButton);
            return new ResultsPage(Driver);
        }

        public void ClickPassengersOkButton(By locator)
        {
            Log.Info($"Clicking on element {locator}");
            var element = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

            System.Threading.Thread.Sleep(500);

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        public bool VerifyErrorMessageDestinationAndDateIsShown()
        {
            if (IsElementVisible(ErrorMessageNoDEstinationAndDateText))
            { return true; }
            return false;
        }
    }
}
