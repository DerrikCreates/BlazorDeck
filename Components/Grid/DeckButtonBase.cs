using System.Security.Cryptography;
using BlazorDeck.Components.Config;
using BlazorDeck.Components.Config.States;
using BlazorDeck.Services;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using StreamerbotClient;

public abstract class DeckButtonBase : ComponentBase
{
    //TODO: i dont like being required to pass in configs
    // to the buttons like this. its fine for what im doing rn, but
    // it makes these components hard to use standalone
    [Parameter] public PageConfig PageConfig { get; set; }
    [Parameter] public DeckButtonConfig DeckButtonConfig { get; set; }

    [Inject] public ButtonStateService ButtonStateService { get; set; }

    protected StateBase ButtonState;

    protected override async Task OnParametersSetAsync()
    {
        if (!ButtonStateService.TryGetState(DeckButtonConfig.Id, out ButtonState))
        {
            ButtonStateService.CreateState(DeckButtonConfig.Id, DeckButtonConfig.ButtonType);
            ButtonStateService.TryGetState(DeckButtonConfig.Id, out ButtonState);
        }

        await base.OnParametersSetAsync();
    }


    public abstract void ActivateButtonAction(params KeyValuePair<string, object>[] args);

    public string GridStyle { get; set; }


    public void CaculateGridPos()
    {
        var gridColumn = $"{DeckButtonConfig.X} / {DeckButtonConfig.X + DeckButtonConfig.Width}";
        var gridRow = $"{DeckButtonConfig.Y} / {DeckButtonConfig.Y + DeckButtonConfig.Height}";
        GridStyle = $"grid-column:{gridColumn}; grid-row:{gridRow};";
    }

//TODO: for the love of god come back and change this
    // treating this like a game engine update has to be wrong
}