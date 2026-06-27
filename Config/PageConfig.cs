using System.Text.Json.Serialization;
using BlazorDeck.Services;

namespace BlazorDeck.Components.Config;

public class PageConfig
{
    [JsonIgnore] public Action OnStateChanged { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int GridSizeX { get; set; }
    public int GridSizeY { get; set; }
    public List<DeckButtonConfig> Buttons { get; set; } = [];

    public void Setup( ButtonStateService buttonStateService)
    {
        foreach (var button in Buttons)
        {
            
            button.Setup(buttonStateService);
        }
    }
}