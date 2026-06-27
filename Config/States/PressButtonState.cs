namespace BlazorDeck.Components.Config.States;

public class PressButtonState : StateBase
{
    public bool IsHeld { get; set; }
    public bool CanBeActivated { get; set; }

    public bool IsOnCooldown => CooldownEndTime > DateTime.UtcNow;

    public double CooldownRemainingPercent
    {
        get
        {
            return
                double.Clamp((DateTime.UtcNow - CooldownStartTime).TotalSeconds /
                             (CooldownEndTime - CooldownStartTime).TotalSeconds, 0, 1);
        }
    }

    public DateTime CooldownEndTime { get; set; } = DateTime.Now.Subtract(TimeSpan.FromDays(365));
    public DateTime CooldownStartTime { get; set; } = DateTime.Now.Subtract(TimeSpan.FromDays(365));
    public int CurrentHoldTime { get; set; }
}