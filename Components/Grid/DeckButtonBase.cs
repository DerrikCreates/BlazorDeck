using System.Security.Cryptography;
using BlazorDeck.Components.Config;
using BlazorDeck.Services;
using Microsoft.AspNetCore.Components;
using StreamerbotClient;

public abstract class DeckButtonBase : ComponentBase
{
    [Parameter] public PageConfig PageConfig { get; set; }
    [Parameter] public DeckButtonConfig DeckButtonConfig { get; set; }



    public abstract void ActivateButtonAction(params KeyValuePair<string, object>[] args);


    protected override async Task OnInitializedAsync()
    {
    }

    //TODO: for the love of god come back and change this
    // treating this like a game engine update has to be wrong
}