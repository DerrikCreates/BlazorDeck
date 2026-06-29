using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

public class ClientInputInterop : IAsyncDisposable
{
    public Action<PointerEventArgs> OnPointerDown { get; set; }
    public Action<PointerEventArgs> OnPointerUp { get; set; }
    public Action<PointerEventArgs> OnPointerMove { get; set; }

    private IJSRuntime JS { get; set; }
    private IJSObjectReference? _module;
    private DotNetObjectReference<Callbacks> _dotNetObjectReference;

    private Callbacks _callbacks;

    public ClientInputInterop(IJSRuntime js)
    {
        JS = js;
    }

    public async Task Init()
    {
        _callbacks = new(this);
        _module ??= await JS.InvokeAsync<IJSObjectReference>(
            "import", "./js/input.js");
        _dotNetObjectReference = DotNetObjectReference.Create(_callbacks);
        _module.InvokeVoidAsync("setup", _dotNetObjectReference);
        Console.WriteLine("JSInputInterop Init done");
    }


    public async ValueTask DisposeAsync()
    {
        Console.WriteLine("INPUT INTEROP DISPOSED");
        _dotNetObjectReference.Dispose();
        await _module.DisposeAsync();
    }

    public class Callbacks
    {
        private readonly ClientInputInterop _interop;

        public Callbacks(ClientInputInterop interop)
        {
            _interop = interop;
        }

        [JSInvokable]
        public void PointerDown(PointerEventArgs down)
        {
            _interop.OnPointerDown?.Invoke(down);
        }

        [JSInvokable]
        public void PointerUp(PointerEventArgs up)
        {
            _interop.OnPointerUp?.Invoke(up);
        }

        [JSInvokable]
        public void PointerMove(PointerEventArgs move)
        {
            _interop.OnPointerMove?.Invoke(move);
        }
    }

    public class PointerEvent
    {
        public double ClientX { get; set; }
        public double ClientY { get; set; }
        public double PointerId { get; set; }
        public string PointerType { get; set; }
    }
}