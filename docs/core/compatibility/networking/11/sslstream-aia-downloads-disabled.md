---
title: "Breaking change: SslStream server-side AIA certificate downloads disabled by default"
description: "Learn about the breaking change in .NET 11 where SslStream disables AIA certificate downloads during server-side client-certificate validation by default."
ms.date: 04/03/2026
ai-usage: ai-assisted
---

# SslStream server-side AIA certificate downloads disabled by default

Starting in .NET 11, <xref:System.Net.Security.SslStream> doesn't download missing intermediate certificates using the Authority Information Access (AIA) extension by default when validating client certificates as a server.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, when `SslStream` validated client certificates as a server, it attempted to download missing intermediate certificates using the AIA extension if the client didn't provide them during the TLS handshake. This behavior occurred even when no custom <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateChainPolicy> was specified.

For example, the following code would attempt to download intermediate certificates via AIA if the client omitted them:

```csharp
var sslStream = new SslStream(networkStream);

await sslStream.AuthenticateAsServerAsync(new SslServerAuthenticationOptions
{
    ServerCertificate = serverCertificate,
    ClientCertificateRequired = true,
    CertificateRevocationCheckMode = X509RevocationMode.Online
});
```

## New behavior

Starting in .NET 11, `SslStream` disables AIA certificate downloads when operating as a server that validates client certificates. If the client doesn't provide all required intermediate certificates during the TLS handshake, the server no longer attempts to download them. The handshake fails with a certificate validation error unless the server is configured with the required intermediate certificates.

This change only applies when no custom <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateChainPolicy> is provided. If a custom <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy> is specified, its <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.DisableCertificateDownloads> value is respected.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Allowing AIA downloads during the TLS handshake can cause significant performance degradation if the AIA server is slow or unresponsive. Additionally, making outbound HTTP requests to client-provided endpoints introduces potential security risks, since an attacker could influence which external endpoints the server contacts. For more details, see the [pull request](https://github.com/dotnet/runtime/pull/125049) that introduced this change.

## Recommended action

Choose one of the following options:

- **Ensure the client sends all required intermediate certificates**: Configure the client to include all intermediate certificates in the TLS handshake. On the client side, use <xref:System.Net.Security.SslClientAuthenticationOptions.ClientCertificateContext> with an <xref:System.Net.Security.SslStreamCertificateContext> that includes the full chain. For most scenarios, creating `SslStreamCertificateContext` handles intermediate certificate management automatically.

- **Provide intermediate certificates in the server's chain policy**: Use <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.ExtraStore> to supply the necessary intermediate certificates to the server:

    ```csharp
    var chainPolicy = new X509ChainPolicy
    {
        // Disable AIA downloads (SslStream sets this to true on its internal policy by default in .NET 11;
        // when you supply a custom X509ChainPolicy, set it explicitly to match that behavior)
        DisableCertificateDownloads = true,

        // Add any necessary intermediate certificates
        ExtraStore = { intermediateCertificate },

        // If client certificates are issued by a private root CA, specify custom trust
        TrustMode = X509ChainTrustMode.CustomRootTrust,
        CustomTrustStore = { rootCertificate }
    };

    var sslStream = new SslStream(networkStream);

    await sslStream.AuthenticateAsServerAsync(new SslServerAuthenticationOptions
    {
        ServerCertificateContext = serverCertificateContext,
        ClientCertificateRequired = true,
        CertificateChainPolicy = chainPolicy
    });
    ```

- **Explicitly allow AIA downloads (not recommended)**: Restore the previous behavior by setting <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy.DisableCertificateDownloads> to `false`. This approach is not recommended due to the associated performance and security risks.

## Affected APIs

- <xref:System.Net.Security.SslStream.AuthenticateAsServer*?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync*?displayProperty=fullName>
