// <ThresholdReachedNoData>
class EventNoData
{
    static void Main()
    {
        Counter c = new(new Random().Next(10));
        // <SubscribeEvent>
        c.ThresholdReached += c_ThresholdReached;
        // </SubscribeEvent>

        Console.WriteLine("press 'a' key to increase total");
        while (Console.ReadKey(true).KeyChar == 'a')
        {
            Console.WriteLine("adding one");
            c.Add(1);
        }
    }

    // <HandleEvent>
    static void c_ThresholdReached(object? sender, EventArgs e)
    {
        Console.WriteLine("The threshold was reached.");
        Environment.Exit(0);
    }
    // </HandleEvent>
}

class Counter(int passedThreshold)
{
    private readonly int _threshold = passedThreshold;
    private int _total;

    public void Add(int x)
    {
        _total += x;
        // <RaiseEvent>
        if (_total >= _threshold)
        {
            OnThresholdReached(EventArgs.Empty);
        }
        // </RaiseEvent>
    }

    // <RaiseEventMethod>
    protected virtual void OnThresholdReached(EventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
    // </RaiseEventMethod>

    // <DeclareEvent>
    public event EventHandler? ThresholdReached;
    // </DeclareEvent>
}
// </ThresholdReachedNoData>
