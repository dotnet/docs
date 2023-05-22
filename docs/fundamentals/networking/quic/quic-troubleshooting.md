---
title: Troubleshoot QUIC issues in .NET
description: Learn how to diagnose and fix the most common QUIC issues in .NET.
ms.date: 05/19/2023
---
# Troubleshoot QUIC issues in .NET

In this article, you'll learn how to diagnose the most common issues with QUIC in .NET.

The `System.Net.Quic` library is based on the open source QUIC implementation [MsQuic](https://github.com/microsoft/msquic). Because of this, the behavior differs from ordinary sockets, sometimes by design. Moreover, it's based on UDP protocol, and it doesn't provide the exact same experience as with TCP.

## Listener is running but doesn't receive any data

If a listener is running but never receives data, it might be caused by other process listening on the same port. To verify which process is using which port run:

```bash
sudo ss -tulpw
```

This behavior is by design as `MsQuic` uses `SO_REUSEPORT` to achieve better performance. For more information, see [ListenerStart](https://github.com/microsoft/msquic/blob/main/docs/api/ListenerStart.md) documentation and the original issue [dotnet/runtime#59382](https://github.com/dotnet/runtime/issues/59382).

> [!NOTE]
> This problem doesn't occur on Windows, where MsQuic will attempt to do a port reservation. This causes the application trying to open second listener on the same port fail to start.

## Client receives unexpected ALPN error

Client attempts to connect, but receives `Application layer protocol negotiation error was encountered` despite using the same ALPN as the server.

What happens is that listener always binds to dual-mode wildcard address, regardless of what the application specified. Then it matches incoming connections by IP address and ALPN. If no match is found, it reports the above mentioned error. As a result, mismatch between listening IP address and connecting one will result in an ALPN error.

To avoid this error, make sure you're connecting to the same address for which the listener was started. For example, print the listening address for your listener:

```csharp
await using var listener = QuicListener.ListenAsync(...);
Console.WriteLine(listener.LocalEndPoint);
```

This issue might happen in several different scenarios, such as in this issue [dotnet/runtime#85412](https://github.com/dotnet/runtime/issues/85412). The server was started for `Loopback` address (`127.0.0.1`) and everything worked when ran on the same machine. But when the client tried to connect from a different one, the address would not match the server loopback address and was rejected with ALPN error.

> [!NOTE]
> This happens when the listener is using MsQuic, for example via .NET `QuicListener`.

## Listener succeeds to start for IPv6 despite it being disabled

Despite IPv6 being disabled, `QuicListener.ListenAsync` succeeds with an IPv6 address. This is related to the previous problem as `MsQuic` binds to wildcard address and thus succeeds in doing so. As a result, the listener is started but no connection can be made to it. This is behavioral difference from sockets, which throw in such case.

There are many ways to check if IPv6 is enable, for example on Linux check the state of IPv6 module:

```bash
cat /sys/module/ipv6/parameters/disable

# 0 - IPv6 is enable
# 1 - IPv6 is disabled
```

As stated above, MsQuic behavior here is intentional. However, this particular problem might be mitigated on the .NET side in the future. For more details, see [dotnet/runtime#75343](https://github.com/dotnet/runtime/issues/75343).

## Listener fails to start with `QUIC_STATUS_ADDRESS_IN_USE` error

This a Windows specific problem. Listener throws `QuicException` with `QUIC_STATUS_ADDRESS_IN_USE` error despite no other process running on particular address and port. The error is caused by port exclusion range defined for the same port as the listener is trying to listen on. To check for the exclusion ranges run:

```batch
netsh.exe int ip show excludedportrange protocol=udp
```

Getting failure for attempt to bind on a port that is from excluded range is expected behavior. For that reason, there are no immediate plans to fix this. More details can be found in [dotnet/runtime#71518](https://github.com/dotnet/runtime/issues/71518).

## See also

- [MsQuic troubleshooting guide](https://github.com/microsoft/msquic/blob/main/docs/TSG.md)
