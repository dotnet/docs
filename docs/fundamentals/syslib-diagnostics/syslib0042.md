---
title: SYSLIB0042 warning - FromXmlString and ToXmlString on ECC types are obsolete
description: Learn about the obsoletion of the 'FromXmlString' and 'ToXmlString' methods on ECC types that generates compile-time warning SYSLIB0042.
ms.date: 04/08/2022
---
# SYSLIB0042: FromXmlString and ToXmlString on ECC types are obsolete

The `FromXmlString` and `ToXmlString` methods that are on elliptic curve cryptography (ECC) types are obsolete, starting in .NET 7. Using them in code generates warning `SYSLIB0042` at compile time. They were never implemented and always threw a <xref:System.PlatformNotSupportedException> exception. The obsoletion affects the following methods:

- <xref:System.Security.Cryptography.ECDiffieHellmanCng.FromXmlString(System.String,System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDiffieHellmanCng.ToXmlString(System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDiffieHellmanCngPublicKey.FromXmlString(System.String)?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDiffieHellmanCngPublicKey.ToXmlString?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToXmlString?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDsaCng.FromXmlString(System.String,System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDsaCng.ToXmlString(System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=nameWithType>

## Workaround

Use a standard data format for exchanging elliptic curve (EC) keys.

Instead of `ToXmlString`, use `ExportSubjectPublicKeyInfo` or `ExportPkcs8PrivateKey` depending on whether you want the public or private key.

Instead of `FromXmlString`, use `ImportSubjectPublicKeyInfo` or `ImportPkcs8PrivateKey` depending on whether you want to import a public or private key.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0042

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0042
```

To suppress all the `SYSLIB0042` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0042</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
