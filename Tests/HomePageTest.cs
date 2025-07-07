using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightCsharp.Pages;
using PlaywrightCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCsharp.Tests
{
    internal class HomePageTest
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        private IBrowserContext _context;
        private IPage _page;
        private HomePage _homePage;

        [SetUp]
        public async Task Init()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await BrowserFactory.LaunchAsync(_playwright, browserName: "chromium", headless: false);
            _context = await _browser.NewContextAsync();
            _page = await _context.NewPageAsync();

            _homePage = new HomePage(_page); // Plug in your page object
        }

        [Test]
        public async Task VerifyHomepageFlow()
        {
            await _homePage.NavigateAsync();
            await _homePage.ValidateTitleAsync();
            await _homePage.ValidateGetStartedLinkAsync();
            await _homePage.ClickGetStartedAsync();
            await _homePage.ValidateIntroUrlAsync();
        }

        [TearDown]
        public async Task Cleanup()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }


    }
}
