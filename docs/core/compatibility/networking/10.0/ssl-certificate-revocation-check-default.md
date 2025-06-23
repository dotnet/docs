---
title: "Breaking change - HttpClient/SslStream default certificate revocation check mode changed to Online"
description: "Learn about the breaking change in .NET 10 Preview 6 where the default certificate revocation check mode changed from NoCheck to Online."
ms.date: 06/23/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46824
---

# HttpClient/SslStream default certificate revocation check mode changed to Online

<xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> default values have changed from `NoCheck` to `Online`. This change enhances security and makes the behavior consistent with <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy?displayProperty=nameWithType>.

## Version introduced

.NET 10 Preview 6

## Previous behavior

<xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> default values were `NoCheck`, meaning certificate revocation lists weren't checked by default.

```csharp
var clientOptions = new SslClientAuthenticationOptions
{
    TargetHost = "example.com"
    // CertificateRevocationCheckMode defaults to NoCheck
};

var serverOptions = new SslServerAuthenticationOptions
{
    ServerCertificate = serverCertificate
    // CertificateRevocationCheckMode defaults to NoCheck  
};
```

## New behavior

<xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> default values are `Online`, meaning certificate revocation lists are checked online by default.

```csharp
var clientOptions = new SslClientAuthenticationOptions
{
    TargetHost = "example.com"
    // CertificateRevocationCheckMode defaults to Online
};

var serverOptions = new SslServerAuthenticationOptions
{
    ServerCertificate = serverCertificate
    // CertificateRevocationCheckMode defaults to Online
};
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enhances security and ensures consistency between APIs related to X.509 certificate revocation checking.

## Recommended action

If certificate revocation checking is not desired, specify `X509RevocationMode.NoCheck` explicitly:

```csharp
var clientOptions = new SslClientAuthenticationOptions
{
    TargetHost = "example.com",
    CertificateRevocationCheckMode = X509RevocationMode.NoCheck
};

var serverOptions = new SslServerAuthenticationOptions
{
    ServerCertificate = serverCertificate,
    CertificateRevocationCheckMode = X509RevocationMode.NoCheck
};
```

In situations where the code might not be modified, previous behavior can be enabled by setting either:

- `System.Net.Security.NoRevocationCheckByDefault` AppContext switch to `true`
- `DOTNET_SYSTEM_NET_SECURITY_NOREVOCATIONCHECKBYDEFAULT` environment variable to `true`

## Affected APIs

- <xref:System.Net.Security.SslStream.AuthenticateAsClient%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsClientAsync%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsServer%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync%2A?displayProperty=fullName>
- <xref:System.Net.Http.HttpClient?displayProperty=fullName>
