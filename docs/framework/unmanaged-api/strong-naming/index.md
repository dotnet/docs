---
title: "Strong Naming (Unmanaged API Reference)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "strong naming [.NET Framework], using the unmanaged API"
  - "native API reference [.NET Framework], strong naming"
  - "unmanaged API reference [.NET Framework], strong naming"
ms.assetid: 428c68b6-a7b4-44be-b280-75905f46612c
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Strong Naming (Unmanaged API Reference)
The strong naming API enables a client to administer strong name signing for assemblies.  
  
 Signing an assembly with a strong name adds a public key encryption to the file containing the assembly manifest. Strong name signing helps verify name uniqueness, prevents name spoofing, and provides callers with a unique identity when a reference is resolved. However, no level of trust is associated with a strong name.  
  
## In This Section  
 [Strong Naming Global Static Functions](http://msdn.microsoft.com/library/efa715df-e8cc-48f2-9ec4-26586f0dc8d0)  
 Describes the unmanaged global static functions that the strong naming API uses.  
  
> [!NOTE]
>  All of these functions have been deprecated starting with the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. For suggested alternatives, see the [ICLRStrongName](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md) interface.  
  
 [GetHashFromAssemblyFile Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromassemblyfile-function.md)  
 Gets a hash of the specified assembly file, using the specified hash algorithm. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [GetHashFromAssemblyFileW Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromassemblyfilew-function.md)  
 Gets a hash of the assembly file specified as a Unicode string, using the specified hash algorithm. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [GetHashFromBlob Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromblob-function.md)  
 Gets a hash of the assembly at the specified memory address, using the specified hash algorithm. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [GetHashFromFile Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromfile-function.md)  
 Generates a hash over the contents of the specified file.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [GetHashFromFileW Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromfilew-function.md)  
 Generates a hash over the contents of the file specified by a Unicode string. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [GetHashFromHandle Function](../../../../docs/framework/unmanaged-api/strong-naming/gethashfromhandle-function.md)  
 Generates a hash over the contents of the file with the specified file handle, using the specified hash algorithm.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameCompareAssemblies Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamecompareassemblies-function.md)  
 Determines whether two assemblies differ only by their strong name signatures. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameErrorInfo Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md)  
 Gets the last error code that was raised by one of the strong name functions.  
  
 [StrongNameFreeBuffer Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamefreebuffer-function.md)  
 Frees memory that was allocated with a previous call to a strong name function such as [StrongNameGetPublicKey](../../../../docs/framework/unmanaged-api/strong-naming/strongnamegetpublickey-function.md), [StrongNameTokenFromPublicKey](../../../../docs/framework/unmanaged-api/strong-naming/strongnametokenfrompublickey-function.md), or [StrongNameSignatureGeneration](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignaturegeneration-function.md).   Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameGetBlob Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamegetblob-function.md)  
 Fills the specified buffer with the binary representation of the executable file at the specified address. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameGetBlobFromImage Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamegetblobfromimage-function.md)  
 Gets a binary representation of the assembly image at the specified memory address. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameGetPublicKey Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamegetpublickey-function.md)  
 Gets the public key from a private/public key pair. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameHashSize Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamehashsize-function.md)  
 Gets the buffer size required for a hash, using the specified hash algorithm.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameKeyDelete Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamekeydelete-function.md)  
 Deletes the specified key container. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameKeyGen Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamekeygen-function.md)  
 Creates a new public/private key pair for strong name use.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameKeyGenEx Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamekeygenex-function.md)  
 Generates a new public/private key pair with the specified key size for strong name use. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameKeyInstall Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamekeyinstall-function.md)  
 Imports a public/private key pair into a container.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureGeneration Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignaturegeneration-function.md)  
 Generates a strong name signature for the specified assembly.   Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureGenerationEx Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignaturegenerationex-function.md)  
 Generates a strong name signature for the specified assembly, based on the specified flags.    Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureSize Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignaturesize-function.md)  
 Returns the size of the strong name signature. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureVerification Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignatureverification-function.md)  
 Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureVerificationEx Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignatureverificationex-function.md)  
 Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameSignatureVerificationFromImage Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnamesignatureverificationfromimage-function.md)  
 Verifies that an assembly that has already been mapped to memory is valid for the associated public key. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameTokenFromAssembly Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnametokenfromassembly-function.md)  
 Creates a strong name token from the specified assembly file.  Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameTokenFromAssemblyEx Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnametokenfromassemblyex-function.md)  
 Creates a strong name token from the specified assembly file, and returns the public key. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [StrongNameTokenFromPublicKey Function](../../../../docs/framework/unmanaged-api/strong-naming/strongnametokenfrompublickey-function.md)  
 Gets a token representing a public key. Deprecated starting with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)].  
  
 [Strong Naming Structure](http://msdn.microsoft.com/library/4b041a2f-fd12-4b91-aacd-bc3b34a5124d)  
 Describes the unmanaged structure that the strong naming API uses  to administer strong name signing for assemblies..  
  
 [PublicKeyBlob Structure](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md)  
 Represents the public key of a public/private key pair in binary format.  
  
## See Also  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)  
 [Unmanaged API Reference](../../../../docs/framework/unmanaged-api/index.md)
