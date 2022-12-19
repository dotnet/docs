using BroadcastChannel.GrainsInterfaces;
using Orleans.BroadcastChannel;

namespace BroadcastChannel.Grains;

[ImplicitChannelSubscription]
public sealed class LiveStockGrain : Grain, IOnBroadcastChannelSubscribed
{
    public Task OnSubscribed(IBroadcastChannelSubscription streamSubscription)
    {
        return streamSubscription.Attach<Stock>(
            item => OnPublished(streamSubscription.ChannelId, item),
            ex => OnError(streamSubscription.ChannelId, ex));

        // Called when an item is published to the channel
        static Task OnPublished(ChannelId id, Stock item)
        {
            // Do something
            return Task.CompletedTask;
        }

        // Called when an error occurs
        static Task OnError(ChannelId id, Exception ex)
        {
            // Do something
            return Task.CompletedTask;
        }
    }
}
