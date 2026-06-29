using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using BlazorDeck.Components.Config.ButtonTypes;
using BlazorDeck.Components.Config.States;
using BlazorDeck.Components.ExtentionMethods;
using BlazorDeck.Config.States;
using BlazorDeck.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Color = System.Drawing.Color;

namespace BlazorDeck.Components.Config;

public enum ButtonType
{
    Button,
    Slider,
    DragArea
}

public class DeckButtonConfig
{
    /// <summary>
    /// When state has been changed by us or another connected device
    /// </summary>
    [JsonIgnore]
    public Action OnStateChanged { get; set; } //TODO: pull out state related bs to someplace else.

    public string Text { get; set; }
    public string TextColor { get; set; } = Color.White.ToHex();

    public Align TextAlign { get; set; } = Align.Center;

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid StreamerBotActionId { get; set; }

    public ButtonType ButtonType { get; set; }

    public string BackgroundColor { get; set; } = Color.FromArgb(31, 29, 39).ToHex();

    public string ForegroundColor { get; set; } = Color.FromArgb(36, 68, 171).ToHex();
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

  

    
}