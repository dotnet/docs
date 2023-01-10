internal static partial class Program
{
    internal static Channel<Coordinates> CreateBounded()
    {
        // <boundedcapcity>
        var channel = Channel.CreateBounded<Coordinates>(1);
        // </boundedcapcity>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptions()
    {
        // <boundedoptions>
        var channel = Channel.CreateBounded<Coordinates>(
            new BoundedChannelOptions(1_000)
            {
                SingleWriter = true,
                SingleReader = false,
                AllowSynchronousContinuations = false,
                FullMode = BoundedChannelFullMode.DropWrite
            });
        // </boundedoptions>

        return channel;
    }

    internal static Channel<Coordinates> CreateBoundedWithOptionsAndCallback()
    {
        // <boundedcallback>
        var channel = Channel.CreateBounded(
            new BoundedChannelOptions(10)
            {
                AllowSynchronousContinuations = true,
                FullMode = BoundedChannelFullMode.DropOldest
            },
            static void (Coordinates dropped) =>
                Console.WriteLine($"Coordinates dropped: {dropped}"));
        // </boundedcallback>

        return channel;
    }
}
