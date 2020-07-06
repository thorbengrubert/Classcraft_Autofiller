using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;

namespace CC_Autofiller
{
    public sealed class Selenium
    {
        private static IWebDriver driver;
        private int processID;
        private static readonly Selenium instance = new Selenium();

        public IWebDriver Driver { get => driver; set => driver = value; }
        public int ProcessId { get => processID; set => processID = value; }


        // Explicit static constructor to tell the C# compiler
        // not to mark type as beforefieldinit
        static Selenium()
        {
        }

        private Selenium()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
            firefoxDriverService.HideCommandPromptWindow = true;
            FirefoxOptions options = new FirefoxOptions();
            //include if no visualization is needed.
            //options.AddArguments("--headless");
            FirefoxProfileManager profileManager = new FirefoxProfileManager();
            FirefoxProfile profileF = new FirefoxProfile();
            options.Profile = profileF;
            //include to speed up page loading by disabling image loading
            //options.Profile.SetPreference("permissions.default.image", 2);
            driver = new FirefoxDriver(firefoxDriverService, options);

            var firefoxService = FirefoxDriverService.CreateDefaultService();
            ProcessId = firefoxService.ProcessId;
        }

        public static Selenium Instance
        {
            get
            {
                return instance;
            }
        }

        public void LogIn(string username, string password)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            Instance.Driver.Navigate().GoToUrl("https://accounts.classcraft.com/login/");

            var openLoginUIButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("//button[@class='Button']")));
            openLoginUIButton.Click();

            // Get the login page elements
            var usernameField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath("//input[@id='input:username']")));
            var passwordField = Instance.Driver.FindElement(By.XPath("//input[@id='password']"));

            // Type user name and password
            usernameField.SendKeys(username);
            passwordField.SendKeys(password);
            passwordField.SendKeys(Keys.Return);

            //Nagivate "Firefox Incompatible - Continue Anyway" Screen
            var continueAnywayButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@class='Button Button--color-xp']")));
            continueAnywayButton.Click();
        }

        public void SelectClassInCC(string selectedClass)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;

            var playButtonSelectedClass = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath($"//div[contains(text(),'{selectedClass}')]/../../div[@class='ButtonWrapper PlayButton outline upper bolder']")));

            //Necessary since the "Play"-Button for the chosen class is often offscreen.
            (jsDriver).ExecuteScript("arguments[0].scrollIntoView(true);", playButtonSelectedClass);
            //Waiting since loading and scrolling may take some time
            System.Threading.Thread.Sleep(3000);

            playButtonSelectedClass.Click();
        }

        public void AwardExp(string username, string symbolGrade)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;

            switch (symbolGrade)
            {
                case "-":
                case "O":
                case "+":
                case "++":
                    var selectedPlayer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                        By.XPath($"//div[starts-with(text(),'{username}')]")));
                    (jsDriver).ExecuteScript("arguments[0].scrollIntoView(true);", selectedPlayer);
                    //System.Threading.Thread.Sleep(3000);
                    selectedPlayer.Click();

                    var awardExpButton = Instance.Driver.FindElement(By.XPath("//*[@class='Icon plus']"));
                    awardExpButton.Click();

                    var symbolGradeButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                        By.XPath($"//div[contains(text(),'(+)')]/ancestor::div[contains(concat(' ', @class, ' '), 'Card BehaviorCard hover')]")));
                    symbolGradeButton.Click();

                    //In case "X"-Button must be pressed to close the "award exp" window
                    //var exitAwardExpButton = Instance.Driver.FindElement(By.XPath("//div[@id='closeModal']"));
                    //exitAwardExpButton.Click();
                    break;
                default:
                    break;
            }

        }

        public void AwardExp(string username, string expFlat, string expDescription)
        {
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            IJavaScriptExecutor jsDriver = (IJavaScriptExecutor)driver;


            var selectedPlayer = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath($"//div[starts-with(text(),'{username}')]")));
            (jsDriver).ExecuteScript("arguments[0].scrollIntoView(true);", selectedPlayer);
            //System.Threading.Thread.Sleep(3000);
            selectedPlayer.Click();

            var awardExpButton = Instance.Driver.FindElement(By.XPath("//*[@class='Icon plus']"));
            awardExpButton.Click();

            var expInputField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(
                By.XPath($"//input[@id='customValue']")));
            expInputField.SendKeys(expFlat);

            var expDescriptionInputField = Instance.Driver.FindElement(By.XPath($"//input[@id='customDescription']"));
            expDescriptionInputField.SendKeys(expDescription);

            var applyExpButton = Instance.Driver.FindElement(By.XPath("//div[@id='confirmCustomValueBtn']"));
            applyExpButton.Click();

            //In case "X"-Button has to be pressed to close the "award exp" window
            //var exitAwardExpButton = Instance.Driver.FindElement(By.XPath("//div[@id='closeModal']"));
            //exitAwardExpButton.Click();
        }

        public void FinishSession()
        {
            //"log out"-functionality could be implemented here
            Instance.Driver.Navigate().GoToUrl("https://accounts.classcraft.com/logout");
            Instance.Driver.Quit();
            try
            {
                Process.GetProcessById(ProcessId).Kill();
            }
            catch (Exception)
            {
                //throw ex;
            }
        }

        public string GetHtmlStringForUrl(string url)
        {
            Instance.Driver.Navigate().GoToUrl(url);

            string pageSourceString = Instance.Driver.PageSource;
            return pageSourceString;
        }
    }
}
