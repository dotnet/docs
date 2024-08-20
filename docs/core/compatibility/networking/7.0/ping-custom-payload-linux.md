---
title: "Breaking change: Custom ping payloads on Linux"
description: Learn about the .NET 7 breaking change in networking where an exception is thrown on non-privileged Linux processes when a custom payload is passed to the Ping method.
ms.date: 03/23/2022
ms.custom: linux-related-content
---
# Custom ping payloads on Linux

On Linux, non-privileged processes can't send raw IP packets. <xref:System.Net.NetworkInformation.Ping> functionality is implemented by interfacing with the `ping` utility. However, this utility doesn't support specifying a custom payload for the Internet Control Message Protocol (ICMP) ping packets. .NET 7 adds a check for such cases and throws an exception if a custom payload is specified.

## Previous behavior

In previous versions, the ping packet payload was silently ignored (that is, it wasn't sent) on non-privileged Linux processes.

## New behavior

Starting in .NET 7, a <xref:System.PlatformNotSupportedException> is thrown if you attempt to send a custom ping packet payload when running in non-privileged Linux process.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

It's better to signal to the user that the operation cannot be performed instead of silently dropping the payload.

## Recommended action

If a ping payload is necessary, run the application as `root`, or grant the `cap_net_raw` capability using the `setcap` utility.

Otherwise, use an overload of <xref:System.Net.NetworkInformation.Ping.SendPingAsync%2A?displayProperty=nameWithType> that does not accept a custom payload, or pass in an empty array.

## Affected APIs

- <xref:System.Net.NetworkInformation.Ping.Send(System.Net.IPAddress,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.Send(System.Net.IPAddress,System.Int32,System.Byte[])?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.Send(System.String,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.Send(System.String,System.Int32,System.Byte[])?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendAsync(System.Net.IPAddress,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions,System.Object)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendAsync(System.Net.IPAddress,System.Int32,System.Byte[],System.Object)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendAsync(System.String,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions,System.Object)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendAsync(System.String,System.Int32,System.Byte[],System.Object)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendPingAsync(System.Net.IPAddress,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendPingAsync(System.Net.IPAddress,System.Int32,System.Byte[])?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendPingAsync(System.String,System.Int32,System.Byte[],System.Net.NetworkInformation.PingOptions)?displayProperty=fullName>
- <xref:System.Net.NetworkInformation.Ping.SendPingAsync(System.String,System.Int32,System.Byte[])?displayProperty=fullName>
