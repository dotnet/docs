---
title: SYSLIB0053 warning - AesGcm should indicate the required tag size
description: Learn about the obsoletion of AesGcm constructors that generates compile-time warning SYSLIB0053.
ms.date: 06/08/2023
---
# SYSLIB0053: AesGcm should indicate the required tag size

The <xref:System.Security.Cryptography.AesGcm> constructors that don't accept a tag size are obsolete, starting in .NET 8:

- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.Byte[])>
- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.ReadOnlySpan{System.Byte})>

Calling them in code generates warning `SYSLIB0053` at compile time.

## Workaround

New constructors that accept a tag size have been added in .NET 8. Use one of these constructors instead:

- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.Byte[],System.Int32)>
- <xref:System.Security.Cryptography.AesGcm.%23ctor(System.ReadOnlySpan{System.Byte},System.Int32)>

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0053

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0053
```

To suppress all the `SYSLIB0053` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0053</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
