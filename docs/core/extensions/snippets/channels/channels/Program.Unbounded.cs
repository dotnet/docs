internal static partial class Program
{
    internal static Channel<T> CreateUnbounded<T>() =>
        Channel.CreateUnbounded<T>();

    internal static Channel<T> CreateUnbounded<T>(
        UnboundedChannelOptions options) =>
        Channel.CreateUnbounded<T>(options);
}
