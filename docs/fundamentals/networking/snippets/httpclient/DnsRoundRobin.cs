using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

// <DnsRoundRobinConnector>
// This is available as NuGet Package: https://www.nuget.org/packages/DnsRoundRobin/
// The original source code can be found also here: https://github.com/MihaZupan/DnsRoundRobin
public sealed class DnsRoundRobinConnector : IDisposable
// </DnsRoundRobinConnector>
{
    private const int DefaultDnsRefreshIntervalSeconds = 2 * 60;
    private const int MaxCleanupIntervalSeconds = 60;

    public static DnsRoundRobinConnector Shared { get; } = new();

    private readonly ConcurrentDictionary<string, HostRoundRobinState> _states = new(StringComparer.Ordinal);
    private readonly Timer _cleanupTimer;
    private readonly TimeSpan _cleanupInterval;
    private readonly long _cleanupIntervalTicks;
    private readonly long _dnsRefreshTimeoutTicks;
    private readonly TimeSpan _endpointConnectTimeout;

    /// <summary>
    /// Creates a new <see cref="DnsRoundRobinConnector"/>.
    /// </summary>
    /// <param name="dnsRefreshInterval">Maximum amount of time a Dns resolution is cached for. Default to 2 minutes.</param>
    /// <param name="endpointConnectTimeout">Maximum amount of time allowed for a connection attempt to any individual endpoint. Defaults to infinite.</param>
    public DnsRoundRobinConnector(TimeSpan? dnsRefreshInterval = null, TimeSpan? endpointConnectTimeout = null)
    {
        dnsRefreshInterval = TimeSpan.FromSeconds(Math.Max(1, dnsRefreshInterval?.TotalSeconds ?? DefaultDnsRefreshIntervalSeconds));
        _cleanupInterval = TimeSpan.FromSeconds(Math.Clamp(dnsRefreshInterval.Value.TotalSeconds / 2, 1, MaxCleanupIntervalSeconds));
        _cleanupIntervalTicks = (long)(_cleanupInterval.TotalSeconds * Stopwatch.Frequency);
        _dnsRefreshTimeoutTicks = (long)(dnsRefreshInterval.Value.TotalSeconds * Stopwatch.Frequency);
        _endpointConnectTimeout = endpointConnectTimeout is null || endpointConnectTimeout.Value.Ticks < 1 ? Timeout.InfiniteTimeSpan : endpointConnectTimeout.Value;

        bool restoreFlow = false;
        try
        {
            // Don't capture the current ExecutionContext and its AsyncLocals onto the timer causing them to live forever
            if (!ExecutionContext.IsFlowSuppressed())
            {
                ExecutionContext.SuppressFlow();
                restoreFlow = true;
            }

            // Ensure the Timer has a weak reference to the connector; otherwise, it
            // can introduce a cycle that keeps the connector rooted by the Timer
            _cleanupTimer = new Timer(static state =>
            {
                var thisWeakRef = (WeakReference<DnsRoundRobinConnector>)state!;
                if (thisWeakRef.TryGetTarget(out DnsRoundRobinConnector? thisRef))
                {
                    thisRef.Cleanup();
                    thisRef._cleanupTimer.Change(thisRef._cleanupInterval, Timeout.InfiniteTimeSpan);
                }
            }, new WeakReference<DnsRoundRobinConnector>(this), Timeout.Infinite, Timeout.Infinite);

            _cleanupTimer.Change(_cleanupInterval, Timeout.InfiniteTimeSpan);
        }
        finally
        {
            if (restoreFlow)
            {
                ExecutionContext.RestoreFlow();
            }
        }
    }

    private void Cleanup()
    {
        long minTimestamp = Stopwatch.GetTimestamp() - _cleanupIntervalTicks;

        foreach (KeyValuePair<string, HostRoundRobinState> state in _states)
        {
            if (state.Value.LastAccessTimestamp < minTimestamp)
            {
                _states.TryRemove(state);
            }
        }
    }

    public void Dispose()
    {
        _states.Clear();
    }

    public Task<Socket> ConnectAsync(DnsEndPoint endPoint, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled<Socket>(cancellationToken);
        }

        if (IPAddress.TryParse(endPoint.Host, out IPAddress? address))
        {
            // Avoid the overhead of HostRoundRobinState if we're dealing with a single endpoint
            return ConnectToIPAddressAsync(address, endPoint.Port, cancellationToken);
        }

        HostRoundRobinState state = _states.GetOrAdd(
            endPoint.Host,
            static (_, thisRef) => new HostRoundRobinState(thisRef._dnsRefreshTimeoutTicks, thisRef._endpointConnectTimeout),
            this);

        return state.ConnectAsync(endPoint, cancellationToken);
    }

    private static async Task<Socket> ConnectToIPAddressAsync(IPAddress address, int port, CancellationToken cancellationToken)
    {
        var socket = new Socket(SocketType.Stream, ProtocolType.Tcp) { NoDelay = true };
        try
        {
            await socket.ConnectAsync(address, port, cancellationToken);
            return socket;
        }
        catch
        {
            socket.Dispose();
            throw;
        }
    }

    private sealed class HostRoundRobinState
    {
        private readonly long _dnsRefreshTimeoutTicks;
        private readonly TimeSpan _endpointConnectTimeout;
        private long _lastAccessTimestamp;
        private long _lastDnsTimestamp;
        private IPAddress[]? _addresses;
        private uint _roundRobinIndex;

        public long LastAccessTimestamp => Volatile.Read(ref _lastAccessTimestamp);

        private bool AddressesAreStale => Stopwatch.GetTimestamp() - Volatile.Read(ref _lastDnsTimestamp) > _dnsRefreshTimeoutTicks;

        public HostRoundRobinState(long dnsRefreshTimeoutTicks, TimeSpan endpointConnectTimeout)
        {
            _dnsRefreshTimeoutTicks = dnsRefreshTimeoutTicks;
            _endpointConnectTimeout = endpointConnectTimeout;

            _roundRobinIndex--; // Offset the first Increment to ensure we start with the first address in the list

            RefreshLastAccessTimestamp();
        }

        private void RefreshLastAccessTimestamp() => Volatile.Write(ref _lastAccessTimestamp, Stopwatch.GetTimestamp());

        public async Task<Socket> ConnectAsync(DnsEndPoint endPoint, CancellationToken cancellationToken)
        {
            RefreshLastAccessTimestamp();

            uint sharedIndex = Interlocked.Increment(ref _roundRobinIndex);
            IPAddress[]? attemptedAddresses = null;
            IPAddress[]? addresses = null;
            Exception? lastException = null;

            while (attemptedAddresses is null)
            {
                if (addresses is null)
                {
                    addresses = _addresses;
                }
                else
                {
                    attemptedAddresses = addresses;

                    // Give each connection attempt a chance to do its own Dns call.
                    addresses = null;
                }

                if (addresses is null || AddressesAreStale)
                {
                    // It's possible that multiple connection attempts are resolving the same host concurrently - that's okay.
                    _addresses = addresses = await Dns.GetHostAddressesAsync(endPoint.Host, cancellationToken);
                    Volatile.Write(ref _lastDnsTimestamp, Stopwatch.GetTimestamp());

                    if (attemptedAddresses is not null && AddressListsAreEquivalent(attemptedAddresses, addresses))
                    {
                        // We've already tried to connect to every address in the list, and a new Dns resolution returned the same list.
                        // Instead of attempting every address again, give up early.
                        break;
                    }
                }

                for (int i = 0; i < addresses.Length; i++)
                {
                    Socket? attemptSocket = null;
                    CancellationTokenSource? endpointConnectTimeoutCts = null;
                    try
                    {
                        IPAddress address = addresses[(int)((sharedIndex + i) % addresses.Length)];

                        if (Socket.OSSupportsIPv6 && address.AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            attemptSocket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.Tcp);
                            if (address.IsIPv4MappedToIPv6)
                            {
                                attemptSocket.DualMode = true;
                            }
                        }
                        else if (Socket.OSSupportsIPv4 && address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            attemptSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        }

                        if (attemptSocket is not null)
                        {
                            attemptSocket.NoDelay = true;

                            if (_endpointConnectTimeout != Timeout.InfiniteTimeSpan)
                            {
                                endpointConnectTimeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
                                endpointConnectTimeoutCts.CancelAfter(_endpointConnectTimeout);
                            }

                            await attemptSocket.ConnectAsync(address, endPoint.Port, endpointConnectTimeoutCts?.Token ?? cancellationToken);

                            RefreshLastAccessTimestamp();
                            return attemptSocket;
                        }
                    }
                    catch (Exception ex)
                    {
                        attemptSocket?.Dispose();

                        if (cancellationToken.IsCancellationRequested)
                        {
                            throw;
                        }

                        if (endpointConnectTimeoutCts?.IsCancellationRequested == true)
                        {
                            ex = new TimeoutException($"Failed to connect to any endpoint within the specified endpoint connect timeout of {_endpointConnectTimeout.TotalSeconds:N2} seconds.", ex);
                        }

                        lastException = ex;
                    }
                    finally
                    {
                        endpointConnectTimeoutCts?.Dispose();
                    }
                }
            }

            throw lastException ?? new SocketException((int)SocketError.NoData);
        }

        private static bool AddressListsAreEquivalent(IPAddress[] left, IPAddress[] right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left.Length != right.Length)
            {
                return false;
            }

            for (int i = 0; i < left.Length; i++)
            {
                if (!left[i].Equals(right[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}