---
title: TLS/SSL Best Practices
description: Learn best practices to using SslStream in .NET
author: rzikm
ms.author: rzikm
ms.date: 10/25/2022
---

# TLS/SSL Best Practices

[TLS (Transport Layer Security)](https://en.wikipedia.org/wiki/Transport_Layer_Security) is a cryptographic protocol designed to secure communication between two computers over the internet. The TLS protocol is exposed in .NET via the [`SslStream`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslstream) class.

This article presents best practices for setting up secure communication between client and server and assumes .NET Core version 3.1 or later. For best practices for .NET Framework, see [Transport Layer Security (TLS) best practices with the .NET Framework](https://learn.microsoft.com/en-us/dotnet/framework/network-programming/tls).

## Selecting TLS Version

While it is possible to specify the version of the TLS protocol to be used via the SslProtocols property, it is recommended to defer to the operating system settings by using `SslProtocols.None` value (this is the default).

Deferring the decision to the OS automatically uses the most recent version of TLS available and lets the application pick up changes after OS upgrades. The operating system may also prevent use of TLS versions which are no longer considered secure.

## Selecting Cipher Suites

SslStream allows users to specify which cipher suites can be negotiated by the TLS handshake via the [`CipherSuitesPolicy`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.ciphersuitespolicy?view=net-6.0) class. As with TLS versions, we recommend letting the operating system decide which are the best cipher suites to negotiate with and, therefore, we recommend avoiding the use of `CipherSuitesPolicy`.

Note that `CipherSuitesPolicy` is not available on all platforms supported by .NET.

## Specifying a Server Certificate

When authenticating as a server, `SslStream` requires an [`X509Certificate`](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509certificate2?view=net-7.0) instance to use. There are multiple ways how the server certificate can be passed to `SslStream`:

- Directly as a parameter to [`SslStream.AuthenticateAsServerAsync`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslstream.authenticateasserverasync?view=net-7.0#system-net-security-sslstream-authenticateasserverasync(system-security-cryptography-x509certificates-x509certificate)) or via [`SslServerAuthenticationOptions.ServerCertificate`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslserverauthenticationoptions.servercertificate?view=net-7.0) property
- From a selection callback in [`SslServerAuthenticationOptions.ServerCertificateSelectionCallback`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslserverauthenticationoptions.servercertificateselectioncallback?view=net-7.0) property
- By passing a [`SslStreamCertificateContext`](https://learn.microsoft.com/cs-cz/dotnet/api/system.net.security.sslstreamcertificatecontext?view=net-6.0) in the [`SslServerAuthenticationOptions.ServerCertificateContext`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslserverauthenticationoptions.servercertificatecontext?view=net-7.0) property

The recommended approach is to use the [`SslServerAuthenticationOptions.ServerCertificateContext`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslserverauthenticationoptions.servercertificatecontext?view=net-7.0) property. When the certificate is obtained by one of the other two ways, a `SslStreamCertificateContext` instance is created internally by the `SslStream` implementation. Creating a `SslStreamCertificateContext` involves building an [`X509Chain`](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.x509certificates.x509chain?view=net-6.0) which is a CPU intensive operation. It is more efficient to create a `SslStreamCertificateContext` once and reuse it for multiple `SslStream` instances.

Reusing `SslStreamCertificateContext` instances also enables additional features such us [TLS session resumption](https://datatracker.ietf.org/doc/html/rfc5077) on Linux servers.

## Custom X509Certificate Validation

There are certain scenarios in which the default certificate validation procedure is not adequate and some custom validation logic is required. This custom logic can be provided via the [`SslClientAuthenticationOptions.RemoteCertificateValidationCallback`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslclientauthenticationoptions.remotecertificatevalidationcallback?view=net-6.0#system-net-security-sslclientauthenticationoptions-remotecertificatevalidationcallback) property. As an illustration, following sections provide some examples.

### Ignoring Specific Validation Errors

Consider an IoT device without a persistent clock. After powering on, the clock of the device would start many years in the past and, therefore, all certificates would be considered "not yet valid". The following code shows a validation callback implementation which ignores validity period violations.

```cs
static bool CustomCertificateValidationCallback(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
{
    if (chain == null)
    {
        return false;
    }

    foreach (X509ChainStatus status in chain.ChainStatus)
    {
        if ((status.Status & ~X509ChainStatusFlags.NotTimeValid) != X509ChainStatusFlags.NoError)
        {
            return false;
        }
    }

    return true;
}
```

### Certificate Pinning

Another situation where custom certificate validation is necessary is when clients expect servers to use a specific certificate, or a certificate from a small set of known certificates. This practice is known as [certificate pinning](https://owasp.org/www-community/controls/Certificate_and_Public_Key_Pinning). The following code snippet shows a validation callback which checks that the server presents a certificate with a specific known public key.

```cs
static bool CustomCertificateValidationCallback(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
{
    if (certificate == null)
    {
        return false;
    }

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

## Considerations for Client Certificate Validation

Server applications need to be careful when requiring and validating client certificates. Instead of sending the entire certificate chain, clients can configure the [AIA (Authority Information Access)](http://www.pkiglobe.org/auth_info_access.html) extension which specifies where the issuer certificate can be downloaded. The server will then download the issuer certificate when building the `X509Chain` for the client certificate. Similarly, servers may need to contact external servers to ensure that the client certificate has not been revoked.

The need to contact external servers when building and validating the `X509Chain` may expose the application to denial of service attacks if the external servers are slow to respond. Therefore, server applications should configure the `X509Chain` building behavior using the [`SslServerAuthenticationOptions.CertificateChainPolicy`](https://learn.microsoft.com/en-us/dotnet/api/system.net.security.sslserverauthenticationoptions.certificatechainpolicy?view=net-7.0) (available since .NET 7).