using System.Text.Json.Serialization;

namespace BlazorDeck.Components.Config.ButtonTypes;

[JsonDerivedType(typeof(PressButtonConfig), (int)ButtonType.Button)]
[JsonDerivedType(typeof(SliderConfig), (int)ButtonType.Slider)]
[JsonDerivedType(typeof(DragAreaConfig), (int)ButtonType.DragArea)]
[JsonPolymorphic]
public class ButtonConfigBase
{
}