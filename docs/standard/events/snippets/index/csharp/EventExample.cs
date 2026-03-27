namespace EventsOverview;

// <DefineEvent>
class Counter
{
    public event EventHandler? ThresholdReached;

    protected virtual void OnThresholdReached(EventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }

    // Provide remaining implementation for the class...
}
// </DefineEvent>

// <EventDataClass>
public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}
// </EventDataClass>

// <CustomDelegate>
public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);
// </CustomDelegate>
