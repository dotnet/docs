---
title: "Configuring Cryptography Classes"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "configuration files [.NET Framework], cryptography"
  - "cryptographic algorithms"
  - "security [.NET Framework], encryption"
  - "cryptography, classes"
  - ".NET Framework application configuration, cryptography"
  - "default cryptography"
ms.assetid: eee3ccb8-2c0d-4f35-b38d-6892a46c14e5
---
# Configuring Cryptography Classes
The Windows SDK allows computer administrators to configure the default cryptographic algorithms and algorithm implementations that the .NET Framework and appropriately written applications use.  For example, an enterprise that has its own implementation of a cryptographic algorithm can make that implementation the default instead of the implementation shipped in the Windows SDK. Although managed applications that use cryptography can always choose to explicitly bind to a particular implementation, it is recommended that they create cryptographic objects by using the crypto configuration system.  
  
## In This Section  
 [Mapping Algorithm Names to Cryptography Classes](map-algorithm-names-to-cryptography-classes.md)  
 Describes how to map an algorithm name to a cryptography class.  
  
 [Mapping Object Identifiers to Cryptography Algorithms](map-object-identifiers-to-cryptography-algorithms.md)  
 Describes how to map an object identifier to a cryptography algorithm.  
  
## Related Sections  
 [Cryptographic Services](../../standard/security/cryptographic-services.md)  
 Provides an overview of cryptographic services provided by the Windows SDK.  
  
 [Cryptography Settings Schema](./file-schema/cryptography/index.md)  
 Describes elements that map friendly algorithm names to classes that implement cryptography algorithms.
