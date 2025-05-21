---
title: "Breaking change: SendFile throws NotSupportedException for connectionless sockets"
description: Learn about the .NET 8 breaking change in networking where the SendFile, SendFileAsync, and EndSendFile methods now throw a NotSupportedException for connectionless sockets on all platforms.
ms.date: 11/03/2023
ms.topic: concept-article
---
# SendFile throws NotSupportedException for connectionless sockets

The behavior of the <xref:System.Net.Sockets.Socket.SendFile%2A> method family for connectionless (for example, UDP) sockets is now consistent across all platforms. The [affected methods](#affected-apis) now throw a <xref:System.NotSupportedException> on all platforms.

## Previous behavior

Previously, for a connectionless <xref:System.Net.Sockets.Socket> (for example, UDP), the following behaviors were observed:

- <xref:System.Net.Sockets.Socket.SendFile%2A> threw a <xref:System.NotSupportedException> on Windows, but not on Unix-like platforms.
- The <xref:System.Threading.Tasks.ValueTask> returned from <xref:System.Net.Sockets.Socket.SendFileAsync%2A> stored a <xref:System.Net.Sockets.SocketException> on all platforms.
- Calling <xref:System.Net.Sockets.Socket.EndSendFile%2A> on an <xref:System.IAsyncResult> returned from <xref:System.Net.Sockets.Socket.BeginSendFile%2A> threw a <xref:System.Net.Sockets.SocketException> on all platforms.

## New behavior

Starting in .NET 8, for a connectionless <xref:System.Net.Sockets.Socket> (for example, UDP), the following behaviors are observed:

- <xref:System.Net.Sockets.Socket.SendFile%2A> throws a <xref:System.NotSupportedException> on all platforms.
- The <xref:System.Threading.Tasks.ValueTask> returned from <xref:System.Net.Sockets.Socket.SendFileAsync%2A> stores a <xref:System.NotSupportedException> on all platforms.
- Calling <xref:System.Net.Sockets.Socket.EndSendFile%2A> on an <xref:System.IAsyncResult> returned from <xref:System.Net.Sockets.Socket.BeginSendFile%2A> throws a <xref:System.NotSupportedException> on all platforms.

## Version introduced

.NET 8 RC 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Given that `SendFile` is typically used with large amounts of data, it doesn't make sense to use it with connectionless sockets. In addition, the previous behavior was inconsistent, throwing `SocketException` on some platforms, while succeeding on others with an unpredictable outcome.

## Recommended action

Do not use `SendFile` methods for connectionless sockets.

## Affected APIs

- <xref:System.Net.Sockets.Socket.SendFile%2A?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.SendFileAsync%2A?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndSendFile%2A?displayProperty=fullName>
