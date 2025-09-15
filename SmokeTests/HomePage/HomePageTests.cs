using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightTests.SmokeTests.HomePage
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class HomePageTests : PageTest
    {
        [Test]
        public async Task HomePage_HasLogo()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect the logo to be visible
            await Expect(Page.Locator(".navbar__brand")).ToBeVisibleAsync();
        }

        [Test]
        public async Task HomePage_SearchFunctionality()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Click the search button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();

            // Fill the search input
            await Page.Locator("#docsearch-input").FillAsync("C#");

            // Expect to see search results
            await Expect(Page.Locator(".DocSearch-Hit-Container").First).ToBeVisibleAsync(new() { Timeout = 5000 });
        }
    }
}
