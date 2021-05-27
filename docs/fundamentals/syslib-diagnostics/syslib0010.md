---
title: SYSLIB0010 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0010.
ms.date: 10/20/2020
---
# SYSLIB0010: Unsupported remoting APIs

[.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71)) is a legacy technology, and the infrastructure exists only in .NET Framework. The following remoting-related APIs are marked as obsolete, starting in .NET 5. Using them in code generates warning `SYSLIB0010` at compile time and throws a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.MarshalByRefObject.GetLifetimeService?displayProperty=nameWithType>
- <xref:System.MarshalByRefObject.InitializeLifetimeService?displayProperty=nameWithType>

## Workarounds

Consider using WCF or HTTP-based REST services to communicate with objects in other applications or across machines. For more information, see [.NET Framework technologies unavailable on .NET Core](../../core/porting/net-framework-tech-unavailable.md).

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

## See also

- [.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71))
