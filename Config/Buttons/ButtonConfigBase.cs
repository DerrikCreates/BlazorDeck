using System.Text.Json.Serialization;

namespace BlazorDeck.Components.Config.ButtonTypes;

[JsonDerivedType(typeof(PressButtonConfig), (int)ButtonType.Button)]
[JsonDerivedType(typeof(SliderConfig), (int)ButtonType.Slider)]
[JsonPolymorphic]
public class ButtonConfigBase
{
}