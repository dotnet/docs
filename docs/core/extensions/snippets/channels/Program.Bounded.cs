internal static partial class Program
{
    internal static Channel<Coordinates> CreateBounded(
        int capacity)
    {
        // <boundedcapcity>
        var channel = Channel.CreateBounded<Coordinates>(capacity);
        // </boundedcapcity>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptions()
    {
        // <boundedoptions>
        var options = new BoundedChannelOptions(10);
        var channel = Channel.CreateBounded<Coordinates>(options);
        // </boundedoptions>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptionsAndCallback()
    {
        // <boundedcallback>
        var options = new BoundedChannelOptions(10)
        {
            AllowSynchronousContinuations = true,
            FullMode = BoundedChannelFullMode.DropOldest
        };

        static void OnItemDropped(Coordinates droppedCoordinates) => 
            Console.WriteLine($"Coordinates dropped: {droppedCoordinates}");

        var channel = Channel.CreateBounded<Coordinates>(
            options, 
            OnItemDropped);
        // </boundedcallback>

        return channel;
    }
}
