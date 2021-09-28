---
title: "Breaking change: MulticastOption.Group doesn't accept a null value"
description: Learn about the breaking change in .NET 5 where MulticastOption.Group no longer accepts a null value.
ms.date: 08/18/2020
---
# MulticastOption.Group doesn't accept a null value

<xref:System.Net.Sockets.MulticastOption.Group?displayProperty=nameWithType> no longer accepts a value of `null`. If you set the property to `null`, an <xref:System.ArgumentNullException> is thrown.

## Version introduced

5.0

## Change description

In previous versions of .NET, you can set the <xref:System.Net.Sockets.MulticastOption.Group?displayProperty=nameWithType> property to `null`. If the <xref:System.Net.Sockets.MulticastOption> is later passed to <xref:System.Net.Sockets.Socket.SetSocketOption%2A?displayProperty=nameWithType>, the runtime throws a <xref:System.NullReferenceException>.

In .NET 5 and later, an <xref:System.ArgumentNullException> is thrown if you set the property to `null`.

## Reason for change

To be consistent with the Framework Design Guidelines, the property has been updated to throw an <xref:System.ArgumentNullException> if the value is `null`.

## Recommended action

Make sure that you don't set <xref:System.Net.Sockets.MulticastOption.Group?displayProperty=nameWithType> to `null`.

## Affected APIs

- <xref:System.Net.Sockets.MulticastOption.Group?displayProperty=fullName>

<!--

### Affected APIs

- `P:System.Net.Sockets.MulticastOption.Group`

### Category

Networking

-->
