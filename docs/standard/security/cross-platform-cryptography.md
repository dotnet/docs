---
title: "Cross-platform cryptography in .NET"
description: Learn about cryptographic capabilities on platforms supported by .NET.
ms.date: "06/19/2020"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "cryptography, cross-platform"
  - "encryption, cross-platform"
---
# Cross-Platform Cryptography in .NET

Cryptographic operations in .NET are done by operating system (OS) libraries. This dependency has advantages:

* .NET apps benefit from OS reliability. Keeping cryptography libraries safe from vulnerabilities is a high priority for OS vendors. To do that, they provide updates that system administrators should be applying.
* .NET apps have access to FIPS-validated algorithms if the OS libraries are FIPS-validated.

The dependency on OS libraries also means that .NET apps can only use cryptographic features that the OS supports. While all platforms support certain core features, some features that .NET supports can't be used on some platforms. This article identifies the features that are supported on each platform.

This article assumes you have a working familiarity with cryptography in .NET. For more information, see [.NET Cryptography Model](cryptography-model.md) and [.NET Cryptographic Services](cryptographic-services.md).

## Hash algorithms

All hash algorithm and hash-based message authentication (HMAC) classes, including the `*Managed` classes, defer to the OS libraries with the exception of .NET on Browser WASM. In Browser WASM, SHA-1, SHA-2-256, SHA-2-384, SHA-2-512, are implemented using managed code.

### SHA-3

.NET 8 introduced support for the SHA-3 hash algorithms, including SHAKE-128 and SHAKE-256. SHA-3 support is currently supported on Windows 11 build 25324 or later, and Linux with OpenSSL 1.1.1 or later.

## Symmetric encryption

The underlying ciphers and chaining are done by the system libraries.

| Cipher + Mode | Windows  | Linux | macOS | iOS | Android |
|---------------|----------|-------|-------|-----|---------|
| AES-CBC       | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| AES-ECB       | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| AES-CFB8      | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| AES-CFB128    | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| 3DES-CBC      | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| 3DES-ECB      | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| 3DES-CFB8     | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| 3DES-CFB64    | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| DES-CBC       | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| DES-ECB       | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| DES-CFB8      | ✔️        | ✔️     | ✔️     | ✔️   | ✔️      |
| RC2-CBC       | ✔️        | ✔️     | ✔️     | ✔️   | ❌     |
| RC2-ECB       | ✔️        | ✔️     | ✔️     | ✔️   | ❌     |
| RC2-CFB       | ❌       | ❌     | ❌    | ❌   | ❌     |

## Authenticated encryption

Authenticated encryption (AE) support is provided for AES-CCM, AES-GCM, and ChaCha20Poly1305 via the <xref:System.Security.Cryptography.AesCcm?displayProperty=fullName>, <xref:System.Security.Cryptography.AesGcm?displayProperty=fullName>, and <xref:System.Security.Cryptography.ChaCha20Poly1305?displayProperty=fullName> classes, respectively.

As authentication encryption requires newer platform APIs to support the algorithm, support may not be present on all platforms. The `IsSupported` static property on the classes for the algorithm can be used to detect at runtime if the current platform supports the algorithm or not.

| Cipher + Mode     | Windows                 | Linux          | macOS   | iOS | Android       | Browser |
|-------------------|-------------------------|----------------|---------|-----|---------------|---------|
| AES-GCM           | ✔️                       | ✔️              | ⚠️       | ❌  | ✔️             | ❌      |
| AES-CCM           | ✔️                       | ✔️              | ⚠️       | ❌  | ✔️             | ❌      |
| ChaCha20Poly1305  | Windows 10 Build 20142+ | OpenSSL 1.1.0+ | ⚠️       | ❌  | API Level 28+ | ❌      |

### AES-CCM on macOS

On macOS, the system libraries don't support AES-CCM for third-party code, so the <xref:System.Security.Cryptography.AesCcm> class uses OpenSSL for support. Users on macOS need to obtain an appropriate copy of OpenSSL (libcrypto) for this type to function, and it must be in a path that the system would load a library from by default. We recommend that you install OpenSSL from a package manager such as Homebrew.

The `libcrypto.0.9.7.dylib` and `libcrypto.0.9.8.dylib` libraries included in macOS are from earlier versions of OpenSSL and will not be used. The `libcrypto.35.dylib`, `libcrypto.41.dylib`, and `libcrypto.42.dylib` libraries are from LibreSSL and will not be used.

### AES-GCM and ChaCha20Poly1305 on macOS

MacOS did not support AES-GCM or ChaCha20Poly1305 until macOS 10.15 for third-party code. Prior to .NET 8, <xref:System.Security.Cryptography.AesGcm> and <xref:System.Security.Cryptography.ChaCha20Poly1305> have the same requirement as AES-CCM and users must install OpenSSL for these types to function.

Starting in .NET 8, .NET on macOS will use the Apple's CryptoKit framework for AES-GCM and ChaCha20Poly1305. Users will not need to install or configure any additional dependencies for AES-GCM or ChaCha20Poly1305 on macOS.

### AES-CCM keys, nonces, and tags

* Key Sizes

  AES-CCM works with 128, 192, and 256-bit keys.

* Nonce Sizes

  The <xref:System.Security.Cryptography.AesCcm> class supports 56, 64, 72, 80, 88, 96, and 104-bit (7, 8, 9, 10, 11, 12, and 13-byte) nonces.

* Tag Sizes

  The <xref:System.Security.Cryptography.AesCcm> class supports creating or processing 32, 48, 64, 80, 96, 112, and 128-bit (4, 8, 10, 12, 14, and 16-byte) tags.

### AES-GCM keys, nonces, and tags

* Key Sizes

  AES-GCM works with 128, 192, and 256-bit keys.

* Nonce Sizes

  The <xref:System.Security.Cryptography.AesGcm> class supports only 96-bit (12-byte) nonces.

* Tag Sizes
  On Windows and Linux, the <xref:System.Security.Cryptography.AesGcm> class supports creating or processing 96, 104, 112, 120, and 128-bit (12, 13, 14, 15, and 16-byte) tags. On macOS, the tag size is limited to 128-bit (16-byte) due to limitation of the CryptoKit framework.

### ChaCha20Poly1305 keys, nonces, and tags.

ChaCha20Poly1305 has a fixed size for the key, nonce, and authentication tag. ChaCha20Poly1305 always uses a 256-bit key, a 96-bit (12-byte) nonce, and 128-bit (16-byte) tag.

## Asymmetric cryptography

This section includes the following subsections:

* [RSA](#rsa)
* [ECDSA](#ecdsa)
* [ECDH](#ecdh)
* [DSA](#dsa)

### RSA

RSA (Rivest–Shamir–Adleman) key generation is performed by the OS libraries and is subject to their size limitations and performance characteristics.

RSA key operations are performed by the OS libraries, and the types of key that can be loaded are subject to OS requirements.

.NET does not expose "raw" (unpadded) RSA operations.

Padding and digest support vary by platform:

| Padding Mode                 | Windows (CNG)            | Linux (OpenSSL) | macOS  | iOS | Android | Windows (CAPI) |
|------------------------------|--------------------------|-----------------|--------|-----|---------|----------------|
| PKCS1 Encryption             | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ✔️             |
| OAEP - SHA-1                 | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ✔️             |
| OAEP - SHA-2                 | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ❌             |
| OAEP - SHA-3**               | Windows 11 Build 25324+  | OpenSSL 1.1.1+  | ❌     | ❌   | ❌      | ❌             |
| PKCS1 Signature (MD5, SHA-1) | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ✔️             |
| PKCS1 Signature (SHA-2)      | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ⚠️\*           |
| PKCS1 Signature (SHA-3)**    | Windows 11 Build 25324+  | OpenSSL 1.1.1+  | ❌     |  ❌  | ❌      | ❌             |
| PSS                          | ✔️                        | ✔️               | ✔️      | ✔️   | ✔️       | ❌             |


\* Windows CryptoAPI (CAPI) is capable of PKCS1 signature with a SHA-2 algorithm. But the individual RSA object may be loaded in a cryptographic service provider (CSP) that doesn't support it.

\** Requires .NET 8.

#### RSA on Windows

* Windows CryptoAPI (CAPI) is used whenever [`new RSACryptoServiceProvider()`](xref:System.Security.Cryptography.RSACryptoServiceProvider) is used.
* Windows Cryptography API Next Generation (CNG) is used whenever [`new RSACng()`](xref:System.Security.Cryptography.RSACng) is used.
* The object returned by <xref:System.Security.Cryptography.RSA.Create%2A?displayProperty=nameWithType> is internally powered by Windows CNG. This use of Windows CNG is an implementation detail and is subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> returns an <xref:System.Security.Cryptography.RSACng> instance. This use of <xref:System.Security.Cryptography.RSACng> is an implementation detail and is subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> currently prefers an <xref:System.Security.Cryptography.RSACng> instance, but if <xref:System.Security.Cryptography.RSACng> can't open the key, <xref:System.Security.Cryptography.RSACryptoServiceProvider> will be attempted. The preferred provider is an implementation detail and is subject to change.

#### RSA native interop

.NET exposes types to allow programs to interoperate with the OS libraries that the .NET cryptography code uses. The types involved do not translate between platforms, and should only be directly used when necessary.

| Type                                                         | Windows | Linux         | macOS         | iOS             | Android         |
|--------------------------------------------------------------|---------|---------------|---------------|-----------------|-----------------|
| <xref:System.Security.Cryptography.RSACryptoServiceProvider> | ✔️     | ⚠️<sup>1</sup>   | ⚠️<sup>1</sup> | ⚠️<sup>1</sup>   | ⚠️<sup>1</sup>   |
| <xref:System.Security.Cryptography.RSACng>                   | ✔️     | ❌              | ❌             | ❌              | ❌              |
| <xref:System.Security.Cryptography.RSAOpenSsl>               | ❌     | ✔️              | ⚠️<sup>2</sup>  | ❌              | ❌              |

<sup>1</sup> On non-Windows, <xref:System.Security.Cryptography.RSACryptoServiceProvider> can be used for compatibility with existing programs. In that case, any method that requires OS interop, such as opening a named key, throws a <xref:System.PlatformNotSupportedException>.

<sup>2</sup> On macOS, <xref:System.Security.Cryptography.RSAOpenSsl> works if OpenSSL is installed and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

### ECDSA

ECDSA (Elliptic Curve Digital Signature Algorithm) key generation is done by the OS libraries and is subject to their size limitations and performance characteristics.

ECDSA key curves are defined by the OS libraries and are subject to their limitations.

| Elliptic Curve                     | Windows 10    | Windows 7 - 8.1 | Linux         | macOS         | iOS           | Android        |
|------------------------------------|---------------|-----------------|---------------|---------------|---------------|----------------|
| NIST P-256 (secp256r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| NIST P-384 (secp384r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| NIST P-521 (secp521r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| Brainpool curves (as named curves) | ✔️           | ❌              | ⚠️<sup>1</sup>   | ❌             | ❌             | ⚠️<sup>4</sup> |
| Other named curves                 | ⚠️<sup>2</sup>| ❌             | ⚠️<sup>1</sup>   | ❌             | ❌             | ⚠️<sup>4</sup> |
| Explicit curves                    | ✔️           | ❌              | ✔️               | ❌             | ❌             | ✔️             |
| Export or import as explicit       | ✔️           | ❌<sup>3</sup>  | ✔️               | ❌<sup>3</sup> | ❌<sup>3</sup> | ✔️             |

<sup>1</sup> Linux distributions don't all have support for the same named curves.

<sup>2</sup> Support for named curves was added to Windows CNG in Windows 10. For more information, see [CNG Named Elliptic Curves](/windows/win32/seccng/cng-named-elliptic-curves). Named curves are not available in earlier versions of Windows, except for three curves in Windows 7.

<sup>3</sup> Exporting with explicit curve parameters requires OS library support, which is not available on Apple platforms or earlier versions of Windows.

<sup>4</sup> Android support for some curves depends on the Android version. Android distributors may choose to add or remove curves from their Android build as well.

#### ECDSA Native Interop

.NET exposes types to allow programs to interoperate with the OS libraries that the .NET cryptography code uses. The types involved don't translate between platforms and should only be directly used when necessary.

| Type                                             | Windows | Linux | macOS | iOS | Android |
|--------------------------------------------------|---------|-------|-------|-----|---------|
| <xref:System.Security.Cryptography.ECDsaCng>     | ✔️       | ❌    | ❌    | ❌   | ❌      |
| <xref:System.Security.Cryptography.ECDsaOpenSsl> | ❌      | ✔️    | ⚠️\*    | ❌   | ❌      |

\* On macOS, <xref:System.Security.Cryptography.ECDsaOpenSsl> works if OpenSSL is installed in the system and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

### ECDH

ECDH (Elliptic Curve Diffie-Hellman) key generation is done by the OS libraries and is subject to their size limitations and performance characteristics.

The <xref:System.Security.Cryptography.ECDiffieHellman> class supports the "raw" value of the ECDH computation as well as through the following key derivation functions:

* HASH(Z)
* HASH(prepend || Z || append)
* HMAC(key, Z)
* HMAC(key, prepend || Z || append)
* HMAC(Z, Z)
* HMAC(Z, prepend || Z || append)
* Tls11Prf(label, seed)

"Raw" key derivation was introduced in .NET 8.

ECDH key curves are defined by the OS libraries and are subject to their limitations.

| Elliptic Curve                     | Windows 10    | Windows 7 - 8.1 | Linux         | macOS         | iOS           | Android        |
|------------------------------------|---------------|-----------------|---------------|---------------|---------------|----------------|
| NIST P-256 (secp256r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| NIST P-384 (secp384r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| NIST P-521 (secp521r1)             | ✔️           | ✔️              | ✔️                | ✔️             | ✔️             | ✔️              |
| Brainpool curves (as named curves) | ✔️           | ❌              | ⚠️<sup>1</sup>   | ❌             | ❌             | ⚠️<sup>4</sup> |
| Other named curves                 | ⚠️<sup>2</sup>| ❌             | ⚠️<sup>1</sup>   | ❌             | ❌             | ⚠️<sup>4</sup> |
| Explicit curves                    | ✔️           | ❌              | ✔️               | ❌             | ❌             | ✔️             |
| Export or import as explicit       | ✔️           | ❌<sup>3</sup>  | ✔️               | ❌<sup>3</sup> | ❌<sup>3</sup> | ✔️             |

<sup>1</sup> Linux distributions don't all have support for the same named curves.

<sup>2</sup> Support for named curves was added to Windows CNG in Windows 10. For more information, see [CNG Named Elliptic Curves](/windows/win32/seccng/cng-named-elliptic-curves). Named curves are not available in earlier versions of Windows, except for three curves in Windows 7.

<sup>3</sup> Exporting with explicit curve parameters requires OS library support, which is not available on Apple platforms or earlier versions of Windows.

<sup>4</sup> Android support for some curves depends on the Android version. Android distributors may choose to add or remove curves from their Android build as well.

#### ECDH native interop

.NET exposes types to allow programs to interoperate with the OS libraries that .NET uses. The types involved don't translate between platforms and should only be directly used when necessary.

| Type                                                       | Windows | Linux | macOS | iOS | Android  |
|------------------------------------------------------------|---------|-------|-------|-----|----------|
| <xref:System.Security.Cryptography.ECDiffieHellmanCng>     | ✔️     | ❌       | ❌    | ❌  | ❌       |
| <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl> | ❌     | ✔️       | ⚠️\*   | ❌  | ❌       |

\* On macOS, <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl> works if OpenSSL is installed and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

### DSA

DSA (Digital Signature Algorithm) key generation is performed by the system libraries and is subject to their size limitations and performance characteristics.

| Function                      | Windows CNG | Linux | macOS         | Windows CAPI | iOS  | Android |
|-------------------------------|-------------|-------|---------------|--------------|------|---------|
| Key creation (<= 1024 bits)   | ✔️           | ✔️    | ❌             | ✔️            | ❌    | ✔️       |
| Key creation (> 1024 bits)    | ✔️           | ✔️    | ❌             | ❌           | ❌    | ✔️       |
| Loading keys (<= 1024 bits)   | ✔️           | ✔️    | ✔️              | ✔️            | ❌   | ✔️       |
| Loading keys (> 1024 bits)    | ✔️           | ✔️    | ⚠️\*            | ❌           | ❌   | ✔️       |
| FIPS 186-2                    | ✔️           | ✔️    | ✔️              | ✔️            | ❌   | ✔️       |
| FIPS 186-3 (SHA-2 signatures) | ✔️           | ✔️    | ❌             | ❌           | ❌    | ✔️       |

\* macOS loads DSA keys bigger than 1024 bits, but the behavior of those keys is undefined. They don't behave according to FIPS 186-3.

#### DSA on Windows

* Windows CryptoAPI (CAPI) is used whenever [`new DSACryptoServiceProvider()`](xref:System.Security.Cryptography.DSACryptoServiceProvider) is used.
* Windows Cryptography API Next Generation (CNG) is used whenever [`new DSACng()`](xref:System.Security.Cryptography.DSACng) is used.
* The object returned by <xref:System.Security.Cryptography.DSA.Create%2A?displayProperty=nameWithType> is internally powered by Windows CNG. This use of Windows CNG is an implementation detail and is subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> returns a <xref:System.Security.Cryptography.DSACng> instance. This use of <xref:System.Security.Cryptography.DSACng> is an implementation detail and is subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> prefers an <xref:System.Security.Cryptography.DSACng> instance, but if <xref:System.Security.Cryptography.DSACng> can't open the key, <xref:System.Security.Cryptography.DSACryptoServiceProvider> will be attempted.  The preferred provider is an implementation detail and is subject to change.

#### DSA native interop

.NET exposes types to allow programs to interoperate with the OS libraries that the .NET cryptography code uses. The types involved don't translate between platforms and should only be directly used when necessary.

| Type                                                         | Windows | Linux         | macOS         | iOS    | Android       |
|--------------------------------------------------------------|---------|---------------|---------------|--------|---------------|
| <xref:System.Security.Cryptography.DSACryptoServiceProvider> | ✔️       | ⚠️<sup>1</sup> | ⚠️<sup>1</sup>   | ❌    | ⚠️<sup>1</sup> |
| <xref:System.Security.Cryptography.DSACng>                   | ✔️       | ❌             | ❌              | ❌    | ❌            |
| <xref:System.Security.Cryptography.DSAOpenSsl>               | ❌      | ✔️            | ⚠️<sup>2</sup>   | ❌     | ❌             |

<sup>1</sup> On non-Windows, <xref:System.Security.Cryptography.DSACryptoServiceProvider> can be used for compatibility with existing programs. In that case, any method that requires system interop, such as opening a named key, throws a <xref:System.PlatformNotSupportedException>.

<sup>2</sup> On macOS, <xref:System.Security.Cryptography.DSAOpenSsl> works if OpenSSL is installed and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

## X.509 Certificates

The majority of support for X.509 certificates in .NET comes from OS libraries. To load a certificate into an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> or <xref:System.Security.Cryptography.X509Certificates.X509Certificate> instance in .NET, the certificate must be loaded by the underlying OS library.

### Read a PKCS12/PFX

| Scenario                                     | Windows | Linux | macOS | iOS | Android |
|----------------------------------------------|---------|-------|-------|-----|---------|
| Empty                                        | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |
| One certificate, no private key              | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |
| One certificate, with private key            | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |
| Multiple certificates, no private keys       | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |
| Multiple certificates, one private key       | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |
| Multiple certificates, multiple private keys | ✔️       | ✔️     | ✔️     | ✔️   | ✔️       |

### Write a PKCS12/PFX

| Scenario                                     | Windows | Linux | macOS | iOS | Android |
|----------------------------------------------|---------|-------|-------|-------|---------|
| Empty                                        | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| One certificate, no private key              | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| One certificate, with private key            | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| Multiple certificates, no private keys       | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| Multiple certificates, one private key       | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| Multiple certificates, multiple private keys | ✔️       | ✔️     | ✔️     | ✔️     | ✔️       |
| Ephemeral loading                            | ✔️       | ✔️     | ❌    | ✔️     | ✔️       |


macOS can't load certificate private keys without a keychain object, which requires writing to disk. Keychains are created automatically for PFX loading, and are deleted when no longer in use. Since the <xref:System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.EphemeralKeySet?displayProperty=nameWithType> option means that the private key should not be written to disk, asserting that flag on macOS results in a <xref:System.PlatformNotSupportedException>.

### Write a PKCS7 certificate collection

Windows and Linux both emit DER-encoded PKCS7 blobs. macOS emits indefinite-length-CER-encoded PKCS7 blobs.

### X509Store

On Windows, the <xref:System.Security.Cryptography.X509Certificates.X509Store> class is a representation of the Windows Certificate Store APIs. Those APIs work the same in .NET Core and .NET 5 as they do in .NET Framework.

On non-Windows, the <xref:System.Security.Cryptography.X509Certificates.X509Store> class is a projection of system trust decisions (read-only), user trust decisions (read-write), and user key storage (read-write).

The following tables show which scenarios are supported in each platform. For unsupported scenarios (❌ in the tables), a <xref:System.Security.Cryptography.CryptographicException> is thrown.

#### The My store

| Scenario                                         | Windows | Linux | macOS | iOS   | Android |
|--------------------------------------------------|---------|-------|-------|-------|--------|
| Open CurrentUser\My (ReadOnly)                   | ✔️     | ✔️       | ✔️     | ✔️     | ✔️     |
| Open CurrentUser\My (ReadWrite)                  | ✔️     | ✔️       | ✔️     | ✔️     | ✔️     |
| Open CurrentUser\My (ExistingOnly)               | ✔️     | ⚠️       | ✔️     | ✔️     | ✔️     |
| Open LocalMachine\My                             | ✔️     | ❌       | ✔️     | ✔️     | ✔️     |

On Linux, stores are created on first write, and no user stores exist by default, so opening `CurrentUser\My` with `ExistingOnly` may fail.

On macOS, the `CurrentUser\My` store is the user's default keychain, which is `login.keychain` by default. The `LocalMachine\My` store is `System.keychain`.

#### The Root store

| Scenario                              | Windows | Linux | macOS           | iOS | Android        |
|---------------------------------------|---------|-------|-----------------|-----|----------------|
| Open CurrentUser\Root (ReadOnly)      | ✔️       | ✔️     | ✔️               | ❌  | ✔️              |
| Open CurrentUser\Root (ReadWrite)     | ✔️       | ✔️     | ❌              | ❌  | ❌              |
| Open CurrentUser\Root (ExistingOnly)  | ✔️       | ⚠️     | ✔️ (if ReadOnly) | ❌  | ✔️ (if ReadOnly) |
| Open LocalMachine\Root (ReadOnly)     | ✔️       | ✔️     | ✔️               | ❌  | ✔️               |
| Open LocalMachine\Root (ReadWrite)    | ✔️       | ❌     | ❌              | ❌  | ❌              |
| Open LocalMachine\Root (ExistingOnly) | ✔️       | ⚠️     | ✔️ (if ReadOnly) | ❌  | ✔️ (if ReadOnly) |

On Linux, the `LocalMachine\Root` store is an interpretation of the CA bundle in the default path for OpenSSL.

On macOS, the `CurrentUser\Root` store is an interpretation of the `SecTrustSettings` results for the user trust domain. The `LocalMachine\Root` store is an interpretation of the `SecTrustSettings` results for the admin and system trust domains.

#### The Intermediate store

| Scenario                                      | Windows | Linux | macOS           | iOS   | Android |
|-----------------------------------------------|---------|-------|-----------------|-------|---------|
| Open CurrentUser\Intermediate (ReadOnly)      | ✔️       | ✔️    | ✔️                | ❌    | ❌       |
| Open CurrentUser\Intermediate (ReadWrite)     | ✔️       | ✔️    | ❌               | ❌    | ❌       |
| Open CurrentUser\Intermediate (ExistingOnly)  | ✔️       | ⚠️    | ✔️ (if ReadOnly)  | ❌    | ❌       |
| Open LocalMachine\Intermediate (ReadOnly)     | ✔️       | ✔️    | ✔️                | ❌    | ❌       |
| Open LocalMachine\Intermediate (ReadWrite)    | ✔️       | ❌    | ❌               | ❌    | ❌       |
| Open LocalMachine\Intermediate (ExistingOnly) | ✔️       | ⚠️    | ✔️ (if ReadOnly)  | ❌    | ❌       |

On Linux, the `CurrentUser\Intermediate` store is used as a cache when downloading intermediate CAs by their Authority Information Access records on successful X509Chain builds. The `LocalMachine\Intermediate` store is an interpretation of the CA bundle in the default path for OpenSSL.

On macOS, the `CurrentUser\Intermediate` store is treated as a custom store. Certificates added to this store do not affect X.509 chain building.

#### The Disallowed store

| Scenario                                    | Windows | Linux | macOS           | iOS             | Android         |
|---------------------------------------------|---------|-------|-----------------|-----------------|-----------------|
| Open CurrentUser\Disallowed (ReadOnly)      | ✔️     | ⚠️       | ✔️               | ✔️               | ✔️               |
| Open CurrentUser\Disallowed (ReadWrite)     | ✔️     | ⚠️       | ❌              | ❌               | ❌               |
| Open CurrentUser\Disallowed (ExistingOnly)  | ✔️     | ⚠️       | ✔️ (if ReadOnly) | ✔️ (if ReadOnly) | ✔️ (if ReadOnly) |
| Open LocalMachine\Disallowed (ReadOnly)     | ✔️     | ❌       | ✔️              | ✔️               | ✔️               |
| Open LocalMachine\Disallowed (ReadWrite)    | ✔️     | ❌       | ❌             | ❌               | ❌               |
| Open LocalMachine\Disallowed (ExistingOnly) | ✔️     | ❌       | ✔️ (if ReadOnly)| ✔️ (if ReadOnly) | ✔️ (if ReadOnly) |

On Linux, the `Disallowed` store is not used in chain building, and attempting to add contents to it results in a <xref:System.Security.Cryptography.CryptographicException>. A <xref:System.Security.Cryptography.CryptographicException> is thrown when opening the `Disallowed` store if it has already acquired contents.

On macOS, the CurrentUser\Disallowed and LocalMachine\Disallowed stores are interpretations of the appropriate SecTrustSettings results for certificates whose trust is set to `Always Deny`.

#### Nonexistent store

| Scenario                                         | Windows | Linux | macOS | iOS | Android |
|--------------------------------------------------|---------|-------|-------|-----|---------|
| Open non-existent store (ExistingOnly)           | ❌     | ❌     | ❌    | ❌   | ❌      |
| Open CurrentUser non-existent store (ReadWrite)  | ✔️     | ✔️     | ⚠️      | ❌   | ❌      |
| Open LocalMachine non-existent store (ReadWrite) | ✔️     | ❌     | ❌    | ❌    | ❌      |

On macOS, custom store creation with the X509Store API is supported only for `CurrentUser` location. It will create a new keychain with no password in the user's keychain directory (*~/Library/Keychains*). To create a keychain with password, a P/Invoke to `SecKeychainCreate` could be used. Similarly, `SecKeychainOpen` could be used to open keychains in different locations. The resulting `IntPtr` can be passed to [`new X509Store(IntPtr)`](xref:System.Security.Cryptography.X509Certificates.X509Store.%23ctor(System.IntPtr)) to obtain a read/write-capable store, subject to the current user's permissions.

### X509Chain

macOS doesn't support Offline CRL utilization, so `X509RevocationMode.Offline` is treated as `X509RevocationMode.Online`.

macOS doesn't support a user-initiated timeout on CRL (Certificate Revocation List) / OCSP (Online Certificate Status Protocol) / AIA (Authority Information Access) downloading, so `X509ChainPolicy.UrlRetrievalTimeout` is ignored.

## Additional resources

* [.NET Cryptography Model](cryptography-model.md)
* [.NET Cryptographic Services](cryptographic-services.md)
* [Timing vulnerabilities with CBC-mode symmetric decryption using padding](vulnerabilities-cbc-mode.md)
* [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
