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
        public static async Task<IBrowser> LaunchAsync(IPlaywright playwright, string browserName = "chromium", bool headless = false)
        {
            return browserName.ToLower() switch
            {
                "chromium" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }),
                "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }),
                "webkit" => await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless }),
                _ => throw new ArgumentException($"Unsupported browser: {browserName}")
            };
        }
    }
}
