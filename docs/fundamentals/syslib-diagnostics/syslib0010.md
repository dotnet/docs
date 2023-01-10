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

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0010

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0010
```

To suppress all the `SYSLIB0010` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0010</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [.NET remoting](/previous-versions/dotnet/netframework-1.1/kwdt6w2k(v=vs.71))
