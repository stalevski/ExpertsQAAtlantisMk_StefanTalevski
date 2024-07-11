using NUnit.Framework.Legacy;
using OpenQA.Selenium;

namespace ExpertsQAAtlantisMk_StefanTalevski.Pages
{
    public class HomePage : BasePage
    {
        private readonly By Departure = By.Id("packageDeparturev2");
        private readonly By Arrival = By.Id("packageArrivalv2");
        private readonly By VacationLength = By.Id("packageDayv2");
        private readonly By NumberOfPeople = By.CssSelector("div.passTrigger");
        private readonly By NumberOfPeopleNewBoxAdultCount = By.Id("multipackageAdultv2");
        private readonly By NumberOfPeopleNewBoxChildrenCount = By.Id("multipackageChildv2");
        private readonly By SearchButton = By.ClassName("searchButton");
        private readonly By DepartureDate = By.Id("packageDepartureDatev2");
        private readonly By AcceptCookiesButton = By.CssSelector("button.auto-button.fr.ml10");
        private readonly By ErrorMessageNoDestinationAndDateText = By.Id("warningPopupText");

        public HomePage(IWebDriver driver) : base(driver)
        {
            NavigateTo("https://www.atlantis.mk/");
        }

        public void AcceptCookies()
        {
            Logger.Information("Attempting to accept cookies.");
            try
            {
                if (IsElementVisible(AcceptCookiesButton) && IsElementClickable(AcceptCookiesButton))
                {
                    ClickElement(AcceptCookiesButton);
                    Logger.Information("'Accept Cookies' button clicked successfully.");
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occurred while attempting to accept cookies: {ex.Message}");
                throw;
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

        public void VerifyErrorMessageDestinationAndDateIsShown()
        {
            ClassicAssert.IsTrue(IsElementVisible(ErrorMessageNoDestinationAndDateText), "Expected error message not shown");
        }
    }
}
