using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests.SomeSanityTest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class SanityTests : PageTest
    {
        [Test]
        [Category("Sanity")]
        public async Task Should_Open_HomePage_And_Show_Title()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Verify title contains "Playwright"
            var title = await Page.TitleAsync();
            Assert.That(title, Does.Contain("Playwright"));
        }

        [Test]
        [Category("Sanity")]
        public async Task Should_Have_Visible_GetStarted_Link()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Check if "Get Started" link is visible
            await Expect(Page.Locator("a", new() { HasTextString = "Get started" }))
                .ToBeVisibleAsync();
        }

        [Test]
        public async Task NonSanity_Test_NotIncluded()
        {
            await Page.GotoAsync("https://example.com");

            // Just a dummy check
            Assert.That(await Page.InnerTextAsync("h1"), Does.Contain("Example Domain"));
        }
    }
}