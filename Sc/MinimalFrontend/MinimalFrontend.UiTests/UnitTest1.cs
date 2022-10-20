using Microsoft.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace MinimalFrontend.UiTests;

[TestFixture]
public class Tests : PageTest
{
    //private IPage page;
    [SetUp]
    public async Task Setup()
    {
        
    }

    [Test]
    public async Task Test1()
    {
        await Page.GotoAsync("https://localhost:1443/");
        await Page.Locator("text=Add new person").ClickAsync();
        await Page.Locator("[placeholder=\"name\"]").Nth(2).FillAsync("testnamenewuser");
        await Page.Locator("[placeholder=\"mail\"]").Nth(2).FillAsync("test@test.de");
        await Page.Locator("#TabPanelFour fluent-number-field [placeholder=\"age\"]").FillAsync("12");
        await Page.Locator("#TabPanelFour button").ClickAsync();
        
        await Expect(Page.Locator("[placeholder=\"name\"]").Nth(2)).ToBeEmptyAsync();
        
        //var dataGrid = Page.Locator("fluent-data-grid-cell");
       // Assert.Equals(11, dataGrid.CountAsync());
        //await Expect(Page.Locator("fluent-data-grid-cell")). ToHaveTextAsync("test@test.de");

        

    }
    
    [Test]
    public async Task Test2()
    {
        await Page.GotoAsync("https://localhost:1443/");
        await Page.Locator("text=Add new person").ClickAsync();
        await Page.Locator("[placeholder=\"name\"]").Nth(2).FillAsync("testnamenewuser");
        await Page.Locator("[placeholder=\"mail\"]").Nth(2).FillAsync("testtest.de");
        await Page.Locator("#TabPanelFour fluent-number-field [placeholder=\"age\"]").FillAsync("12");
        await Page.Locator("#TabPanelFour button").ClickAsync();
        
        await Expect(Page.Locator("[placeholder=\"name\"]").Nth(2)).ToContainTextAsync("testnamenewuser");
        
        //var dataGrid = Page.Locator("fluent-data-grid-cell");
        // Assert.Equals(11, dataGrid.CountAsync());
        //await Expect(Page.Locator("fluent-data-grid-cell")). ToHaveTextAsync("test@test.de");

        

    }
}