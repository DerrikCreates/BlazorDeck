using System.Text.Json.Serialization;

namespace BlazorDeck.Components.Config;

public class PageConfig
{
    [JsonIgnore] public Action OnStateChanged { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public int GridSizeX { get; set; }
    public int GridSizeY { get; set; }
    public List<ButtonConfig> Buttons { get; set; }
}