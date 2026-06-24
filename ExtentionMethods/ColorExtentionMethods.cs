using System.Drawing;

namespace BlazorDeck.Components.ExtentionMethods;

public static class ColorExtentionMethods
{
   public static string ToHex(this Color c)
    {
        return $"#{c.R:X2}{c.G:X2}{c.B:X2}";
    }
}