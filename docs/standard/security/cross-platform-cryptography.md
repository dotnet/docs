---
title: "Cross-platform cryptography in .NET Core"
description: Learn about cryptographic capabilities on platforms supported by .NET.
ms.date: "06/19/2020"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "cryptography, cross-platform"
  - "encryption, cross-platform"
---
# Cross-Platform Cryptography in .NET Core

Cryptographic operations in .NET are performed by existing operating system (OS) libraries. As a result of this dependency:

* .NET apps benefit from OS reliability. The OS has a vested interest in keeping its cryptography libraries safe from security vulnerabilities, and it has an update mechanism that system administrators should be using.
* .NET apps automatically have access to FIPS-validated algorithms if the OS libraries are FIPS-validated.
* The cryptographic capabilities of .NET vary depending on what the OS supports. While all platforms support certain core capabilities, there are significant gaps in some platforms.

## Hash algorithms

All hash algorithm and HMAC classes in .NET Core, including the \*Managed classes, defer to the OS libraries. While the various OS libraries may have different performance, they should be compatible.

In the future, new hash algorithms may be added to .NET Core before all platforms have support for them. On platforms that don't support an algorithm, its `Create()` method will throw a <xref:System.PlatformNotSupportedException>.

## Symmetric encryption

The underlying ciphers and chaining are performed by the system libraries.

| Cipher + Mode | Windows | Linux | macOS |
|---------------|---------|-------|-------|
| AES-CBC       | ✔️     | ✔️    | ✔️   |
| AES-ECB       | ✔️     | ✔️    | ✔️   |
| 3DES-CBC      | ✔️     | ✔️    | ✔️   |
| 3DES-ECB      | ✔️     | ✔️    | ✔️   |
| DES-CBC       | ✔️     | ✔️    | ✔️   |
| DES-ECB       | ✔️     | ✔️    | ✔️   |

In the future, new ciphers may be added to .NET Core before all platforms have support for them. On platforms that don't support a cipher, its `Create()` method will throw a <xref:System.PlatformNotSupportedException>.

In the future, new cipher/chaining modes may be added to .NET Core before all platforms have support for them. On platforms that don't support a cipher/chaining mode, the `CreateEncryptor()` or `CreateDecryptor()` methods will throw a <xref:System.PlatformNotSupportedException>.

In the future, new cipher/chaining modes may be added to .NET Core before all platforms support them for all symmetric algorithms. This would likely result in a <xref:System.NotSupportedException> when using the set-accessor of the <xref:System.Security.Cryptography.SymmetricAlgorithm.Mode%2A> property on the <xref:System.Security.Cryptography.SymmetricAlgorithm> object.

## Authenticated encryption

Authenticated encryption (AE) support is provided for AES-CCM and AES-GCM via <xref:System.Security.Cryptography.AesCcm?displayProperty=fullName> and <xref:System.Security.Cryptography.AesGcm?displayProperty=fullName>, respectively. On Windows and Linux the implementations of AES-CCM and AES-GCM are provided by the OS libraries.

On macOS the system libraries do not support AES-CCM or AES-GCM for 3rd party code, so the `AesCcm` and `AesGcm` classes use OpenSSL for support. Users on macOS need to obtain an appropriate copy of OpenSSL (libcrypto) for these types to function, and it must be in a path that the system would load a library from by default.

Obtaining OpenSSL from a package manager, such as Homebrew, is recommended but not required.
The `libcrypto.0.9.7.dylib` and `libcrypto.0.9.8.dylib` libraries included in macOS are from older versions of OpenSSL and will not be used. The `libcrypto.35.dylib`, `libcrypto.41.dylib`, and `libcrypto.42.dylib` libraries are LibreSSL and will not be used.

### AES-GCM

* Key Sizes

  AES-GCM works with 128, 192, and 256-bit keys.

* Nonce Sizes

  The AesGcm class supports only 96-bit (12 byte) nonces.

* Tag Sizes

  The AesGcm class supports creating or processing 96, 104, 112, 120, and 128-bit (12-16 bytes) tags.

### AES-CCM

* Key Sizes

  AES-CCM works with 128, 192, and 256-bit keys.

* Nonce Sizes

  The AesCcm class supports 56, 64, 72, 80, 88, 96, and 104-bit nonces (7-13 bytes).

* Tag Sizes

  The AesCcm class supports creating or processing 32, 48, 64, 80, 96, 112, and 128-bit (4, 8, 10, 12, 14, and 16-byte) tags.

## Asymmetric cryptography

This section includes the following subsections:

* [RSA](#rsa)
* [ECDSA](#ecdsa)
* [ECDiffieHellman (ECDH)](#ecdiffiehellman-ecdh)
* [DSA](#dsa)
* [X.509 Certificates](#x509-certificates)
* [Reading a PKCS12/PFX](#reading-a-pkcs12pfx)
* [Writing a PKCS12/PFX](#writing-a-pkcs12pfx)
* [X509Store](#x509store)
* [X509Chain](#x509chain)

### RSA

RSA key generation is performed by the OS libraries and is subject to their size limitations and performance characteristics.

RSA key operations are performed by the OS libraries, and the types of key that may be loaded are subject to OS requirements.

.NET Core does not expose "raw" (unpadded) RSA operations, and .NET Core relies on the OS libraries for encryption and decryption padding.

Not all platforms support the same padding options.

| Padding Mode                          | Windows (CNG) | Linux (OpenSSL) | macOS | Windows (CAPI) |
|---------------------------------------|---------------|-----------------|-------|----------------|
| PKCS1 Encryption                      | ✔️           | ✔️              | ✔️   | ✔️             |
| OAEP - SHA-1                          | ✔️           | ✔️              | ✔️   | ✔️             |
| OAEP - SHA-2 (SHA256, SHA384, SHA512) | ✔️           | ✔️              | ✔️   | ❌             |
| PKCS1 Signature (MD5, SHA-1)          | ✔️           | ✔️              | ✔️   | ✔️             |
| PKCS1 Signature (SHA-2)               | ✔️           | ✔️              | ✔️   | ⚠️             |
| PSS                                   | ✔️           | ✔️              | ✔️   | ❌             |

Windows CAPI is capable of PKCS1 signature with a SHA-2 algorithm, but the individual RSA object may be loaded in a CSP that doesn't support it.

#### RSA on Windows

* Windows CNG is used on Windows whenever [`new RSACng()`](xref:System.Security.Cryptography.RSACng) is used.
* Windows CAPI is used on Windows whenever [`new RSACryptoServiceProvider()`](xref:System.Security.Cryptography.RSACryptoServiceProvider) is used.
* The object returned by <xref:System.Security.Cryptography.RSA.Create%2A?displayProperty=nameWithType> is internally powered by Windows CNG. This is an implementation detail subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPublicKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> currently returns an <xref:System.Security.Cryptography.RSACng> instance, but this could change in the future.
* The <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> currently prefers an <xref:System.Security.Cryptography.RSACng> instance, but if <xref:System.Security.Cryptography.RSACng> can't open the key, <xref:System.Security.Cryptography.RSACryptoServiceProvider> will be attempted. In the future, other providers could be preferred over <xref:System.Security.Cryptography.RSACng>.

#### RSA Native interop

.NET Core exposes types to allow programs to interoperate with the OS libraries upon which the .NET cryptography code is layered.

The types involved do not translate between platforms, and should only be directly used when necessary.

| Type                                                         | Windows | Linux | macOS |
|--------------------------------------------------------------|---------|-------|-------|
| <xref:System.Security.Cryptography.RSACryptoServiceProvider> | ✔️     | ⚠️    | ⚠️   |
| <xref:System.Security.Cryptography.RSACng>                   | ✔️     | ❌     | ❌    |
| <xref:System.Security.Cryptography.RSAOpenSsl>               | ❌      | ✔️    | ⚠️   |

RSAOpenSsl on macOS works if OpenSSL is installed in the system and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

On non-Windows systems, <xref:System.Security.Cryptography.RSACryptoServiceProvider> can be used for compatibility with existing programs. In that case, any method that requires system interop, such as opening a named key, throws a <xref:System.PlatformNotSupportedException>.

### ECDSA

ECDSA key generation is performed by the OS libraries and is subject to their size limitations and performance characteristics.

ECDSA key curves are defined by the OS libraries and are subject to their limitations.

| EC Curve                           | Windows 10 | Windows 7 - 8.1 | Linux | macOS |
|------------------------------------|------------|-----------------|-------|-------|
| NIST P-256 (secp256r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| NIST P-384 (secp384r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| NIST P-521 (secp521r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| brainpool curves (as named curves) | ✔️        | ❌              | ⚠️   | ❌    |
| other named curves                 | ⚠️        | ❌              | ⚠️   | ❌    |
| explicit curves                    | ✔️        | ❌              | ✔️   | ❌    |
| Export or import as explicit       | ✔️        | ❌              | ✔️   | ❌    |

Support for named curves was added to Windows CNG in Windows 10. For more information, see [CNG Named Elliptic Curves](https://msdn.microsoft.com/library/windows/desktop/mt632245(v=vs.85).aspx). Named curves are not available in earlier versions of Windows except for special support for three curves in Windows 7.

Not all Linux distributions have support for the same named curves.

Exporting with explicit curve parameters requires OS library support which is not available on macOS or older versions of Windows.

#### ECDSA Native Interop

.NET Core exposes types to allow programs to interoperate with the OS libraries upon which the .NET cryptography code is layered.

The types involved do not translate between platforms, and should only be directly used when necessary.

| Type                                             | Windows | Linux | macOS |
|--------------------------------------------------|---------|-------|-------|
| <xref:System.Security.Cryptography.ECDsaCng>     | ✔️     | ❌     | ❌    |
| <xref:System.Security.Cryptography.ECDsaOpenSsl> | ❌      | ✔️    | ⚠️   |

<xref:System.Security.Cryptography.ECDsaOpenSsl> on macOS works if OpenSSL is installed in the system and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

### ECDiffieHellman (ECDH)

ECDH key generation is performed by the OS libraries and is subject to their size limitations and performance characteristics.

The <xref:System.Security.Cryptography.ECDiffieHellman> class doesn't return the "raw" value of the ECDH computation. All returned data is in terms of key derivation functions.

* HASH(Z)
* HASH(prepend || Z || append)
* HMAC(key, Z)
* HMAC(key, prepend || Z || append)
* HMAC(Z, Z)
* HMAC(Z, prepend || Z || append)
* Tls11Prf(label, seed)

ECDH key curves are defined by the OS libraries and are subject to their limitations.

| EC Curve                           | Windows 10 | Windows 7 - 8.1 | Linux | macOS |
|------------------------------------|------------|-----------------|-------|-------|
| NIST P-256 (secp256r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| NIST P-384 (secp384r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| NIST P-521 (secp521r1)             | ✔️        | ✔️              | ✔️   | ✔️    |
| brainpool curves (as named curves) | ✔️        | ❌               | ⚠️   | ❌     |
| other named curves                 | ⚠️        | ❌               | ⚠️   | ❌     |
| explicit curves                    | ✔️        | ❌               | ✔️   | ❌     |
| Export or import as explicit       | ✔️        | ❌               | ✔️   | ❌     |

Support for named curves was added to Windows CNG in Windows 10. For more information, see [CNG Named Elliptic Curves](https://msdn.microsoft.com/library/windows/desktop/mt632245(v=vs.85).aspx). Named curves are not available in earlier versions of Windows except for special support for three curves in Windows 7.

Not all Linux distributions have support for the same named curves.

Exporting with explicit curve parameters requires OS library support, which is not available on macOS or older versions of Windows.

#### ECDH Native Interop

.NET Core exposes types to allow programs to interoperate with the system libraries upon which the .NET cryptography code is layered. The types involved do not translate between platforms, and should only be directly used when necessary.

| Type                                                       | Windows | Linux | macOS |
|------------------------------------------------------------|---------|-------|-------|
| <xref:System.Security.Cryptography.ECDiffieHellmanCng>     | ✔️     | ❌    | ❌   |
| <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl> | ❌     | ✔️    | ⚠️   |

<xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl> on macOS works if OpenSSL is installed in the system and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

### DSA

DSA key generation is performed by the system libraries, and is subject to size limitations and performance characteristics thereof.

| Function                      | Windows CNG | Linux | macOS | Windows CAPI |
|-------------------------------|-------------|-------|-------|--------------|
| Key creation (<= 1024 bits)   | ✔️         | ✔️    | ❌    | ✔️           |
| Key creation (> 1024 bits)    | ✔️         | ✔️    | ❌    | ❌           |
| Loading keys (<= 1024 bits)   | ✔️         | ✔️    | ✔️    | ✔️           |
| Loading keys (> 1024 bits)    | ✔️         | ✔️    | ⚠️    | ❌           |
| FIPS 186-2                    | ✔️         | ✔️    | ✔️    | ✔️           |
| FIPS 186-3 (SHA-2 signatures) | ✔️         | ✔️    | ❌    | ❌           |

macOS loads DSA keys whose size exceeds 1024 bits, but it doesn't perform FIPS 186-3 behaviors with those keys, so the behavior of those keys is undefined.

#### DSA on Windows

* Windows CNG is used on Windows whenever [`new DSACng()`](xref:System.Security.Cryptography.DSACng) is used.
* Windows CAPI is used on Windows whenever [`new DSACryptoServiceProvider()`](xref:System.Security.Cryptography.DSACryptoServiceProvider) is used.
* The object returned by <xref:System.Security.Cryptography.DSA.Create%2A?displayProperty=nameWithType> is internally powered by Windows CNG. This is an implementation detail subject to change.
* The <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPublicKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> currently returns a <xref:System.Security.Cryptography.DSACng> instance, but this could change in the future.
* The <xref:System.Security.Cryptography.X509Certificates.DSACertificateExtensions.GetDSAPrivateKey%2A> extension method for <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> currently prefers an <xref:System.Security.Cryptography.DSACng> instance, but if <xref:System.Security.Cryptography.DSACng> can't open the key, <xref:System.Security.Cryptography.DSACryptoServiceProvider> will be attempted. In the future, other providers could be preferred over <xref:System.Security.Cryptography.RSACng>.

### DSA Native Interop

.NET Core exposes types to allow programs to interoperate with the OS libraries upon which the .NET cryptography code is layered.

The types involved do not translate between platforms, and should only be directly used when necessary.

| Type                                                         | Windows | Linux | macOS |
|--------------------------------------------------------------|---------|-------|-------|
| <xref:System.Security.Cryptography.DSACryptoServiceProvider> | ✔️     | ⚠️    | ⚠️   |
| <xref:System.Security.Cryptography.DSACng>                   | ✔️     | ❌    | ❌   |
| <xref:System.Security.Cryptography.DSAOpenSsl>               | ❌     | ✔️    | ⚠️   |

<xref:System.Security.Cryptography.DSAOpenSsl> on macOS works if OpenSSL is installed in the system and an appropriate libcrypto dylib can be found via dynamic library loading. If an appropriate library can't be found, exceptions will be thrown.

On non-Windows systems, <xref:System.Security.Cryptography.DSACryptoServiceProvider> can be used for compatibility with existing programs. In that case, any method that requires system interop, such as opening a named key, throws a <xref:System.PlatformNotSupportedException>.

### X.509 Certificates

The majority of support for X.509 certificates in .NET Core comes from OS libraries. To load a certificate into an <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> or <xref:System.Security.Cryptography.X509Certificates.X509Certificate> instance in .NET Core, the certificate must be loaded by the underlying OS library.

### Reading a PKCS12/PFX

| Scenario                                     | Windows | Linux | macOS |
|----------------------------------------------|---------|-------|-------|
| Empty                                        | ✔️     | ✔️    | ✔️   |
| One certificate, no private key              | ✔️     | ✔️    | ✔️   |
| One certificate, with private key            | ✔️     | ✔️    | ✔️   |
| Multiple certificates, no private keys       | ✔️     | ✔️    | ✔️   |
| Multiple certificates, one private key       | ✔️     | ✔️    | ✔️   |
| Multiple certificates, multiple private keys | ✔️     | ❌     | ✔️   |

### Writing a PKCS12/PFX

| Scenario                                     | Windows | Linux | macOS |
|----------------------------------------------|---------|-------|-------|
| Empty                                        | ✔️     | ✔️    | ❌    |
| One certificate, no private key              | ✔️     | ✔️    | ❌    |
| One certificate, with private key            | ✔️     | ✔️    | ✔️   |
| Multiple certificates, no private keys       | ✔️     | ✔️    | ❌    |
| Multiple certificates, one private key       | ✔️     | ✔️    | ✔️   |
| Multiple certificates, multiple private keys | ✔️     | ❌     | ✔️   |
| Ephemeral loading                            | ✔️     | ✔️    | ❌    |

macOS can't load certificate private keys without a keychain object, which requires writing to disk. Keychains are created automatically for PFX loading, and are deleted when no longer in use. Since the <xref:System.Security.Cryptography.X509Certificates.X509KeyStorageFlags.EphemeralKeySet?displayProperty=nameWithType> option means that the private key should not be written to disk, asserting that flag on macOS results in a PlatformNotSupportedException<xref:System.PlatformNotSupportedException>.

### Writing a PKCS7 certificate collection

Windows and Linux both emit DER-encoded PKCS7 blobs. macOS emits indefinite-length-CER-encoded PKCS7 blobs.

### X509Store

On Windows, the <xref:System.Security.Cryptography.X509Certificates.X509Store> class is a representation of the Windows Certificate Store APIs, and work the same in .NET Core as they do on .NET Framework.

On Linux, the <xref:System.Security.Cryptography.X509Certificates.X509Store> class is a projection of system trust decisions (read-only), user trust decisions (read-write), and user key storage (read-write).

On macOS, the <xref:System.Security.Cryptography.X509Certificates.X509Store> class is a projection of system trust decisions (read-only), user trust decisions (read-only), and user key storage (read-write).

| Scenario                                         | Windows | Linux | macOS            |
|--------------------------------------------------|---------|-------|------------------|
| Open CurrentUser\My (ReadOnly)                   | ✔️     | ✔️    | ✔️              |
| Open CurrentUser\My (ReadWrite)                  | ✔️     | ✔️    | ✔️              |
| Open CurrentUser\My (ExistingOnly)               | ✔️     | ⚠️    | ✔️              |
| Open LocalMachine\My                             | ✔️     | ❌     | ✔️              |
| Open CurrentUser\Root (ReadOnly)                 | ✔️     | ✔️    | ✔️              |
| Open CurrentUser\Root (ReadWrite)                | ✔️     | ✔️    | ❌               |
| Open CurrentUser\Root (ExistingOnly)             | ✔️     | ⚠️    | ✔️ (if ReadOnly) |
| Open LocalMachine\Root (ReadOnly)                | ✔️     | ✔️    | ✔️              |
| Open LocalMachine\Root (ReadWrite)               | ✔️     | ❌     | ❌               |
| Open LocalMachine\Root (ExistingOnly)            | ✔️     | ⚠️    | ✔️  (if ReadOnly) |
| Open CurrentUser\Disallowed (ReadOnly)           | ✔️     | ⚠️    | ✔️              |
| Open CurrentUser\Disallowed (ReadWrite)          | ✔️     | ⚠️    | ❌               |
| Open CurrentUser\Disallowed (ExistingOnly)       | ✔️     | ⚠️    | ✔️ (if ReadOnly) |
| Open LocalMachine\Disallowed (ReadOnly)          | ✔️     | ❌     | ✔️              |
| Open LocalMachine\Disallowed (ReadWrite)         | ✔️     | ❌     | ❌               |
| Open LocalMachine\Disallowed (ExistingOnly)      | ✔️     | ❌     | ✔️ (if ReadOnly) |
| Open non-existant store (ExistingOnly)           | ❌      | ❌     | ❌               |
| Open CurrentUser non-existant store (ReadWrite)  | ✔️     | ✔️    | ❌               |
| Open LocalMachine non-existant store (ReadWrite) | ✔️     | ❌     | ❌               |

❌ in the table means a <xref:System.Security.Cryptography.CryptographicException> is thrown.

On Linux, stores are created on first write, and no user stores exist by default, so opening `CurrentUser\My` with `ExistingOnly` may fail.

On Linux, the Disallowed store is not used in chain building, and attempting to add contents to it results in a <xref:System.Security.Cryptography.CryptographicException>. A <xref:System.Security.Cryptography.CryptographicException> will be thrown when opening the Disallowed store on Linux if it has already acquired contents.

The LocalMachine\Root store on Linux is an interpretation of the CA bundle in the default path for OpenSSL.
The LocalMachine\Intermediate store on Linux is an interpretation of the CA bundle in the default path for OpenSSL.
The CurrentUser\Intermediate store on Linux is used as a cache when downloading intermediate CAs by their Authority Information Access records on successful X509Chain builds.

On macOS the CurrentUser\My store is the user's default keychain (login.keychain, by default).
The LocalMachine\My store is System.keychain.
The CurrentUser\Root store on macOS is an interpretation of the SecTrustSettings results for the user trust domain.
The LocalMachine\Root store on macOS is an interpretation of the SecTrustSettings results for the admin and system trust domains.
The CurrentUser\Disallowed and LocalMachine\Disallowed stores are interpretations of the appropriate SecTrustSettings results for certificates whose trust is set to Always Deny.
Custom store creation on macOS with the X509Store API is supported only for CurrentUser location. It will create a new keychain with no password in the user's keychain
directory (~/Library/Keychains). To create a keychain with password a P/Invoke to SecKeychainCreate could be used. Similarly, SecKeychainOpen could be used to open keychains
in different locations. The resulting `IntPtr` can be passed to `new X509Store(IntPtr)` to obtain a read/write-capable store (subject to the current user's permissions).

### X509Chain

macOS does not support Offline CRL utilization, so `X509RevocationMode.Offline` is treated as `X509RevocationMode.Online`.
macOS does not support a user-initiated timeout on CRL/OCSP/AIA downloading, so `X509ChainPolicy.UrlRetrievalTimeout` is ignored.
