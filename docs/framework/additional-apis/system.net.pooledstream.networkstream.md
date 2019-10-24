---
title: PooledStream.NetworkStream Property (System.Net)
ms.date: 10/21/2019
ms.technology: "dotnet-networking"
topic_type:
  - "apiref"
api_name:
  - "System.Net.PooledStream.NetworkStream"
  - "System.Net.PooledStream.get_NetworkStream"
  - "System.Net.PooledStream.set_NetworkStream"
api_location:
  - "System.dll"
api_type:
  - "Assembly"
---
# PooledStream.NetworkStream Property

Gets or sets the network stream for the `PooledStream` socket.

## Syntax

```csharp
internal NetworkStream NetworkStream { get; set; }
```

## Property value

<xref:System.Net.Sockets.NetworkStream>  
The network stream for the `PooledStream` socket.

## Remarks

> [!WARNING]
> The `PooledStream.NetworkStream` property is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
