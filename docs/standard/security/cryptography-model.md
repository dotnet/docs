---
title: ".NET Framework Cryptography Model"
description: Review implementations of usual cryptographic algorithms in .NET. Learn the extensible cryptography model of object inheritance, stream design, & configuration.
ms.date: "03/30/2017"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "cryptography [.NET], model"
  - "encryption [.NET], model"
ms.assetid: 12fecad4-fbab-432a-bade-2f05976a2971
---
# .NET Framework Cryptography Model

.NET provides implementations of many standard cryptographic algorithms. These algorithms have the safest possible default properties. In addition, the .NET cryptography model of object inheritance and configuration is extensible.

## Object Inheritance

The .NET cryptography system implements an extensible pattern of derived class inheritance. The hierarchy is as follows:

- Algorithm type class, such as <xref:System.Security.Cryptography.SymmetricAlgorithm>,  <xref:System.Security.Cryptography.AsymmetricAlgorithm>, or <xref:System.Security.Cryptography.HashAlgorithm>. This level is abstract.

- Algorithm class that inherits from an algorithm type class; for example, <xref:System.Security.Cryptography.Aes>, <xref:System.Security.Cryptography.RC2>, or <xref:System.Security.Cryptography.ECDiffieHellman>. This level is abstract.

- Implementation of an algorithm class that inherits from an algorithm class; for example, <xref:System.Security.Cryptography.AesManaged>, <xref:System.Security.Cryptography.RC2CryptoServiceProvider>, or <xref:System.Security.Cryptography.ECDiffieHellmanCng>. This level is fully implemented.

This pattern of derived classes lets you add a new algorithm or a new implementation of an existing algorithm. For example, to create a new public-key algorithm, you would inherit from the <xref:System.Security.Cryptography.AsymmetricAlgorithm> class. To create a new implementation of a specific algorithm, you would create a non-abstract derived class of that algorithm.

## How Algorithms Are Implemented in .NET

As an example of the different implementations available for an algorithm, consider symmetric algorithms. The base for all symmetric algorithms is <xref:System.Security.Cryptography.SymmetricAlgorithm>, which is inherited by the following algorithms:

* <xref:System.Security.Cryptography.Aes>
* <xref:System.Security.Cryptography.DES>
* <xref:System.Security.Cryptography.RC2>
* <xref:System.Security.Cryptography.Rijndael>
* <xref:System.Security.Cryptography.TripleDES>

<xref:System.Security.Cryptography.Aes> is inherited by two classes: <xref:System.Security.Cryptography.AesCryptoServiceProvider> and <xref:System.Security.Cryptography.AesManaged>.

In the .NET Framework on Windows:

* `*CryptoServiceProvider` algorithm classes, such as <xref:System.Security.Cryptography.AesCryptoServiceProvider>, are wrappers around the Windows Cryptography API (CAPI) implementation of an algorithm.
* `*Cng` algorithm classes, such as <xref:System.Security.Cryptography.ECDiffieHellmanCng> are wrappers around the Windows Cryptography Next Generation (CNG) implementation. CNG algorithms are available on Windows Vista and later.
* `*Managed` classes, such as <xref:System.Security.Cryptography.AesManaged>, are written entirely in managed code. `*Managed` implementations are not certified by the Federal Information Processing Standards (FIPS), and may be slower than the `*CryptoServiceProvider` and `*Cng` wrapper classes.

In .NET Core and .NET 5 and later versions, all implementation classes (`*CryptoServiceProvider`, `*Managed`, and `*Cng`) are wrappers for the operating system (OS) algorithms. If the OS algorithms are FIPS-certified, then .NET uses FIPS-certified algorithms. For more information, see [Cross-Platform Cryptography](cross-platform-cryptography.md).

## Cryptographic Configuration

Cryptographic configuration lets you resolve a specific implementation of an algorithm to an algorithm name, allowing extensibility of the .NET cryptography classes. You can add your own hardware or software implementation of an algorithm and map the implementation to the algorithm name of your choice. If an algorithm is not specified in the configuration file, the default settings are used. For more information about cryptographic configuration, see [Configuring Cryptography Classes](../../framework/configure-apps/configure-cryptography-classes.md).

## Choosing an Algorithm

You can select an algorithm for different reasons: for example, for data integrity, for data privacy, or to generate a key. Symmetric and hash algorithms are intended for protecting data for either integrity reasons (protect from change) or privacy reasons (protect from viewing). Hash algorithms are used primarily for data integrity.

Here is a list of recommended algorithms by application:

- Data privacy:
  - <xref:System.Security.Cryptography.Aes>
- Data integrity:
  - <xref:System.Security.Cryptography.HMACSHA256>
  - <xref:System.Security.Cryptography.HMACSHA512>
- Digital signature:
  - <xref:System.Security.Cryptography.ECDsa>
  - <xref:System.Security.Cryptography.RSA>
- Key exchange:
  - <xref:System.Security.Cryptography.ECDiffieHellman>
  - <xref:System.Security.Cryptography.RSA>
- Random number generation:
  - <xref:System.Security.Cryptography.RandomNumberGenerator.Create%2A?displayProperty=nameWithType>
- Generating a key from a password:
  - <xref:System.Security.Cryptography.Rfc2898DeriveBytes>

## See also

- [Cryptographic Services](cryptographic-services.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
