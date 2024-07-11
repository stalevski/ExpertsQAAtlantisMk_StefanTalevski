using NUnit.Framework;

namespace ExpertsQAAtlantisMk_StefanTalevski.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
    {
        [Test]
        public void Test_SearchFunctionality()
        {
            HomePage.AcceptCookies();
            HomePage.SetDeparture("Скопје");
            HomePage.SetArrival("Хургада");
            HomePage.SetDepartureDate("31/07/2024");
            HomePage.SetVacationLength("7");
            HomePage.SetNumberOfPeople(2, 1);

            ResultsPage = HomePage.ClickSearchButton();

            var resultsUrl = ResultsPage.GetCurrentUrl();
            TestContext.WriteLine($"Results Page URL: {resultsUrl}");

            ResultsPage.TakeScreenshot("ResultsPage");
            ResultsPage.VerifyBalkanHolidaysAirIsShown();
        }

        [Test]
        public void Test_ErrorMessageIsShownIfNoDestinationAndDateIsSelected()
        {
            HomePage.AcceptCookies(); 
            HomePage.ClickSearchButton();
            HomePage.VerifyErrorMessageDestinationAndDateIsShown();

            ResultsPage.TakeScreenshot("ErrorMessage");
        }
    }
}
