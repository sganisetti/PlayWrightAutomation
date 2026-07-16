using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_TestProject.Helpers
{
    public  class BasePage
    {
        protected readonly IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }

        protected async Task Click(ILocator locator)
        {
            await locator.ClickAsync();
        }

        protected async Task FillText(ILocator locator, string text)
        {
            await locator.FillAsync(text);
        }
    }
}
