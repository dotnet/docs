// <ThresholdReachedWithDelegate>
class EventWithDelegate
{
    static void Main()
    {
        CounterWithDelegate c = new(new Random().Next(10));
        // <SubscribeEventDelegate>
        c.ThresholdReached += c_ThresholdReached;
        // </SubscribeEventDelegate>

        Console.WriteLine("press 'a' key to increase total");
        while (Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine("adding one");
            c.Add(1);
        }
    }

    // <HandleEventDelegate>
    static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
    {
        Console.WriteLine($"The threshold of {e.Threshold} was reached at {e.TimeReached}.");
        Environment.Exit(0);
    }
    // </HandleEventDelegate>
}

class CounterWithDelegate(int passedThreshold)
{
    private readonly int _threshold = passedThreshold;
    private int _total;

    public void Add(int x)
    {
        _total += x;
        // <RaiseEventDelegate>
        if (_total >= _threshold)
        {
            ThresholdReachedEventArgs args = new();
            args.Threshold = _threshold;
            args.TimeReached = DateTime.Now;
            OnThresholdReached(args);
        }
        // </RaiseEventDelegate>
    }

    // <RaiseEventMethodDelegate>
    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
    // </RaiseEventMethodDelegate>

    // <DeclareEventWithDelegate>
    public event ThresholdReachedEventHandler? ThresholdReached;
    // </DeclareEventWithDelegate>
}

// <DeclareDelegateType>
public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);
// </DeclareDelegateType>
// </ThresholdReachedWithDelegate>
