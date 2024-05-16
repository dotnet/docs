internal static partial class Program
{
    internal static Channel<Coordinates> CreateUnbounded()
    {
        // <unbounded>
        var channel = Channel.CreateUnbounded<Coordinates>();
        // </unbounded>

        return channel;
    }

    internal static Channel<Coordinates> CreateUnboundedWithOptions()
    {
        // <unboundedoptions>
        var channel = Channel.CreateUnbounded<Coordinates>(
            new UnboundedChannelOptions
            {
                SingleWriter = false,
                SingleReader = false,
                AllowSynchronousContinuations = true
            });
        // </unboundedoptions>

        return channel;
    }
}
