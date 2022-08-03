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
        var options = new UnboundedChannelOptions()
        {

        };

        var channel = Channel.CreateUnbounded<Coordinates>(options);
        // </unboundedoptions>

        return channel;
    }
}
