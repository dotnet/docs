---
description: "Learn more about: UnsafeNclNativeMethods class"
title: UnsafeNclNativeMethods class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.UnsafeNclNativeMethods
  - System.Net.UnsafeNclNativeMethods.NativePKI
  - System.Net.UnsafeNclNativeMethods.NativePKI.FindClientCertificates
api_location:
  - System.dll
api_type:
  - Assembly
---
# UnsafeNclNativeMethods class

Contains classes that import unsafe native networking methods. This class cannot be inherited.

```csharp
internal static class UnsafeNclNativeMethods
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## NativePKI class

Contains methods imported from crypt32.dll. These methods handle certificates when using Hypertext Transfer Protocol Secure (HTTPS). This class cannot be inherited.

```csharp
internal static class NativePKI
```

## NativePKI.FindClientCertificates method

Discovers available client certificates to send to the server.

```csharp
internal static X509CertificateCollection FindClientCertificates
```

### Return value

<xref:System.Security.Cryptography.X509Certificates.X509CertificateCollection?displayProperty=nameWithType>

A collection of available client certificates.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
