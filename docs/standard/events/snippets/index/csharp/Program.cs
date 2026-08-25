namespace EventsOverview;

// <HandleEvent>
class Program
{
    static void Main()
    {
        var c = new Counter();
        c.ThresholdReached += c_ThresholdReached;

        // Provide remaining implementation for the class...
    }

    static void c_ThresholdReached(object? sender, EventArgs e)
    {
        Console.WriteLine("The threshold was reached.");
    }
}
// </HandleEvent>
