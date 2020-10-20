---
title: SYSLIB0010 compiler warning
description: Learn about the obsoletion that generates compiler warning SYSLIB0010.
ms.topic: reference
ms.date: 10/20/2020
---
# SYSLIB0010: Unsupported remoting APIs

[.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71)) is a legacy technology, and the infrastructure exists only in .NET Framework. The following remoting-related APIs are marked as obsolete, starting in .NET 5.0. Using them in code generates warning `SYSLIB0010` at compile time.

- <xref:System.MarshalByRefObject.GetLifetimeService?displayProperty=nameWithType>
- <xref:System.MarshalByRefObject.InitializeLifetimeService?displayProperty=nameWithType>

## Workaround

Consider using WCF or HTTP-based REST services to communicate with objects in other applications or across machines. For more information, see [.NET Framework technologies unavailable on .NET Core](../../../../docs/core/porting/net-framework-tech-unavailable.md).

## See also

- [.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71))
