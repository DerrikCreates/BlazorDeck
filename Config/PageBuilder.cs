using BlazorDeck.Components.Config;
using BlazorDeck.Components.ExtentionMethods;
using MudBlazor;
using Color = System.Drawing.Color;

namespace BlazorDeck.Config;

public class PageBuilder
{
    private PageConfig _config;

    public PageBuilder()
    {
        _config = new();
        _config.Id = Guid.NewGuid();
    }

    public PageBuilder PageSize(int x, int y)
    {
        _config.GridSizeX = x;
        _config.GridSizeY = y;

        return this;
    }


    public PageConfig Build()
    {
        return _config;
    }


    public PageConfig BuildDemo1()
    {
        _config.Id = new Guid("0f0c3e41-1746-4115-9b8d-73479312e2e5");
        var button1 = new ButtonBuilder()
            .DefinePressButton(0, 200, Color.Blue.ToHex())
            .StreamerBotAction(new Guid("2b8750c1-38ba-4564-8daa-1d6afa79d86c"))
            .Size(1, 1)
            .SetText("Button 1")
            .Position(1, 1);

        _config.Buttons.Add(button1.Build());

        var button2 = new ButtonBuilder()
            .DefinePressButton(1000, 0, "")
            .StreamerBotAction(new Guid("38eb0d7a-17e3-4651-93fc-a7aa5eee9d8f"))
            .InteractColor(Color.FromArgb(25, 127, 236).ToHex())
            .Position(1, 2)
            .Size(1, 1)
            .SetText("Button 2");
        _config.Buttons.Add(button2.Build());

        var button3 = new ButtonBuilder()
            .DefinePressButton(1000, 0, "", new Guid("bc862ef4-a046-41ff-97eb-3b974be72276"))
            .InteractColor(Color.FromArgb(25, 127, 236).ToHex())
            .Position(1, 2)
            .Size(1, 1)
            .SetText("Page 2");
        _config.Buttons.Add(button3.Build());

        var slider1 = new ButtonBuilder()
            .DefineSlider(true)
            .StreamerBotAction(new Guid("f7a567db-bf60-40bc-9ca5-a29e5a9ebb73"))
            .Position(2, 1)
            .Size(1, 4)
            .SetText("Slider");
        _config.Buttons.Add(slider1.Build());

        var area1 = new ButtonBuilder()
            .DefineArea()
            .Position(4, 1)
            .Size(4, 4)
            .SetText("Drag Area")
            .StreamerBotAction(new Guid("a31bb086-3e9c-4a18-b5c7-fece29665b69"));
        _config.Buttons.Add(area1.Build());

        return _config;
    }

    public PageConfig BuildDemo2()
    {
        _config.Id = new Guid("bc862ef4-a046-41ff-97eb-3b974be72276");
        var button1 = new ButtonBuilder()
            .DefinePressButton(1000, 0, "", new Guid("0f0c3e41-1746-4115-9b8d-73479312e2e5"))
            .InteractColor(Color.FromArgb(25, 127, 236).ToHex())
            .Position(1, 4)
            .Size(1, 1)
            .SetText("Main Page");
        _config.Buttons.Add(button1.Build());

        var button2 = new ButtonBuilder()
            .DefinePressButton(0, 100, "")
            .SetText("Page 2 Button")
            .StreamerBotAction(new Guid("76b8fdf3-d546-42e9-bf33-ee53ae5fa032"))
            .Size(1, 1)
            .Position(1, 1);
        _config.Buttons.Add(button2.Build());

        return _config;
    }
}