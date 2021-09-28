---
title: "Enhanced strong naming"
description: Conventional strong name signatures for assemblies in .NET Framework have limitations. Learn about enhanced strong naming. 
ms.date: "08/20/2019"
helpviewer_keywords: 
  - "strong-named assemblies"
  - "strong naming [.NET Framework], enhanced"
ms.assetid: 6cf17a82-62a1-4f6d-8d5a-d7d06dec2bb5
---
# Enhanced strong naming

A strong name signature is an identity mechanism in the .NET Framework for identifying assemblies. It is a public-key digital signature that is typically used to verify the integrity of data being passed from an originator (signer) to a recipient (verifier). This signature is used as a unique identity for an assembly and ensures that references to the assembly are not ambiguous. The assembly is signed as part of the build process and then verified when it is loaded.  
  
 Strong name signatures help prevent malicious parties from tampering with an assembly and then re-signing the assembly with the original signer’s key. However, strong name keys don’t contain any reliable information about the publisher, nor do they contain a certificate hierarchy. A strong name signature does not guarantee the trustworthiness of the person who signed the assembly or indicate whether that person was a legitimate owner of the key; it indicates only that the owner of the key signed the assembly. Therefore, we do not recommend using a strong name signature as a security validator for trusting third-party code. Microsoft Authenticode is the recommended way to authenticate code.  
  
## Limitations of conventional strong names  

 The strong naming technology used in versions before the .NET Framework 4.5 has the following shortcomings:  
  
- Keys are constantly under attack, and improved techniques and hardware make it easier to infer a private key from a public key. To guard against attacks, larger keys are necessary. .NET Framework versions before the .NET Framework 4.5 provide the ability to sign with any size key (the default size is 1024 bits), but signing an assembly with a new key breaks all binaries that reference the older identity of the assembly. Therefore, it is extremely difficult to upgrade the size of a signing key if you want to maintain compatibility.  
  
- Strong name signing supports only the SHA-1 algorithm. SHA-1 has recently been found to be inadequate for secure hashing applications. Therefore, a stronger algorithm (SHA-256 or greater) is necessary. It is possible that SHA-1 will lose its FIPS-compliant standing, which would present problems for those who choose to use only FIPS-compliant software and algorithms.  
  
## Advantages of enhanced strong names  

 The main advantages of enhanced strong names are compatibility with pre-existing strong names and the ability to claim that one identity is equivalent to another:  
  
- Developers who have pre-existing signed assemblies can migrate their identities to the SHA-2 algorithms while maintaining compatibility with assemblies that reference the old identities.  
  
- Developers who create new assemblies and are not concerned with pre-existing strong name signatures can use the more secure SHA-2 algorithms and sign the assemblies as they always have.  
  
## Use enhanced strong names  

 Strong name keys consist of a signature key and an identity key. The assembly is signed with the signature key and is identified by the identity key. Prior to the .NET Framework 4.5, these two keys were identical. Starting with the .NET Framework 4.5, the identity key remains the same as in earlier .NET Framework versions, but the signature key is enhanced with a stronger hash algorithm. In addition, the signature key is signed with the identity key to create a counter-signature.  
  
 The <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute enables the assembly metadata to use the pre-existing public key for assembly identity, which allows old assembly references to continue to work.  The <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute uses the counter-signature to ensure that the owner of the new signature key is also the owner of the old identity key.  
  
### Sign with SHA-2, without key migration  

 Run the following commands from a command prompt to sign an assembly without migrating a strong name signature:  
  
1. Generate the new identity key (if necessary).  
  
    ```console  
    sn -k IdentityKey.snk  
    ```  
  
2. Extract the identity public key, and specify that a SHA-2 algorithm should be used when signing with this key.  
  
    ```console  
    sn -p IdentityKey.snk IdentityPubKey.snk sha256  
    ```  
  
3. Delay-sign the assembly with the identity public key file.  
  
    ```console  
    csc MyAssembly.cs /keyfile:IdentityPubKey.snk /delaySign+  
    ```  
  
4. Re-sign the assembly with the full identity key pair.  
  
    ```console  
    sn -Ra MyAssembly.exe IdentityKey.snk  
    ```  
  
### Sign with SHA-2, with key migration  

 Run the following commands from a command prompt to sign an assembly with a migrated strong name signature.  
  
1. Generate an identity and signature key pair (if necessary).  
  
    ```console  
    sn -k IdentityKey.snk  
    sn -k SignatureKey.snk  
    ```  
  
2. Extract the signature public key, and specify that a SHA-2 algorithm should be used when signing with this key.  
  
    ```console  
    sn -p SignatureKey.snk SignaturePubKey.snk sha256  
    ```  
  
3. Extract the identity public key, which determines the hash algorithm that generates a counter-signature.  
  
    ```console  
    sn -p IdentityKey.snk IdentityPubKey.snk  
    ```  
  
4. Generate the parameters for a <xref:System.Reflection.AssemblySignatureKeyAttribute> attribute, and attach the attribute to the assembly.  
  
    ```console  
    sn -a IdentityPubKey.snk IdentityKey.snk SignaturePubKey.snk  
    ```  

    This produces output similar to the following.

    ```output
    Information for key migration attribute.
    (System.Reflection.AssemblySignatureKeyAttribute):
    publicKey=
    002400000c80000094000000060200000024000052534131000400000100010005a3a81ac0a519
    d96244a9c589fc147c7d403e40ccf184fc290bdd06c7339389a76b738e255a2bce1d56c3e7e936
    e4fc87d45adc82ca94c716b50a65d39d373eea033919a613e4341c66863cb2dc622bcb541762b4
    3893434d219d1c43f07e9c83fada2aed400b9f6e44ff05e3ecde6c2827830b8f43f7ac8e3270a3
    4d153cdd

    counterSignature=
    e3cf7c211678c4d1a7b8fb20276c894ab74c29f0b5a34de4d61e63d4a997222f78cdcbfe4c91eb
    e1ddf9f3505a32edcb2a76f34df0450c4f61e376b70fa3cdeb7374b1b8e2078b121e2ee6e8c6a8
    ed661cc35621b4af53ac29c9e41738f199a81240e8fd478c887d1a30729d34e954a97cddce66e3
    ae5fec2c682e57b7442738
    ```

    This output can then be transformed into an AssemblySignatureKeyAttribute.

    ```csharp
    [assembly:System.Reflection.AssemblySignatureKeyAttribute(
    "002400000c80000094000000060200000024000052534131000400000100010005a3a81ac0a519d96244a9c589fc147c7d403e40ccf184fc290bdd06c7339389a76b738e255a2bce1d56c3e7e936e4fc87d45adc82ca94c716b50a65d39d373eea033919a613e4341c66863cb2dc622bcb541762b43893434d219d1c43f07e9c83fada2aed400b9f6e44ff05e3ecde6c2827830b8f43f7ac8e3270a34d153cdd",
    "e3cf7c211678c4d1a7b8fb20276c894ab74c29f0b5a34de4d61e63d4a997222f78cdcbfe4c91ebe1ddf9f3505a32edcb2a76f34df0450c4f61e376b70fa3cdeb7374b1b8e2078b121e2ee6e8c6a8ed661cc35621b4af53ac29c9e41738f199a81240e8fd478c887d1a30729d34e954a97cddce66e3ae5fec2c682e57b7442738"
    )]
    ```
  
5. Delay-sign the assembly with the identity public key.  
  
    ```console  
    csc MyAssembly.cs /keyfile:IdentityPubKey.snk /delaySign+  
    ```  
  
6. Fully sign the assembly with the signature key pair.  
  
    ```console  
    sn -Ra MyAssembly.exe SignatureKey.snk  
    ```  
  
## See also

- [Create and use strong-named assemblies](create-use-strong-named.md)
