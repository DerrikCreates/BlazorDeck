using System.Drawing;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using BlazorDeck.Components.ExtentionMethods;

namespace BlazorDeck.Components.Config;

public enum ButtonType
{
    Button,
    Slider
}

public class ButtonConfig
{
    [JsonIgnore] public Action OnStateChanged { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();

    public ButtonType ButtonType { get; set; }

    public string BackgroundColor { get; set; } = Color.Black.ToHex();

    public string ForegroundColor { get; set; } = Color.FromArgb(26, 95, 216).ToHex();

    public JsonObject Config { get; set; } = new JsonObject();
    [JsonIgnore] public JsonObject State { get; set; } = new();

    public int X { get; set; }
    public int Y { get; set; }

    public int Width { get; set; }
    public int Height { get; set; }
}