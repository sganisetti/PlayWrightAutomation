using Microsoft.Playwright;
using Playwright_TestProject.Pages;
using System.Runtime.InteropServices;
using System.Text.Unicode;

namespace Playwright_TestProject.Tests
{
    public class Tests
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _browsercontext;
        private IPage page;
        [SetUp]
        public async Task Setup()
        {
            _playwright = await Playwright.CreateAsync();

            _browser = await _playwright.Chromium.LaunchAsync(
                new BrowserTypeLaunchOptions
                {
                    Headless = false
                }


            );

            _browsercontext = await _browser.NewContextAsync();
            page = await _browsercontext.NewPageAsync();
            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");


        }

        [Test]

        public async Task LoginTest()
        {
            LoginPage login = new LoginPage(page);
           await login.Login("Admin", "admin123");
        }


        [Test]

        public async Task LoginTestWithListeners()
        {
            var request = page.WaitForRequestAsync(x => x.Url.Contains("login") && x.Method == "GET");
            var responseTask = page.WaitForResponseAsync(x => x.Url.Contains("/dashboard/index"));
            LoginPage login = new LoginPage(page);
            await login.Login("Admin", "admin123");
            var response = await responseTask;
            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(response.Ok, Is .True);
            var contentType = await response.HeaderValuesAsync("content-type");
            Assert.That(contentType, Does.Contain("text/html; charset=UTF-8"));






        }


        [Test]
        public async Task Test1()
        {
            // Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            //page

            var page = await browser.NewPageAsync();
            await page.GotoAsync("http://eaapp.somee.com/");
            await page.ClickAsync("text = Login");
            await page.ScreenshotAsync(new PageScreenshotOptions
            {

                Path = "Eaapp.jpg"

            });
            //first Tc
        }
    }
}
