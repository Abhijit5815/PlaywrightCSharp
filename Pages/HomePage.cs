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
            await _page.GotoAsync("http://the-internet.herokuapp.com/");
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshots/url.png" });
        }

        public async Task ValidateTitleAsync()
        {
            await Expect(_page).ToHaveTitleAsync(new Regex("The Internet"));
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = "screenshots/title.png" });
        }
        public async Task ValidateLinkAsync(string link,string href)
        {
            var getStarted = _page.Locator("text="+ link);
            await Expect(getStarted).ToHaveAttributeAsync("href", href);
        }

        public async Task ClickLinkAsync(string link)
        {
            await _page.Locator("text="+link).ClickAsync();
        }

        public async Task ValidateIntroUrlAsync()
        {
            await Expect(_page).ToHaveURLAsync(new Regex(".*intro"));
        }

    }
}
