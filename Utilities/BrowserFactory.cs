using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCsharp.Utilities
{
    internal class BrowserFactory
    {
       public static async Task<IBrowser> LaunchAsync(
       IPlaywright playwright,
       string browserName = "chromium",
       bool headless = false,
       string[]? args = null)
        {
            var launchOptions = new BrowserTypeLaunchOptions
            {
                Headless = headless,
                Args = args ?? new[] { "--start-maximized" }
            };

            IBrowser browser = browserName.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(launchOptions),
                "firefox" => await playwright.Firefox.LaunchAsync(launchOptions),
                "webkit" => await playwright.Webkit.LaunchAsync(launchOptions),
                _ => throw new ArgumentException($"Unsupported browser: {browserName}")
            };
            return browser; // Return browser for global use
        }
    }
}
