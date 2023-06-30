---
title: SYSLIB0030 warning
description: Learn about the obsoletion of one of the HMACSHA1 constructors that generates compile-time warning SYSLIB0030.
ms.date: 07/16/2021
---
# SYSLIB0030: HMACSHA1 always uses the algorithm implementation provided by the platform

The <xref:System.Security.Cryptography.HMACSHA1.%23ctor(System.Byte[],System.Boolean)> constructor is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0030` at compile time.

## Workarounds

Use a constructor without the `useManagedSha1` parameter.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0030

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0030
```

To suppress all the `SYSLIB0030` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0030</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
