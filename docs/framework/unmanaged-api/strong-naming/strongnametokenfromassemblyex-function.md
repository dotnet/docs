---
title: "StrongNameTokenFromAssemblyEx Function"
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
  - "StrongNameTokenFromAssemblyEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameTokenFromAssemblyEx"
helpviewer_keywords: 
  - "StrongNameTokenFromAssemblyEx function [.NET Framework strong naming]"
ms.assetid: 67a8a9f2-dee3-44b2-a1c0-f307a3bdf90f
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameTokenFromAssemblyEx Function
Creates a strong name token from the specified assembly file, and returns the public key that the token represents.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameTokenFromAssemblyEx](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassemblyex-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameTokenFromAssemblyEx (  
    [in]  LPCWSTR   wszFilePath,  
    [out] BYTE      **ppbStrongNameToken,  
    [out] ULONG     *pcbStrongNameToken,  
    [out] BYTE      **ppbPublicKeyBlob,  
    [out] ULONG     *pcbPublicKeyBlob  
);  
```  
  
#### Parameters  
 `wszFilePath`  
 [in] The path to the portable executable (PE) file for the assembly.  
  
 `ppbStrongNameToken`  
 [out] The returned strong name token.  
  
 `pcbStrongNameToken`  
 [out] The size, in bytes, of the strong name token.  
  
 `ppbPublicKeyBlob`  
 [out] The returned public key.  
  
 `pcbPublicKeyBlob`  
 [out] The size, in bytes, of the public key.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read from the assembly metadata.  
  
 After the key is retrieved and the token is created, you should call the [StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/strong-naming/strongnamefreebuffer-function.md) function to release the allocated memory.  
  
 If the `StrongNameTokenFromAssemblyEx` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameTokenFromAssemblyEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassemblyex-method.md)  
 [StrongNameTokenFromAssembly Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassembly-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
