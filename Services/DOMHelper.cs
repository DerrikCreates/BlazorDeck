using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor.Interop;

namespace BlazorDeck.Services;

public class DOMHelper
{
    private IJSObjectReference? _module;
    private IJSRuntime JS;

    public DOMHelper(IJSRuntime js)
    {
        JS = js;
    }

    public async Task Init()
    {
        _module ??= await JS.InvokeAsync<IJSObjectReference>(
            "import", "./js/helper.js");
    }

    public async Task<BoundingClientRect> GetBoundingClientRect(ElementReference element)
    {
        return await _module.InvokeAsync<BoundingClientRect>("getBoundingClientRect", element);
    }
}