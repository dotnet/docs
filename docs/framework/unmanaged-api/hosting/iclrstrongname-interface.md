---
title: "ICLRStrongName Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICLRStrongName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName"
helpviewer_keywords: 
  - "ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 2fac66fd-6b3b-4dbd-8baf-86038bd85526
topic_type: 
  - "apiref"
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName Interface
Provides basic global static functions for signing assemblies with strong names. All `ICLRStrongName` methods return standard COM HRESULTs.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetHashFromAssemblyFile Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromassemblyfile-method.md)|Gets a hash of the specified assembly file, using the specified hash algorithm.|  
|[GetHashFromAssemblyFileW Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromassemblyfilew-method.md)|Gets a hash of the assembly file specified as a Unicode string, using the specified hash algorithm.|  
|[GetHashFromBlob Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromblob-method.md)|Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.|  
|[GetHashFromFile Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromfile-method.md)|Generates a hash over the contents of the specified file.|  
|[GetHashFromFileW Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromfilew-method.md)|Generates a hash over the contents of the file specified by a Unicode string.|  
|[GetHashFromHandle Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-gethashfromhandle-method.md)|Generates a hash over the contents of the file with the specified file handle, using the specified hash algorithm.|  
|[StrongNameCompareAssemblies Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamecompareassemblies-method.md)|Determines whether two assemblies differ only by their strong name signatures.|  
|[StrongNameFreeBuffer Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md)|Frees memory that was allocated with a previous call to a strong name method such as [StrongNameGetPublicKey](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md), [StrongNameTokenFromPublicKey](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfrompublickey-method.md), or [StrongNameSignatureGeneration](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignaturegeneration-method.md).|  
|[StrongNameGetBlob Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblob-method.md)|Fills the specified buffer with the binary representation of the executable file at the specified address.|  
|[StrongNameGetBlobFromImage Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblobfromimage-method.md)|Gets a binary representation of the assembly image at the specified memory address.|  
|[StrongNameGetPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetpublickey-method.md)|Gets the public key from a private/public key pair.|  
|[StrongNameHashSize Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamehashsize-method.md)|Gets the buffer size required for a hash, using the specified hash algorithm.|  
|[StrongNameKeyDelete Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeydelete-method.md)|Deletes the specified key container.|  
|[StrongNameKeyGen Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygen-method.md)|Creates a new public/private key pair for strong name use.|  
|[StrongNameKeyGenEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygenex-method.md)|Generates a new public/private key pair with the specified key size for strong name use.|  
|[StrongNameKeyInstall Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeyinstall-method.md)|Imports a public/private key pair into a container.|  
|[StrongNameSignatureGeneration Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignaturegeneration-method.md)|Generates a strong name signature for the specified assembly.|  
|[StrongNameSignatureGenerationEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignaturegenerationex-method.md)|Generates a strong name signature for the specified assembly, based on the specified flags.|  
|[StrongNameSignatureSize Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignaturesize-method.md)|Returns the size of the strong name signature.|  
|[StrongNameSignatureVerification Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverification-method.md)|Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.|  
|[StrongNameSignatureVerificationEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationex-method.md)|Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature.|  
|[StrongNameSignatureVerificationFromImage Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationfromimage-method.md)|Verifies that an assembly that has already been mapped to memory is valid for the associated public key.|  
|[StrongNameTokenFromAssembly Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassembly-method.md)|Creates a strong name token from the specified assembly file.|  
|[StrongNameTokenFromAssemblyEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassemblyex-method.md)|Creates a strong name token from the specified assembly file, and returns the public key.|  
|[StrongNameTokenFromPublicKey Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfrompublickey-method.md)|Gets a token representing a public key.|  
  
## Remarks  
 You can get an instance of the `ICLRStrongName` by calling the [ICLRRuntimeInfo::GetInterface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getinterface-method.md) method using `CLSID_CLRStrongName` and `IID_ICLRStrongName` as parameters.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
