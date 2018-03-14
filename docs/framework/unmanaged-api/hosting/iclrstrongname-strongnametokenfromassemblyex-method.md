---
title: "ICLRStrongName::StrongNameTokenFromAssemblyEx Method"
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
  - "ICLRStrongName.StrongNameTokenFromAssemblyEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameTokenFromAssemblyEx"
helpviewer_keywords: 
  - "StrongNameTokenFromAssemblyEx method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameTokenFromAssemblyEx method [.NET Framework hosting]"
ms.assetid: 648ea90e-5e60-40a0-a56a-3e61bf2fba7c
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameTokenFromAssemblyEx Method
Creates a strong name token from the specified assembly file, and returns the public key that the token represents.  
  
## Syntax  
  
```  
HRESULT StrongNameTokenFromAssemblyEx (  
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
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 A strong name token is the shortened form of a public key. The token is a 64-bit hash that is created from the public key used to sign the assembly. The token is a part of the strong name for the assembly, and can be read from the assembly metadata.  
  
 After the key is retrieved and the token is created, you should call the [ICLRStrongName::StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md) method to release the allocated memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameTokenFromAssembly Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnametokenfromassembly-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
