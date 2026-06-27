using System.Drawing;
using System.Text.Json.Serialization;
using BlazorDeck.Components.ExtentionMethods;

namespace BlazorDeck.Components.Config.ButtonTypes;
public class SliderConfig : ButtonConfigBase
{
    public bool Vertical { get; set; }
}