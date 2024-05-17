---
title: SYSLIB0039 warning - SslProtocols.Tls and SslProtocols.Tls11 are obsolete
description: Learn about the obsoletion of the SslProtocols.Tls and SslProtocols.Tls11 enumeration fields that generates compile-time warning SYSLIB0039.
ms.date: 03/17/2022
f1_keywords:
  - syslib0039
---
# SYSLIB0039: SslProtocols.Tls and SslProtocols.Tls11 are obsolete

<xref:System.Security.Authentication.SslProtocols.Tls?displayProperty=nameWithType> and <xref:System.Security.Authentication.SslProtocols.Tls11?displayProperty=nameWithType> are marked as obsolete, starting in .NET 7. Using these enumeration fields in code generates warning `SYSLIB0039` at compile time.

## Workaround

Use a higher TLS protocol version, or use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType> to defer to system defaults.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0039

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0039
```

To suppress all the `SYSLIB0039` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0039</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
