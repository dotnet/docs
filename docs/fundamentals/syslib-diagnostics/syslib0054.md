---
title: SYSLIB0054 warning - Thread.VolatileRead and Thread.VolatileWrite are obsolete
description: Learn about the obsoletion of Thread.VolatileRead and Thread.VolatileWrite that generates compile-time warning SYSLIB0054.
ms.date: 05/09/2024
f1_keywords:
  - syslib0054
---
# SYSLIB0054: Thread.VolatileRead and Thread.VolatileWrite are obsolete

All overloads of the <xref:System.Threading.Thread.VolatileRead%2A?displayProperty=nameWithType> and <xref:System.Threading.Thread.VolatileWrite%2A?displayProperty=nameWithType> methods are obsolete, starting in .NET 9. Calling them in code generates warning `SYSLIB0054` at compile time.

## Reason for obsoletion

The .NET Framework implementation of the 64-bit overloads of the <xref:System.Threading.Thread.VolatileRead%2A?displayProperty=nameWithType> and <xref:System.Threading.Thread.VolatileWrite%2A?displayProperty=nameWithType> methods had incorrect atomicity. In .NET (Core), the implementation was changed to delegate to the <xref:System.Threading.Volatile.Read%2A?displayProperty=nameWithType> and <xref:System.Threading.Volatile.Write%2A?displayProperty=nameWithType>, respectively, which provide proper acquire/release semantics. In addition, the methods in the <xref:System.Threading.Thread> class don't include an overload that accepts a Boolean argument, whereas the <xref:System.Threading.Volatile> methods do. The methods were obsoleted to encourage use of the <xref:System.Threading.Volatile> methods.

## Workaround

Call <xref:System.Threading.Volatile.Read%2A?displayProperty=nameWithType> or <xref:System.Threading.Volatile.Write%2A?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0054

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0054
```

To suppress all the `SYSLIB0054` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0054</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
