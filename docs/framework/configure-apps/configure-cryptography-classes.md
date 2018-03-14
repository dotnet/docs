---
title: "Configuring Cryptography Classes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "configuration files [.NET Framework], cryptography"
  - "cryptographic algorithms"
  - "security [.NET Framework], encryption"
  - "cryptography, classes"
  - ".NET Framework application configuration, cryptography"
  - "default cryptography"
ms.assetid: eee3ccb8-2c0d-4f35-b38d-6892a46c14e5
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Configuring Cryptography Classes
The [!INCLUDE[winsdklong](../../../includes/winsdklong-md.md)] allows computer administrators to configure the default cryptographic algorithms and algorithm implementations that the .NET Framework and appropriately written applications use.  For example, an enterprise that has its own implementation of a cryptographic algorithm can make that implementation the default instead of the implementation shipped in the [!INCLUDE[winsdkshort](../../../includes/winsdkshort-md.md)]. Although managed applications that use cryptography can always choose to explicitly bind to a particular implementation, it is recommended that they create cryptographic objects by using the crypto configuration system.  
  
## In This Section  
 [Mapping Algorithm Names to Cryptography Classes](../../../docs/framework/configure-apps/map-algorithm-names-to-cryptography-classes.md)  
 Describes how to map an algorithm name to a cryptography class.  
  
 [Mapping Object Identifiers to Cryptography Algorithms](../../../docs/framework/configure-apps/map-object-identifiers-to-cryptography-algorithms.md)  
 Describes how to map an object identifier to a cryptography algorithm.  
  
## Related Sections  
 [Cryptographic Services](../../../docs/standard/security/cryptographic-services.md)  
 Provides an overview of cryptographic services provided by the [!INCLUDE[winsdkshort](../../../includes/winsdkshort-md.md)].  
  
 [Cryptography Settings Schema](../../../docs/framework/configure-apps/file-schema/cryptography/index.md)  
 Describes elements that map friendly algorithm names to classes that implement cryptography algorithms.
