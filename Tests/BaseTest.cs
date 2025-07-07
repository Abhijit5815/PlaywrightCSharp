using Microsoft.Playwright;
using PlaywrightCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCsharp.Tests
{
    internal class BaseTest
    {
        protected IBrowser _browser;
        protected IPage _page;
        protected IPlaywright _playwright;
        protected IBrowserContext _context;

        [SetUp]
        public async Task Init()
        {
            _playwright = await Playwright.CreateAsync();

            // Launch browser using custom args and optional viewport
            _browser = await BrowserFactory.LaunchAsync(
                _playwright,
                browserName: "chromium",
                headless: false,
                args: new[] { "--start-maximized" } // Or pass null for default
                
            );

            // Automatically detect scaled viewport from current display
            var viewport = ScreenHelper.GetScaledViewport();
            var scale = ScreenHelper.GetScaleFactor();

            Console.WriteLine($"Detected Screen Scale: {scale * 100}%");
            Console.WriteLine($"Scaled Viewport: {viewport.Width} x {viewport.Height}");

            _context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = viewport
            });


            // Create page in this context
            _page = await _context.NewPageAsync();
        }

        [TearDown]
        public async Task Cleanup()
        {
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
    }
