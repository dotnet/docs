// <EventProperties>
using System.ComponentModel;

public class StrokeEventArgs(int x, int y) : EventArgs
{
    public int X { get; } = x;
    public int Y { get; } = y;
}

// The class DrawingCanvas defines two event properties, StrokeStarted and StrokeEnded.
class DrawingCanvas
{
    // Define the delegate collection.
    protected EventHandlerList listEventDelegates = new EventHandlerList();

    // Define a unique key for each event.
    static readonly object strokeStartedEventKey = new object();
    static readonly object strokeEndedEventKey = new object();

    // Define the StrokeStarted event property.
    public event EventHandler<StrokeEventArgs> StrokeStarted
    {
        add { listEventDelegates.AddHandler(strokeStartedEventKey, value); }
        remove { listEventDelegates.RemoveHandler(strokeStartedEventKey, value); }
    }

    protected virtual void OnStrokeStarted(StrokeEventArgs e)
    {
        EventHandler<StrokeEventArgs>? strokeEventDelegate =
            (EventHandler<StrokeEventArgs>?)listEventDelegates[strokeStartedEventKey];
        strokeEventDelegate?.Invoke(this, e);
    }

    // Define the StrokeEnded event property.
    public event EventHandler<StrokeEventArgs> StrokeEnded
    {
        add { listEventDelegates.AddHandler(strokeEndedEventKey, value); }
        remove { listEventDelegates.RemoveHandler(strokeEndedEventKey, value); }
    }

    protected virtual void OnStrokeEnded(StrokeEventArgs e)
    {
        EventHandler<StrokeEventArgs>? strokeEventDelegate =
            (EventHandler<StrokeEventArgs>?)listEventDelegates[strokeEndedEventKey];
        strokeEventDelegate?.Invoke(this, e);
    }
}
// </EventProperties>
