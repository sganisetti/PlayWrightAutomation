using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_TestProject.PlayWrightWithNUnit
{
    public class LoginToORMWithPlayWright :PageTest
    {
        [Test]
        public async Task LoginHrm()
        {
            await Page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
            //ILocator username = Page.GetByRole(AriaRole.Textbox, new() { Name = "username" });
            // ILocator password = Page.GetByRole(AriaRole.Textbox, new() { Name = "password" });
            // ILocator login_btn = Page.GetByRole(AriaRole.Button, new() { Name = " submit"});
            ILocator username = Page.GetByPlaceholder("Username");
            ILocator password = Page.GetByPlaceholder("Password");
            ILocator login_btn = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await username.FillAsync("admin");
            await password.FillAsync("admin123");
            await login_btn.ClickAsync();
        }
    }
}
