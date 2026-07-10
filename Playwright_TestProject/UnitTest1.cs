using Microsoft.Playwright;

namespace Playwright_TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
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
            await page.ScreenshotAsync(new PageScreenshotOptions {
                
                Path =  "Eaapp.jpg"
            
            });
// first Tc
        }
    }
}
