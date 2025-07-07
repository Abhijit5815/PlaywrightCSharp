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
    internal class HomePageTest : BaseTest
    {
        private HomePage _homePage;

        [SetUp]
        public async Task SetupTest()
        {
            // BaseTest already initializes _page — use it directly
            _homePage = new HomePage(_page);
            await _homePage.NavigateAsync(); // Optional if not already navigated in constructor
        }

        [Test]
        public async Task VerifyHomepageFlow()
        {
            await _homePage.ValidateTitleAsync();
            await _homePage.ValidateLinkAsync("A/B Testing", "/abtest");
            await _homePage.ClickLinkAsync("A/B Testing");
            // await _homePage.ValidateIntroUrlAsync(); // Uncomment when method is ready
        }

    }
}
