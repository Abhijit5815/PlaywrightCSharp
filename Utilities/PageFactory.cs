using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightCsharp.Utilities
{
    internal class PageFactory
    {
        public static async Task<IPage> CreatePageAsync(IBrowser browser, string? url = null, ViewportSize? viewport = null)
        {
            var contextOptions = new BrowserNewContextOptions();

            if (viewport != null)
                contextOptions.ViewportSize = viewport;

            var context = await browser.NewContextAsync(contextOptions);
            var page = await context.NewPageAsync();

            if (!string.IsNullOrEmpty(url))
                await page.GotoAsync(url);

            return page;
        }

    }
}
