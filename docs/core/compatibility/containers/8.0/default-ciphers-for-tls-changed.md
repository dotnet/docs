---
title: "Debian 12 container images no longer support TLS 1.2"
description: Learn about the breaking change in containers where .NET 8 Debian container images no longer support TLS 1.2.
ms.date: 08/29/2024
---
# Debian 12 container images no longer support TLS 1.2

.NET 8 Debian 12 container images use different default cipher suites for TLS than .NET 7 Debian 11 container images. The same is true for .NET 8 Ubuntu 24.04 containers images as compared to Ubuntu 22.04.

This change will prevent applications from securely connecting to servers that do not support TLS 1.3.

.NET, on Linux, respects the OpenSSL configuration for default cipher suites when doing TLS/SSL via the <xref:System.Net.Security.SslStream> class or higher-level operations, such as HTTPS via the <xref:System.Net.Http.HttpClient> class. When default cipher suites aren't explicitly configured, .NET on Linux uses a tightly restricted list of permitted cipher suites. This behavior was [added in .NET 5 as a breaking change](../../cryptography/5.0/default-cipher-suites-for-tls-on-linux.md).

Debian 12 and Ubuntu 24.04 do not configure default cipher suites for OpenSSL. Alpine (all known versions) do not configure default cipher suites for OpenSSL.

## Previous behavior

.NET 6 and 7 Debian images are based on Debian 11. Debian 11 includes a setting in `/etc/ssl/openssl.cnf` that configures TLS 1.2 as the minimum supported protocol. This setting is honored by OpenSSL, including when used within .NET apps.

.NET 8 Ubuntu 22.04 images are configured the same way as Debian 11.

## New behavior

.NET 8 Debian images are based on Debian 12. Debian 12 does not configure a minimum protocol version in `/etc/ssl/openssl.cnf`. As a result, The .NET default ciphers are used on Debian 12 or higher, making TLS 1.3 the minimum protocol version.

.NET 8 Ubuntu 24.04 images are configured the same way as Debian 12 and also set TLS 1.3 as the minimum protocol version.

## Version introduced

.NET 5

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Debian and Ubuntu maintainers presumably made this change to align with industry standards. TLS 1.2 has not been considered secure for many years. The .NET 5 change was made for the same rationale.

## Recommended action

Upgrade components that do not support TLS 1.3. This is required to create secure workflows.

More information is available at [dotnet/dotnet-docker #6039](https://github.com/dotnet/dotnet-docker/issues/6039).

## Affected APIs

None.

## See also
