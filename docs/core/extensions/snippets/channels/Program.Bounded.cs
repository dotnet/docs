internal static partial class Program
{
    internal static Channel<Coordinates> CreateBounded()
    {
        // <boundedcapcity>
        var channel =
            Channel.CreateBounded<Coordinates>(10);
        // </boundedcapcity>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptions()
    {
        // <boundedoptions>
        var channel = 
            Channel.CreateBounded<Coordinates>(
                new BoundedChannelOptions(10));
        // </boundedoptions>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptionsAndCallback()
    {
        // <boundedcallback>
        var onItemDropped = static (Coordinates droppedCoordinates) => 
            Console.WriteLine($"Coordinates dropped: {droppedCoordinates}");

        var channel = Channel.CreateBounded(
            new BoundedChannelOptions(10)
            {
                AllowSynchronousContinuations = true,
                FullMode = BoundedChannelFullMode.DropOldest
            }, 
            onItemDropped);
        // </boundedcallback>

        return channel;
    }
}
