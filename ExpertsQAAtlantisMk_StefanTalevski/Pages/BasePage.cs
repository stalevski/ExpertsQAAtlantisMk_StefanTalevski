using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;

namespace ExpertsQAAtlantisMk_StefanTalevski.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        protected static readonly ILogger Logger;

        static BasePage()
        {
            try
            {
                LoggingConfig.Configure();
                Logger = Log.ForContext<BasePage>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing logger in BasePage: {ex.Message}");
                throw;
            }
        }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            Logger.Information($"Navigating to {url}");
            Driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By locator)
        {
            Logger.Information($"Clicking on element {locator}");
            var element = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            try
            {
                element.Click();
            }
            catch (ElementClickInterceptedException)
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
            }
        }

        public void EnterText(By element, string text)
        {
            Logger.Information($"Entering text '{text}' into element {element}");
            Wait.Until(driver => driver.FindElement(element).Displayed);
            Driver.FindElement(element).SendKeys(text);
        }

        public void SetDate(By locator, string date)
        {
            Logger.Information($"Setting date '{date}' in element {locator}");
            int attempts = 0;
            while (attempts < 3)
            {
                try
                {
                    var dateElement = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
                    if (dateElement.GetAttribute("readonly") == "true")
                    {
                        ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].removeAttribute('readonly',0);", dateElement);
                    }
                    dateElement.Clear();
                    dateElement.SendKeys(date);
                    dateElement.SendKeys(Keys.Enter);

                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].blur();", dateElement);
                    dateElement.SendKeys(Keys.Tab);

                    break;
                }
                catch (StaleElementReferenceException)
                {
                    attempts++;
                    Logger.Warning($"StaleElementReferenceException encountered. Retry attempt {attempts}");
                }
            }
        }

        public void SelectFromDropdown(By element, string value)
        {
            Logger.Information($"Selecting '{value}' from dropdown {element}");
            var dropdown = Wait.Until(ExpectedConditions.ElementToBeClickable(element));

            Actions actions = new Actions(Driver);
            actions.MoveToElement(dropdown).Click().Build().Perform();

            var option = dropdown.FindElements(By.TagName("option"))
                                 .FirstOrDefault(o => o.Text.Trim() == value);
            option.Click();
        }

        public void WaitForElementToBeVisible(By element, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

        public void WaitForElementToBeClickable(By element, int timeoutInSeconds = 10)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public bool IsElementVisible(By element, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(ExpectedConditions.ElementIsVisible(element)).Displayed;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public bool IsElementClickable(By element, int timeoutInSeconds = 10)
        {
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }

        public void TakeScreenshot(string screenshotName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotDirectory);
                string filePath = Path.Combine(screenshotDirectory, $"{screenshotName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(filePath);
                Logger.Information($"Screenshot taken: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Error($"An error occurred while taking a screenshot: {ex.Message}");
            }
        }
    }
}
