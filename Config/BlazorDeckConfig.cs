using System.Text.Json;
using BlazorDeck.Components.Config;

namespace BlazorDeck;

public class BlazorDeckConfig
{
    public List<PageConfig> BlazorDeckPages { get; set; }

    public void Save()
    {
        var opts = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText("./BlazorDeck.json", JsonSerializer.Serialize(this, opts));
    }
}