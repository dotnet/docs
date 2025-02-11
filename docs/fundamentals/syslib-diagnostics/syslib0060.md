---
title: SYSLIB0060 warning - Rfc2898DeriveBytes constructors are obsolete
description: Learn about the obsoletion of Rfc2898DeriveBytes constructors. Use of these constructors generates compile-time warning SYSLIB0060.
ms.date: 01/30/2025
ai-usage: ai-assisted
f1_keywords:
  - SYSLIB0060
---
# SYSLIB0060: Rfc2898DeriveBytes constructors are obsolete

Starting in .NET 10, all of the constructors on <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType> are obsolete. Calling these constructors in code generates warning `SYSLIB0060` at compile time.

## Reason for obsoletion

The instance-based implementation of PBKDF2, which <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType> provides, offers a non-standard usage by "streaming" bytes back by allowing successive calls to `GetBytes`. This is not the intended use of PBKDF2; the algorithm should be used as a one-shot. The one-shot functionality exists as the static method <xref:System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2*?displayProperty=nameWithType> and should be used instead of instantiating <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType>.

## Workaround

Change instances of <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType> and calls to `GetBytes` to use the <xref:System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2*?displayProperty=nameWithType> one-shot static method instead.

For example, change:

```csharp
using System.Security.Cryptography;

Rfc2898DeriveBytes kdf = new Rfc2898DeriveBytes(password, salt, iterations, hashAlgorithm);
byte[] derivedKey = kdf.GetBytes(64);
```

to

```csharp
byte[] derivedKey = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, 64);
```

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0060

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0060
```

To suppress all the `SYSLIB0060` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0060</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
