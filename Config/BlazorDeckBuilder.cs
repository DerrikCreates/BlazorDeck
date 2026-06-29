using BlazorDeck.Components.Config;

namespace BlazorDeck.Config;

public class BlazorDeckBuilder
{
    private BlazorDeckConfig _blazorDeckConfig = new();

    public void AddPage(PageConfig page)
    {
        _blazorDeckConfig.BlazorDeckPages.Add(page);
    }

    public BlazorDeckConfig Build()
    {
        return _blazorDeckConfig;
    }
}