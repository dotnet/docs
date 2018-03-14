---
title: "Mapping Object Identifiers to Cryptography Algorithms"
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
  - "digital signatures"
  - "identifiers, mapping object identifiers"
  - "cryptographic algorithms"
  - "mapping object identifiers"
  - "cryptography, mapping object identifiers"
ms.assetid: c9673f81-bf9e-47fd-bc6f-6bc1c1c4c15e
caps.latest.revision: 8
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Mapping Object Identifiers to Cryptography Algorithms
Digital signatures ensure that data is not tampered with when it is sent from one program to another. Typically the digital signature is computed by applying a mathematical function to the hash of the data to be signed. When formatting a hash value to be signed, some digital signature algorithms append an ASN.1 Object Identifier (OID) as part of the formatting operation. The OID identifies the algorithm that was used to compute the hash. You can map algorithms to object identifiers to extend the cryptography mechanism to use custom algorithms. The following example shows how to map an object identifier to a new hash algorithm.  
  
```xml  
<configuration>  
   <mscorlib>  
      <cryptographySettings>  
         <cryptoNameMapping>  
            <cryptoClasses>  
               <cryptoClass MyNewHash="MyNewHashClass, MyAssembly  
                  Culture='en', PublicKeyToken=a5d015c7d5a0b012,  
                  Version=1.0.0.0"/>  
            </cryptoClasses>  
            <nameEntry name="NewHash" class="MyNewHash"/>  
         </cryptoNameMapping>  
         <oidMap>  
            <oidEntry OID="1.3.14.33.42.46"  name="NewHash"/>  
         </oidMap>  
      </cryptographySettings>  
   </mscorlib>  
</configuration>  
```  
  
 The [\<oidEntry> element](../../../docs/framework/configure-apps/file-schema/cryptography/oidentry-element.md) contains two attributes. The **OID** attribute is the object identifier number. The **name** attribute is the value of the **name** attribute from the [\<nameEntry> element](../../../docs/framework/configure-apps/file-schema/cryptography/nameentry-element.md). There must be a mapping from an algorithm name to a class before an object identifier can be mapped to a simple name.  
  
## See Also  
 [Configuring Cryptography Classes](../../../docs/framework/configure-apps/configure-cryptography-classes.md)  
 [Cryptographic Services](../../../docs/standard/security/cryptographic-services.md)
