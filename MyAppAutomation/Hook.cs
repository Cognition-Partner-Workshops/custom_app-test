using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace MyAppAutomation
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        public static IWebDriver Driver { get; private set; }

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                TakeScreenshot(_scenarioContext.ScenarioInfo.Title);
            }

            Driver?.Quit();
            Driver = null;
        }

        private void TakeScreenshot(string scenarioTitle)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var sanitizedTitle = string.Join("_", scenarioTitle.Split(Path.GetInvalidFileNameChars()));
                var screenshotDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
                Directory.CreateDirectory(screenshotDir);
                var filePath = Path.Combine(screenshotDir, $"{sanitizedTitle}_{timestamp}.png");
                screenshot.SaveAsFile(filePath);
            }
            catch (Exception)
            {
                // Silently handle screenshot failures to avoid masking the actual test error
            }
        }
    }
}
