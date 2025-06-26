---
description: "Learn more about: ICLRStrongName Interface"
title: "ICLRStrongName Interface"
ms.date: "03/30/2017"
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
---
# ICLRStrongName Interface

Provides basic global static functions for signing assemblies with strong names. All `ICLRStrongName` methods return standard COM HRESULTs.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetHashFromAssemblyFile Method](iclrstrongname-gethashfromassemblyfile-method.md)|Gets a hash of the specified assembly file, using the specified hash algorithm.|  
|[GetHashFromAssemblyFileW Method](iclrstrongname-gethashfromassemblyfilew-method.md)|Gets a hash of the assembly file specified as a Unicode string, using the specified hash algorithm.|  
|[GetHashFromBlob Method](iclrstrongname-gethashfromblob-method.md)|Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.|  
|[GetHashFromFile Method](iclrstrongname-gethashfromfile-method.md)|Generates a hash over the contents of the specified file.|  
|[GetHashFromFileW Method](iclrstrongname-gethashfromfilew-method.md)|Generates a hash over the contents of the file specified by a Unicode string.|  
|[GetHashFromHandle Method](iclrstrongname-gethashfromhandle-method.md)|Generates a hash over the contents of the file with the specified file handle, using the specified hash algorithm.|  
|[StrongNameCompareAssemblies Method](iclrstrongname-strongnamecompareassemblies-method.md)|Determines whether two assemblies differ only by their strong name signatures.|  
|[StrongNameFreeBuffer Method](iclrstrongname-strongnamefreebuffer-method.md)|Frees memory that was allocated with a previous call to a strong name method such as [StrongNameGetPublicKey](iclrstrongname-strongnamegetpublickey-method.md), [StrongNameTokenFromPublicKey](iclrstrongname-strongnametokenfrompublickey-method.md), or [StrongNameSignatureGeneration](iclrstrongname-strongnamesignaturegeneration-method.md).|  
|[StrongNameGetBlob Method](iclrstrongname-strongnamegetblob-method.md)|Fills the specified buffer with the binary representation of the executable file at the specified address.|  
|[StrongNameGetBlobFromImage Method](iclrstrongname-strongnamegetblobfromimage-method.md)|Gets a binary representation of the assembly image at the specified memory address.|  
|[StrongNameGetPublicKey Method](iclrstrongname-strongnamegetpublickey-method.md)|Gets the public key from a private/public key pair.|  
|[StrongNameHashSize Method](iclrstrongname-strongnamehashsize-method.md)|Gets the buffer size required for a hash, using the specified hash algorithm.|  
|[StrongNameKeyDelete Method](iclrstrongname-strongnamekeydelete-method.md)|Deletes the specified key container.|  
|[StrongNameKeyGen Method](iclrstrongname-strongnamekeygen-method.md)|Creates a new public/private key pair for strong name use.|  
|[StrongNameKeyGenEx Method](iclrstrongname-strongnamekeygenex-method.md)|Generates a new public/private key pair with the specified key size for strong name use.|  
|[StrongNameKeyInstall Method](iclrstrongname-strongnamekeyinstall-method.md)|Imports a public/private key pair into a container.|  
|[StrongNameSignatureGeneration Method](iclrstrongname-strongnamesignaturegeneration-method.md)|Generates a strong name signature for the specified assembly.|  
|[StrongNameSignatureGenerationEx Method](iclrstrongname-strongnamesignaturegenerationex-method.md)|Generates a strong name signature for the specified assembly, based on the specified flags.|  
|[StrongNameSignatureSize Method](iclrstrongname-strongnamesignaturesize-method.md)|Returns the size of the strong name signature.|  
|[StrongNameSignatureVerification Method](iclrstrongname-strongnamesignatureverification-method.md)|Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.|  
|[StrongNameSignatureVerificationEx Method](iclrstrongname-strongnamesignatureverificationex-method.md)|Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature.|  
|[StrongNameSignatureVerificationFromImage Method](iclrstrongname-strongnamesignatureverificationfromimage-method.md)|Verifies that an assembly that has already been mapped to memory is valid for the associated public key.|  
|[StrongNameTokenFromAssembly Method](iclrstrongname-strongnametokenfromassembly-method.md)|Creates a strong name token from the specified assembly file.|  
|[StrongNameTokenFromAssemblyEx Method](iclrstrongname-strongnametokenfromassemblyex-method.md)|Creates a strong name token from the specified assembly file, and returns the public key.|  
|[StrongNameTokenFromPublicKey Method](iclrstrongname-strongnametokenfrompublickey-method.md)|Gets a token representing a public key.|  
  
## Remarks  

 You can get an instance of the `ICLRStrongName` by calling the [ICLRRuntimeInfo::GetInterface](iclrruntimeinfo-getinterface-method.md) method using `CLSID_CLRStrongName` and `IID_ICLRStrongName` as parameters.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
