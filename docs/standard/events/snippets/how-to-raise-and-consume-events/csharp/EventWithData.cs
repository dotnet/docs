// <ThresholdReachedWithData>
class EventWithData
{
    static void Main()
    {
        CounterWithData c = new(new Random().Next(10));
        // <SubscribeEvent2>
        c.ThresholdReached += c_ThresholdReached;
        // </SubscribeEvent2>

        Console.WriteLine("press 'a' key to increase total");
        while (Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine("adding one");
            c.Add(1);
        }
    }

    // <HandleEvent2>
    static void c_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
    {
        Console.WriteLine($"The threshold of {e.Threshold} was reached at {e.TimeReached}.");
        Environment.Exit(0);
    }
    // </HandleEvent2>
}

class CounterWithData(int passedThreshold)
{
    private readonly int _threshold = passedThreshold;
    private int _total;

    public void Add(int x)
    {
        _total += x;
        // <RaiseEvent2>
        if (_total >= _threshold)
        {
            ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
            args.Threshold = _threshold;
            args.TimeReached = DateTime.Now;
            OnThresholdReached(args);
        }
        // </RaiseEvent2>
    }

    // <RaiseEventMethod2>
    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
    // </RaiseEventMethod2>

    // <DeclareEvent2>
    public event EventHandler<ThresholdReachedEventArgs>? ThresholdReached;
    // </DeclareEvent2>
}

// <EventDataClass2>
public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}
// </EventDataClass2>
// </ThresholdReachedWithData>
