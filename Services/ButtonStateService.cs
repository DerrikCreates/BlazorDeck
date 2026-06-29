using BlazorDeck.Components.Config;
using BlazorDeck.Components.Config.States;
using BlazorDeck.Config.States;

namespace BlazorDeck.Services;

public class ButtonStateService
{
    public Dictionary<Guid, StateBase> State { get; private set; } = [];

    public bool TryGetState<T>(Guid id, out T state)
    {
        if (State.TryGetValue(id, out var b))
        {
            if (b is T cast)
            {
                state = cast;
                return true;
            }
        }

        state = default(T);
        return false;
    }

    public void CreateState(Guid id, ButtonType type)
    {
        switch (type)
        {
            //TODO: check if the type of the button has changed,
            // if it has remove the old state and create new 
            case ButtonType.Button:
                var btn = new PressButtonState();
                State.TryAdd(id, btn);
                break;
            case ButtonType.Slider:
                var slider = new SliderState();
                State.TryAdd(id, slider);
                break;
            case ButtonType.DragArea:
                State.TryAdd(id, new DragAreaState());
                break;
        }
    }
}