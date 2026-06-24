export function setup(dotnet) {

    window.addEventListener("pointerdown", e => {
            console.log(e)


            dotnet.invokeMethodAsync("PointerDown", buildMessage(e))
        }
    );

    window.addEventListener("pointermove", e => {
            dotnet.invokeMethodAsync("PointerMove", buildMessage(e))
        }
    );

    window.addEventListener("pointerup", e => {
            dotnet.invokeMethodAsync("PointerUp", buildMessage(e))
        }
    );

    function buildMessage(e) {
        return {
            ClientX: e.clientX,
            ClientY: e.clientY,
            PointerId: e.pointerId,
            PointerType: e.pointerType
        }
    }
}