---
title: SYSLIB0035 warning - ComputeCounterSignature without specifying a CmsSigner is obsolete
description: Learn about the obsoletion of the parameterless ComputeCounterSignature method that generates compile-time warning SYSLIB0035.
ms.date: 09/07/2021
---
# SYSLIB0035: ComputeCounterSignature without specifying a CmsSigner is obsolete

The <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0035` at compile time.

## Workaround

Use the overload that accepts a <xref:System.Security.Cryptography.Pkcs.CmsSigner>, that is, <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature(System.Security.Cryptography.Pkcs.CmsSigner)?displayProperty=nameWithType>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0035

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0035
```

To suppress all the `SYSLIB0035` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0035</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
