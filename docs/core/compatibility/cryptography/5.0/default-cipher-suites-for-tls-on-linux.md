---
title: "Breaking change: Default TLS cipher suites for .NET on Linux"
description: Learn about the breaking change in .NET 5 where .NET, on Linux, now respects the OpenSSL configuration for default cipher suites when doing TLS/SSL.
ms.date: 10/16/2020
---
# Default TLS cipher suites for .NET on Linux

.NET, on Linux, now respects the OpenSSL configuration for default cipher suites when doing TLS/SSL via the <xref:System.Net.Security.SslStream> class or higher-level operations, such as HTTPS via the <xref:System.Net.Http.HttpClient> class. When default cipher suites aren't explicitly configured, .NET on Linux uses a tightly restricted list of permitted cipher suites.

## Change description

In previous .NET versions, .NET does not respect system configuration for default cipher suites. The default cipher suite list for .NET on Linux is very permissive.

Starting in .NET 5, .NET on Linux respects the OpenSSL configuration for default cipher suites when it's specified in *openssl.cnf*. When cipher suites aren't explicitly configured, the only permitted cipher suites are as follows:

- TLS 1.3 cipher suites
- TLS_ECDHE_ECDSA_WITH_AES_256_GCM_SHA384
- TLS_ECDHE_ECDSA_WITH_AES_128_GCM_SHA256
- TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384
- TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256
- TLS_ECDHE_ECDSA_WITH_AES_256_CBC_SHA384
- TLS_ECDHE_ECDSA_WITH_AES_128_CBC_SHA256
- TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384
- TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256

Since this fallback default doesn't include any cipher suites that are compatible with TLS 1.0 or TLS 1.1, these older protocol versions are effectively disabled by default.

Supplying a CipherSuitePolicy value to SslStream for a specific session will still replace the configuration file content and/or .NET fallback default.

## Reason for change

Users running .NET on Linux requested that the default configuration for <xref:System.Net.Security.SslStream> be changed to one that provided a high security rating from third-party assessment tools.

## Version introduced

5.0

## Recommended action

The new defaults are likely to work when communicating with modern clients or servers. If you need to expand the default cipher suite list to accept legacy clients (or to contact legacy servers), either specify a `CipherSuitePolicy` value or change the OpenSSL configuration file. On many Linux distributions, the OpenSSL configuration file is at */etc/ssl/openssl.cnf*.

This sample *openssl.cnf* file is a minimal file that's equivalent to the default cipher suites policy for .NET 5 and later on Linux. Instead of replacing the system file, merge these concepts with the file that's present on your system.

```ini
openssl_conf = default_conf

[default_conf]
ssl_conf = ssl_sect

[ssl_sect]
system_default = system_default_sect

[system_default_sect]
CipherString = ECDHE-ECDSA-AES256-GCM-SHA384:ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES256-SHA384:ECDHE-ECDSA-AES128-SHA256:ECDHE-RSA-AES256-SHA384:ECDHE-RSA-AES128-SHA256
```

On the Red Hat Enterprise Linux, CentOS, and Fedora distributions, .NET applications default to the cipher suites permitted by the system-wide cryptographic policies. On these distributions, use the crypto-policies configuration instead of *openssl.cnf*.

## Affected APIs

Not detectible via API analysis.

<!--

### Affected APIs

- Not detectible via API analysis.

### Category

- Cryptography
- Security

-->
