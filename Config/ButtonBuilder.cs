using System.Drawing;
using BlazorDeck.Components.Config;
using BlazorDeck.Components.Config.ButtonTypes;
using BlazorDeck.Components.ExtentionMethods;
using MudBlazor;
using ButtonType = BlazorDeck.Components.Config.ButtonType;
using Color = System.Drawing.Color;

namespace BlazorDeck.Config;

public class ButtonBuilder
{
    private DeckButtonConfig _button;

    public ButtonBuilder()
    {
        _button = new();
        _button.Id = Guid.NewGuid();
    }

    public ButtonBuilder SetText(string text, string color = "#fff", Align align = Align.Center)
    {
        _button.Text = text;
        _button.TextAlign = align;
        _button.TextColor = color;
        return this;
    }


    public ButtonBuilder Position(int x, int y)
    {
        _button.X = x;
        _button.Y = y;
        return this;
    }

    public ButtonBuilder Size(int width, int height)
    {
        _button.Width = width;
        _button.Height = height;
        return this;
    }

    public ButtonBuilder Type(ButtonType type)
    {
        _button.ButtonType = type;
        return this;
    }

    public ButtonBuilder StreamerBotAction(Guid id)
    {
        _button.StreamerBotActionId = id;
        return this;
    }

    public ButtonBuilder ForegroundColor(string hex)
    {
        _button.ForegroundColor = hex;
        return this;
    }

    public ButtonBuilder BackgroundColor(string hex)
    {
        _button.BackgroundColor = hex;
        return this;
    }

    public ButtonBuilder InteractColor(string hex)
    {
        _button.InteractColor = hex;
        return this;
    }

    public ButtonBuilder DefineSlider(bool vertical)
    {
        _button.ButtonType = ButtonType.Slider;
        SetConfig(new SliderConfig() { Vertical = vertical });
        return this;
    }

    public ButtonBuilder DefinePressButton(int activateTimeMS, int cooldownMS, string readyColorHex,
        Guid pageId = new Guid())
    {
        _button.ButtonType = ButtonType.Button;
        var config = new PressButtonConfig()
        {
            ActivateTime = activateTimeMS,
            ActivateReadyColor = readyColorHex,
            ButtonCooldown = cooldownMS
        };

        if (pageId != Guid.Empty)
        {
            config.PageToSwapTo = pageId;
        }

        SetConfig(config);
        return this;
    }

    public ButtonBuilder DefineArea()
    {
        _button.ButtonType = ButtonType.DragArea;
        SetConfig(new DragAreaConfig());
        return this;
    }

    public ButtonBuilder SetConfig(ButtonConfigBase config)
    {
        _button.Config = config;
        return this;
    }

    public DeckButtonConfig Build()
    {
        return _button;
    }
}