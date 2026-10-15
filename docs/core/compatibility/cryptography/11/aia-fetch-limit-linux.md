---
title: "Breaking change: Linux AIA certificate fetching limited to two fetches per chain build"
description: "Learn about the breaking change in .NET 11 where certificate chain building on OpenSSL-based platforms performs at most two Authority Information Access (AIA) fetches."
ms.date: 08/04/2026
ai-usage: ai-assisted
---

# Linux AIA certificate fetching limited to two fetches per chain build

On Linux and other OpenSSL-based platforms, certificate chain building via Authority Information Access (AIA) is now limited to two AIA fetches per chain build. This limit aligns Linux behavior with Windows, which has always had a two-fetch limit.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, on OpenSSL-based platforms, <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType> performed AIA fetches to download intermediate certificates as many times as needed to complete the chain. For example, a chain that required three intermediate certificates downloaded through AIA could succeed:

```csharp
using var cert = X509Certificate2.CreateFromPem(leafCertificateWithThreeAiaHops);
using var chain = new X509Chain();

// On Linux with .NET 10 and earlier, this could succeed even when three or more
// intermediate certificates needed to be downloaded via AIA.
bool result = chain.Build(cert);
Console.WriteLine(result); // Could print True with 3+ AIA fetches
```

## New behavior

Starting in .NET 11, on OpenSSL-based platforms, <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType> performs at most two AIA fetches per chain build, which matches Windows behavior. If the chain requires more than two intermediates to be downloaded through AIA, the chain build doesn't succeed through AIA downloads alone:

```csharp
using var cert = X509Certificate2.CreateFromPem(leafCertificateWithThreeAiaHops);
using var chain = new X509Chain();

// On Linux with .NET 11+, if three or more AIA fetches are required,
// the build fails.
bool result = chain.Build(cert);
Console.WriteLine(result); // Prints False if more than two AIA fetches are needed.
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Windows has always limited AIA fetches to two per chain build, while the Linux implementation had no such limit, which created an inconsistency across platforms. The same limit on Linux makes cross-platform behavior consistent and better limits the network and memory resources required to construct a certificate chain. For more information, see [dotnet/runtime#130456](https://github.com/dotnet/runtime/pull/130456).

## Recommended action

If your application builds certificate chains on Linux that require more than two intermediate certificates to be fetched via AIA, supply the intermediate certificates directly instead of relying on AIA downloads:

```csharp
using var cert = X509Certificate2.CreateFromPem(leafCertPem);
using var intermediate1 = X509Certificate2.CreateFromPem(intermediate1Pem);
using var intermediate2 = X509Certificate2.CreateFromPem(intermediate2Pem);
using var intermediate3 = X509Certificate2.CreateFromPem(intermediate3Pem);

using var chain = new X509Chain();
chain.ChainPolicy.ExtraStore.Add(intermediate1);
chain.ChainPolicy.ExtraStore.Add(intermediate2);
chain.ChainPolicy.ExtraStore.Add(intermediate3);
// other ChainPolicy settings as appropriate

bool result = chain.Build(cert);
```

Alternatively, install the intermediate certificates in the user or system intermediate certificate store so they're available to all chains without AIA downloads.

## Affected APIs

* <xref:System.Security.Cryptography.X509Certificates.X509Chain.Build(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=fullName>
