---
title: "Enhanced Strong Naming"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "strong-named assemblies"
  - "strong naming [.NET Framework], enhanced"
ms.assetid: 6cf17a82-62a1-4f6d-8d5a-d7d06dec2bb5
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Enhanced Strong Naming
A strong name signature is an identity mechanism in the .NET Framework for identifying assemblies. It is a public-key digital signature that is typically used to verify the integrity of data being passed from an originator (signer) to a recipient (verifier). This signature is used as a unique identity for an assembly and ensures that references to the assembly are not ambiguous. The assembly is signed as part of the build process and then verified when it is loaded.  
  
 Strong name signatures help prevent malicious parties from tampering with an assembly and then re-signing the assembly with the original signer’s key. However, strong name keys don’t contain any reliable information about the publisher, nor do they contain a certificate hierarchy. A strong name signature does not guarantee the trustworthiness of the person who signed the assembly or indicate whether that person was a legitimate owner of the key; it indicates only that the owner of the key signed the assembly. Therefore, we do not recommend using a strong name signature as a security validator for trusting third-party code. Microsoft Authenticode is the recommended way to authenticate code.  
  
## Limitations of Conventional Strong Names  
 The strong naming technology used in versions before the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] has the following shortcomings:  
  
-   Keys are constantly under attack, and improved techniques and hardware make it easier to infer a private key from a public key. To guard against attacks, larger keys are necessary. .NET Framework versions before the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] provide the ability to sign with any size key (the default size is 1024 bits), but signing an assembly with a new key breaks all binaries that reference the older identity of the assembly. Therefore, it is extremely difficult to upgrade the size of a signing key if you want to maintain compatibility.  
  
-   Strong name signing supports only the SHA-1 algorithm. SHA-1 has recently been found to be inadequate for secure hashing applications. Therefore, a stronger algorithm (SHA-256 or greater) is necessary. It is possible that SHA-1 will lose its FIPS-compliant standing, which would present problems for those who choose to use only FIPS-compliant software and algorithms.  
  
## Advantages of Enhanced Strong Names  
 The main advantages of enhanced strong names are compatibility with pre-existing strong names and the ability to claim that one identity is equivalent to another:  
  
-   Developers who have pre-existing signed assemblies can migrate their identities to the SHA-2 algorithms while maintaining compatibility with assemblies that reference the old identities.  
  
-   Developers who create new assemblies and are not concerned with pre-existing strong name signatures can use the more secure SHA-2 algorithms and sign the assemblies as they always have.  
  
## Using Enhanced Strong Names  
 Strong name keys consist of a signature key and an identity key. The assembly is signed with the signature key and is identified by the identity key. Prior to the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], these two keys were identical. Starting with the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], the identity key remains the same as in earlier .NET Framework versions, but the signature key is enhanced with a stronger hash algorithm. In addition, the signature key is signed with the identity key to create a counter-signature.  
  
 The <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute enables the assembly metadata to use the pre-existing public key for assembly identity, which allows old assembly references to continue to work.  The <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute uses the counter-signature to ensure that the owner of the new signature key is also the owner of the old identity key.  
  
### Signing with SHA-2, Without Key Migration  
 Run the following commands from a Command Prompt window to sign an assembly without migrating a strong name signature:  
  
1.  Generate the new identity key (if necessary).  
  
    ```  
    sn -k IdentityKey.snk  
    ```  
  
2.  Extract the identity public key, and specify that a SHA-2 algorithm should be used when signing with this key.  
  
    ```  
    sn -p IdentityKey.snk IdentityPubKey.snk sha256  
    ```  
  
3.  Delay-sign the assembly with the identity public key file.  
  
    ```  
    csc MyAssembly.cs /keyfile:IdentityPubKey.snk /delaySign+  
    ```  
  
4.  Re-sign the assembly with the full identity key pair.  
  
    ```  
    sn -Ra MyAssembly.exe IdentityKey.snk  
    ```  
  
### Signing with SHA-2, with Key Migration  
 Run the following commands from a Command Prompt window to sign an assembly with a migrated strong name signature.  
  
1.  Generate an identity and signature key pair (if necessary).  
  
    ```  
    sn -k IdentityKey.snk  
    sn -k SignatureKey.snk  
    ```  
  
2.  Extract the signature public key, and specify that a SHA-2 algorithm should be used when signing with this key.  
  
    ```  
    sn -p SignatureKey.snk SignaturePubKey.snk sha256  
    ```  
  
3.  Extract the identity public key, which determines the hash algorithm that generates a counter-signature.  
  
    ```  
    sn -p IdentityKey.snk IdentityPubKey.snk  
    ```  
  
4.  Generate the parameters for a <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute, and attach the attribute to the assembly.  
  
    ```  
    sn -ac IdentityPubKey.snk IdentityKey.snk SignaturePubKey.snk  
    ```  
  
5.  Delay-sign the assembly with the identity public key.  
  
    ```  
    csc MyAssembly.cs /keyfile:IdentityPubKey.snk /delaySign+  
    ```  
  
6.  Fully sign the assembly with the signature key pair.  
  
    ```  
    sn -Ra MyAssembly.exe SignatureKey.snk  
    ```  
  
## See Also  
 [Creating and Using Strong-Named Assemblies](../../../docs/framework/app-domains/create-and-use-strong-named-assemblies.md)
