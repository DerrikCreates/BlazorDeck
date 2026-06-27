using System.Drawing;
using System.Text.Json.Serialization;
using BlazorDeck.Components.ExtentionMethods;

namespace BlazorDeck.Components.Config.ButtonTypes;
public class PressButtonConfig : ButtonConfigBase
{
    public int ActivateTime { get; set; }
    public string ActivateReadyColor { get; set; } = Color.Blue.ToHex();
    public int ButtonCooldown { get; set; } = 1;
}