internal static partial class Program
{
    internal static Channel<T> CreateBounded<T>(
        int capacity) =>
        Channel.CreateBounded<T>(capacity);

    internal static Channel<T> CreateBounded<T>(
        BoundedChannelOptions options) =>
        Channel.CreateBounded<T>(options);

    internal static Channel<T> CreateBounded<T>(
        BoundedChannelOptions options,
        Action<T>? itemDropped) =>
        Channel.CreateBounded<T>(options, itemDropped);
}
