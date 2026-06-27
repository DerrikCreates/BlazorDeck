using System.Drawing;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using BlazorDeck.Components.Config.ButtonTypes;
using BlazorDeck.Components.Config.States;
using BlazorDeck.Components.ExtentionMethods;
using BlazorDeck.Config.States;
using BlazorDeck.Services;

namespace BlazorDeck.Components.Config;

public enum ButtonType
{
    Button,
    Slider
}

public class DeckButtonConfig
{
    /// <summary>
    /// When state has been changed by us or another connected device
    /// </summary>
    [JsonIgnore]
    public Action OnStateChanged { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid StreamerBotActionId { get; set; }

    public ButtonType ButtonType { get; set; }

    public string BackgroundColor { get; set; } = Color.Black.ToHex();

    public string ForegroundColor { get; set; } = Color.FromArgb(26, 95, 216).ToHex();
    public string InteractColor { get; set; } = Color.DarkRed.ToHex();

    public ButtonConfigBase Config { get; set; }


    public int X { get; set; } = 1;
    public int Y { get; set; } = 1;

    public int Width { get; set; } = 1;
    public int Height { get; set; } = 1;

    private JsonSerializerOptions _serializerOptions = new()
    {
        WriteIndented = true,
    };

    private ButtonStateService _buttonStateService;

    public void Setup(ButtonStateService buttonStateService)
    {
        _buttonStateService = buttonStateService;
        buttonStateService.CreateState(Id, ButtonType);
    }

    public T GetState<T>() where T : StateBase
    {
        // i dont like it but cant explain why.
        // everything about this file feels alittle off
        _buttonStateService.TryGetState<T>(Id, out var state);
        return state;
    }
}