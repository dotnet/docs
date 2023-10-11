---
title: SYSLIB0009 warning
description: Learn about the obsoletions that generate compile-time warning SYSLIB0009.
ms.date: 10/20/2020
---

# SYSLIB0009: AuthenticationManager is not supported

The following APIs are marked obsolete, starting in .NET 5. Use of these APIs generates warning `SYSLIB0009` at compile time and throws a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType>
- <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType>

The entire <xref:System.Net.AuthenticationManager> class is marked as obsolete as of .NET 9. The usage of this class generates warning `SYSLIB0009` at compile time.
The methods will no-op or throw <xref:System.PlatformNotSupportedException>.

## Workarounds

Implement <xref:System.Net.IAuthenticationModule>, which has methods that were previously called by <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0009

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0009
```

To suppress all the `SYSLIB0009` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0009</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
