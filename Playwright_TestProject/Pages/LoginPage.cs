using Microsoft.Playwright;
using Playwright_TestProject.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Playwright_TestProject.Pages
{
    public class LoginPage :BasePage
    {
       
        public LoginPage(IPage page) :base(page)
        {
            
        }

        private ILocator txtUsername => Page.GetByPlaceholder("Username");
        private ILocator txtPassword => Page.GetByPlaceholder("Password");

        private ILocator loginBtn => Page.GetByRole(AriaRole.Button, new() { Name = "Login"});


        public async Task Login(string username, string password)
        {
            await FillText(txtUsername, username);
            await FillText(txtPassword, password);
            await Click(loginBtn);
        }


    }
}
