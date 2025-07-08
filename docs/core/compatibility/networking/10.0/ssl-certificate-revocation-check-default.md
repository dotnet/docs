---
title: "Breaking change - HttpClient/SslStream default certificate revocation check mode changed to Online"
description: "Learn about the breaking change in .NET 10 where the default certificate revocation check mode changed from 'NoCheck' to 'Online'."
ms.date: 06/23/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46824
---

# HttpClient/SslStream default certificate revocation check mode changed to `Online`

The default values of <xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> have changed from `NoCheck` to `Online`. This change enhances security and makes the behavior consistent with <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy?displayProperty=nameWithType>.

## Version introduced

.NET 10 Preview 6

## Previous behavior

Previously, the default values of <xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> were <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck?displayProperty=nameWithType>, meaning revocation status of peer certificates wasn't checked by default.

## New behavior

Starting in .NET 10, the default values of <xref:System.Net.Security.SslClientAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> and <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateRevocationCheckMode?displayProperty=nameWithType> are <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode.Online?displayProperty=nameWithType>, meaning revocation status of peer certificates are checked online by default.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enhances security and ensures consistency between APIs related to X.509 certificate revocation checking.

## Recommended action

If certificate revocation checking is not desired, specify <xref:System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck?displayProperty=nameWithType> explicitly:

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

> [!NOTE]
> Due to a bug on the OSX platform, you might encounter certificate validation failures with <xref:System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.RevocationStatusUnknown?displayProperty=nameWithType> in scenarios where the certificate doesn't support revocation checking via OCSP. This is a bug in the underlying platform crypto implementation. To avoid failing the certificate validation if revocation status can't be retrieved, either disable certificate revocation checking as per the previous instructions, or set <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy> with <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.VerificationFlags?displayProperty=nameWithType> set to `X509VerificationFlags.IgnoreEndRevocationUnknown | X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown`.

In situations where you can't modify the code, you can restore the previous behavior with one of the following settings:

- Set `System.Net.Security.NoRevocationCheckByDefault` AppContext switch to `true`.
- Set `DOTNET_SYSTEM_NET_SECURITY_NOREVOCATIONCHECKBYDEFAULT` environment variable to `true`.

## Affected APIs

- <xref:System.Net.Security.SslStream.AuthenticateAsClient%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsClientAsync%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsServer%2A?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync%2A?displayProperty=fullName>
- <xref:System.Net.Http.HttpClient.Send*?displayProperty=fullName> (when using either <xref:System.Net.Http.WinHttpHandler> or <xref:System.Net.Http.SocketsHttpHandler>)
- <xref:System.Net.Http.HttpClient.SendAsync*?displayProperty=fullName> (when using either <xref:System.Net.Http.WinHttpHandler> or <xref:System.Net.Http.SocketsHttpHandler>)
