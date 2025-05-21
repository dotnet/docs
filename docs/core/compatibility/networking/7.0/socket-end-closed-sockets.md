---
title: "Breaking change: Socket.End methods don't throw ObjectDisposedException"
description: Learn about the .NET 7 breaking change in networking where Socket.End methods no longer throw ObjectDisposedException when the socket is closed.
ms.date: 09/14/2022
ms.topic: concept-article
---
# Socket.End methods don't throw ObjectDisposedException

`System.Net.Sockets.Socket.End*` methods (for example, <xref:System.Net.Sockets.Socket.EndSend%2A>) throw a <xref:System.Net.Sockets.SocketException> instead of an <xref:System.ObjectDisposedException> if the socket is closed.

## Previous behavior

Previously, the [affected methods](#affected-apis) threw an <xref:System.ObjectDisposedException> for closed sockets.

## New behavior

Starting in .NET 7, the [affected methods](#affected-apis) throw a <xref:System.Net.Sockets.SocketException> with <xref:System.Net.Sockets.SocketException.SocketErrorCode> set to <xref:System.Net.Sockets.SocketError.OperationAborted?displayProperty=nameWithType> for closed sockets.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

The [asynchronous programming model (APM)](../../../../standard/asynchronous-programming-patterns/asynchronous-programming-model-apm.md) APIs are those named `Begin*` and `End*`. Starting with .NET 6, these legacy APIs are backed with a `Task`-based implementation as part of an effort to consolidate and simplify the `Socket` codebase. Unfortunately, with the 6.0 implementation, unexpected events were sometimes raised on <xref:System.Threading.Tasks.TaskScheduler.UnobservedTaskException?displayProperty=nameWithType>. This happened even when the APIs were used correctly, meaning that the calling code always invoked the `End*` methods, including when the socket was closed.

The change to throw a <xref:System.Net.Sockets.SocketException> was made to ensure that no unobserved exceptions are leaked in such cases.

## Recommended action

If your code catches an <xref:System.ObjectDisposedException> from any of the `Socket.End*` methods, change it to catch <xref:System.Net.Sockets.SocketException> and refer to <xref:System.Net.Sockets.SocketException.SocketErrorCode?displayProperty=nameWithType> to query the underlying reason.

> [!NOTE]
> APM code should always make sure that `End*` methods are invoked after the corresponding `Begin*` methods, even if the socket is closed.

## Affected APIs

- <xref:System.Net.Sockets.Socket.EndConnect(System.IAsyncResult)?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndDisconnect(System.IAsyncResult)?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndSend%2A?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndSendFile(System.IAsyncResult)?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndSendTo(System.IAsyncResult)?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndReceive%2A?displayProperty=fullName>
- <xref:System.Net.Sockets.Socket.EndAccept%2A?displayProperty=fullName>
