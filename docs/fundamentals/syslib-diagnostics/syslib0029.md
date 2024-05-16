---
title: SYSLIB0029 warning
description: Learn about the obsoletion of ProduceLegacyHmacValues that generates compile-time warning SYSLIB0029.
ms.date: 07/16/2021
f1_keywords:
  - syslib0029
---
# SYSLIB0029: ProduceLegacyHmacValues is obsolete

The following properties are marked as obsolete, starting in .NET 6:

- <xref:System.Security.Cryptography.HMACSHA384.ProduceLegacyHmacValues?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.HMACSHA512.ProduceLegacyHmacValues?displayProperty=nameWithType>

Using these APIs in code generates warning `SYSLIB0029` at compile time. Producing legacy HMAC values is no longer supported.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0029

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0029
```

To suppress all the `SYSLIB0029` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0029</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
