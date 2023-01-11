---
title: TLS/SSL best practices
description: Learn the best practices when using SslStream in .NET.
author: rzikm
ms.author: radekzikmund
ms.date: 1/9/2023
---

# TLS/SSL best practices

TLS (Transport Layer Security) is a cryptographic protocol designed to secure communication between two computers over the internet. The TLS protocol is exposed in .NET via the <xref:System.Net.Security.SslStream> class.

This article presents best practices for setting up secure communication between client and server and assumes use of .NET. For best practices with .NET Framework, see [Transport Layer Security (TLS) best practices with the .NET Framework](/dotnet/framework/network-programming/tls).

## Select TLS version

While it is possible to specify the version of the TLS protocol to be used via the SslProtocols property, it is recommended to defer to the operating system settings by using <xref:System.Security.Authentication.SslProtocols.None> value (this is the default).

Deferring the decision to the OS automatically uses the most recent version of TLS available and lets the application pick up changes after OS upgrades. The operating system may also prevent use of TLS versions which are no longer considered secure.

## Select cipher suites

`SslStream` allows users to specify which cipher suites can be negotiated by the TLS handshake via the <xref:System.Net.Security.CipherSuitesPolicy> class. As with TLS versions, it's recommended to let the OS decide which are the best cipher suites to negotiate with, and, therefore, it's recommended to avoid using <xref:System.Net.Security.CipherSuitesPolicy>.

> [!NOTE]
> <xref:System.Net.Security.CipherSuitesPolicy> is not supported on Windows and attempts to instantiate it will cause <xref:System.NotSupportedException> to be thrown.

## Specify a server certificate

When authenticating as a server, <xref:System.Net.Security.SslStream> requires an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> instance. It is recommended to always use an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> instance which also contains the private key.

There are multiple ways that a server certificate can be passed to <xref:System.Net.Security.SslStream>:

- Directly as a parameter to <xref:System.Net.Security.SslStream.AuthenticateAsServerAsync%2A?displayProperty=nameWithType> or via <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificate?displayProperty=nameWithType> property
- From a selection callback in <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateSelectionCallback?displayProperty=nameWithType> property
- By passing a <xref:System.Net.Security.SslStreamCertificateContext> in the <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateContext?displayProperty=nameWithType> property

The recommended approach is to use the <xref:System.Net.Security.SslServerAuthenticationOptions.ServerCertificateContext?displayProperty=nameWithType> property. When the certificate is obtained by one of the other two ways, a <xref:System.Net.Security.SslStreamCertificateContext> instance is created internally by the <xref:System.Net.Security.SslStream> implementation. Creating a <xref:System.Net.Security.SslStreamCertificateContext> involves building an <xref:System.Security.Cryptography.X509Certificates.X509Chain> which is a CPU intensive operation. It is more efficient to create a <xref:System.Net.Security.SslStreamCertificateContext> once and reuse it for multiple <xref:System.Net.Security.SslStream> instances.

Reusing <xref:System.Net.Security.SslStreamCertificateContext> instances also enables additional features such us [TLS session resumption](https://datatracker.ietf.org/doc/html/rfc5077) on Linux servers.

## Custom `X509Certificate` validation

There are certain scenarios in which the default certificate validation procedure isn't adequate and some custom validation logic is required. Parts of the validation logic can be customized by specifying <xref:System.Net.Security.SslClientAuthenticationOptions.CertificateChainPolicy?displayProperty=nameWithType> or <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateChainPolicy?displayProperty=nameWithType>. Alternatively, completely custom logic can be provided via the <System.Net.Security.SslClientAuthenticationOptions.RemoteCertificateValidationCallback> property. For more information, see [Custom certificate trust](#custom-certificate-trust).

### Custom certificate trust

When encountering a certificate that wasn't issued by any of the certificate authorities trusted by the machine (including self-signed certificates), the default certificate validation procedure will fail. One possible way to resolve this is to add the necessary issuer certificates to the machine's trusted store. That, however, might affect other applications on the system and is not always possible.

The alternative solution is to specify custom trusted root certificates via an <xref:System.Security.Cryptography.X509Certificates.X509ChainPolicy>. To specify a custom trust list that will be used instead of the system trust list during validation, consider the following example:

```csharp
SslClientAuthenticationOptions clientOptions = new();

clientOptions.CertificateChainPolicy = new X509ChainPolicy()
{
    TrustMode = X509ChainTrustMode.CustomRootTrust,
    CustomTrustStore =
    {
        customIssuerCert
    }
};
```

Clients configured with the preceding policy would only accept certificates trusted by `customIssuerCert`.

### Ignore specific validation errors

Consider an IoT device without a persistent clock. After powering on, the clock of the device would start many years in the past and, therefore, all certificates would be considered "not yet valid". Consider the following code that shows a validation callback implementation ignoring validity period violations.

```csharp
static bool CustomCertificateValidationCallback(
    object sender,
    X509Certificate? certificate,
    X509Chain? chain,
    SslPolicyErrors sslPolicyErrors)
{
    // Anything that would have been accepted by default is OK
    if (sslPolicyErrors == SslPolicyErrors.None)
    {
        return true;
    }
    
    // If there is something wrong other than a chain processing error, don't trust it.
    if (sslPolicyErrors != SslPolicyErrors.RemoteCertificateChainErrors)
    {
        return false;
    }
    
    Debug.Assert(chain is not null);
    
    foreach (X509ChainStatus status in chain.ChainStatus)
    {
        // If an error other than `NotTimeValid` (or `NoError`) is present, don't trust it.
        if ((status.Status & ~X509ChainStatusFlags.NotTimeValid) != X509ChainStatusFlags.NoError)
        {
            return false;
        }
    }

    return true;
}
```

### Certificate pinning

Another situation where custom certificate validation is necessary is when clients expect servers to use a specific certificate, or a certificate from a small set of known certificates. This practice is known as [certificate pinning](https://owasp.org/www-community/controls/Certificate_and_Public_Key_Pinning). The following code snippet shows a validation callback which checks that the server presents a certificate with a specific known public key.

```csharp
static bool CustomCertificateValidationCallback(
    object sender,
    X509Certificate? certificate,
    X509Chain? chain,
    SslPolicyErrors sslPolicyErrors)
{
    // If there is something wrong other than a chain processing error, don't trust it.
    if ((sslPolicyErrors & ~SslPolicyErrors.RemoteCertificateChainErrors) != 0)
    {
        return false;
    }
    
    Debug.Assert(certificate is not null);

    const string ExpectedPublicKey =
        "3082010A0282010100C204ECF88CEE04C2B3D850D57058CC9318EB5C" +
        "A86849B022B5F9959EB12B2C763E6CC04B604C4CEAB2B4C00F80B6B0" +
        "F972C98602F95C415D132B7F71C44BBCE9942E5037A6671C618CF641" +
        "42C546D31687279F74EB0A9D11522621736C844C7955E4D16BE8063D" +
        "481552ADB328DBAAFF6EFF60954A776B39F124D131B6DD4DC0C4FC53" +
        "B96D42ADB57CFEAEF515D23348E72271C7C2147A6C28EA374ADFEA6C" +
        "B572B47E5AA216DC69B15744DB0A12ABDEC30F47745C4122E19AF91B" +
        "93E6AD2206292EB1BA491C0C279EA3FB8BF7407200AC9208D98C5784" +
        "538105CBE6FE6B5498402785C710BB7370EF6918410745557CF9643F" +
        "3D2CC3A97CEB931A4C86D1CA850203010001";

    return certificate.GetPublicKeyString().Equals(ExpectedPublicKey);
}
```

## Considerations for client certificate validation

Server applications need to be careful when requiring and validating client certificates. Certificates may contain the [AIA (Authority Information Access)](http://www.pkiglobe.org/auth_info_access.html) extension which specifies where the issuer certificate can be downloaded. The server may therefore attempt to download the issuer certificate from external server when building the <xref:System.Security.Cryptography.X509Certificates.X509Chain> for the client certificate. Similarly, servers may need to contact external servers to ensure that the client certificate has not been revoked.

The need to contact external servers when building and validating the <xref:System.Security.Cryptography.X509Certificates.X509Chain> may expose the application to denial of service attacks if the external servers are slow to respond. Therefore, server applications should configure the <xref:System.Security.Cryptography.X509Certificates.X509Chain> building behavior using the <xref:System.Net.Security.SslServerAuthenticationOptions.CertificateChainPolicy>.
