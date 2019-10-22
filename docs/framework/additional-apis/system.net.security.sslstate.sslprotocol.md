---
title: SslState.SslProtocol Property (System.Net.Security)
ms.date: 10/21/2019
ms.technology: "dotnet-networking"
topic_type:
  - "apiref"
api_name:
  - "System.Net.Security.SslState.SslProtocol"
  - "System.Net.Security.SslState.get_SslProtocol"
api_location:
  - "System.dll"
api_type:
  - "Assembly"
---
# SslState.SslProtocol Property

Gets the SSL protocol versions.

## Syntax

```csharp
internal SslProtocols SslProtocol { get; }
```

## Property value

<xref:System.Security.Authentication.SslProtocols>  
A bitwise combination of the enumeration values that specify the SSL protocol versions.

## Remarks

> [!WARNING]
> The `SslState.SslProtocol` property is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this property in a production application under any circumstance.

## Requirements

**Namespace:** <xref:System.Net.Security>

**Assembly:** System (in System.dll)

**.NET Framework versions:** Available since 2.0.
