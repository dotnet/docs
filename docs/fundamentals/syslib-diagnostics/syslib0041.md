---
title: SYSLIB0041 warning - Rfc2898DeriveBytes constructors with default hash algorithm and iteration counts are obsolete
description: Learn about the obsoletion of some Rfc2898DeriveBytes constructors that generates compile-time warning SYSLIB0041.
ms.date: 04/08/2022
f1_keywords:
  - syslib0041
---
# SYSLIB0041: Some Rfc2898DeriveBytes constructors are obsolete

The following <xref:System.Security.Cryptography.Rfc2898DeriveBytes> constructors are obsolete, starting in .NET 7. Using them in code generates warning `SYSLIB0041` at compile time.

- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Byte[])>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.Byte[],System.Byte[],System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Byte[],System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Int32,System.Int32)>

 These overloads default the hash algorithm or number of iterations, and the defaults are no longer considered secure. These are all of the constructors that were available in .NET 4.7.1 and earlier versions. Going forward, you should only use the newer constructors.

## Workaround

Use a different constructor overload where you can explicitly specify the iteration count (the default is 1000) and hash algorithm name (the default is <xref:System.Security.Cryptography.HashAlgorithmName.SHA1?displayProperty=nameWithType>).

If you're using the default iteration count or default hash algorithm, consider moving to more secure values&mdash;that is, a larger iteration count or a newer hash algorithm.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0041

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0041
```

To suppress all the `SYSLIB0041` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0041</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
