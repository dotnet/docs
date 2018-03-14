---
title: "ICLRStrongName::StrongNameKeyGenEx Method"
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
  - "ICLRStrongName.StrongNameKeyGenEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameKeyGenEx"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameKeyGenEx method [.NET Framework hosting]"
  - "StrongNameKeyGenEx method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 1f8b59d0-5b72-45b8-ab74-c2b43ffc806e
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameKeyGenEx Method
Generates a new public/private key pair with the specified key size, for strong name use.  
  
## Syntax  
  
```  
HRESULT StrongNameKeyGenEx (  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  DWORD     dwFlags,  
    [in]  DWORD     dwKeySize,  
    [out] BYTE      **ppbKeyBlob,  
    [out] ULONG     *pcbKeyBlob  
);  
```  
  
#### Parameters  
 `wszKeyContainer`  
 [in] The requested key container name. `wszKeyContainer` must either be a non-empty string or null to generate a temporary name.  
  
 `dwFlags`  
 [in] A value that specifies whether to leave the key registered. The following values are supported:  
  
-   0x00000000 - Used when `wszKeyContainer` is null to generate a temporary key container name.  
  
-   0x00000001 (`SN_LEAVE_KEY`) - Specifies that the key should be left registered.  
  
 `dwKeySize`  
 [in] The requested size of the key, in bits.  
  
 `ppbKeyBlob`  
 [out] The returned public/private key pair.  
  
 `pcbKeyBlob`  
 [out] The size, in bytes, of `ppbKeyBlob`.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Remarks  
 The .NET Framework versions 1.0 and 1.1 require a `dwKeySize` of 1024 bits to sign an assembly with a strong name; version 2.0 adds supports for 2048-bit keys.  
  
 After the key is retrieved, you should call the [ICLRStrongName::StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamefreebuffer-method.md) method to release the allocated memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameKeyGen Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygen-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
