using Microsoft.Playwright;
using System.Text.RegularExpressions;
using static Microsoft.Playwright.Assertions;


namespace PlaywrightCsharp.Pages
{
    internal class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page)
        {
            _page = page ?? throw new ArgumentNullException(nameof(page));
        }
        public async Task NavigateAsync()
        {
            await _page.GotoAsync("https://playwright.dev");
        }

        public async Task ValidateTitleAsync()
        {
            await Expect(_page).ToHaveTitleAsync(new Regex("Playwright"));
        }
        public async Task ValidateGetStartedLinkAsync()
        {
            var getStarted = _page.Locator("text=Get Started");
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");
        }

        public async Task ClickGetStartedAsync()
        {
            await _page.Locator("text=Get Started").ClickAsync();
        }

        public async Task ValidateIntroUrlAsync()
        {
            await Expect(_page).ToHaveURLAsync(new Regex(".*intro"));
        }

    }
}
