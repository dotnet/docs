---
title: "ICLRStrongName::StrongNameSignatureSize Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameSignatureSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameSignatureSize"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameSignatureSize method [.NET Framework hosting]"
  - "StrongNameSignatureSize method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 76d4f93a-5e25-4399-abcc-a1389549481d
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRStrongName::StrongNameSignatureSize Method
Returns the size of the strong name signature. This method is typically used by compilers to determine how much space to reserve in the file when creating a delay-signed assembly.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameSignatureSize (   
    [in]  BYTE   *pbPublicKeyBlob,  
    [in]  ULONG  cbPublicKeyBlob,   
    [in]  DWORD  *pcbSize  
);   
```  
  
## Parameters  
 `pbPublicKeyBlob`  
 [in] A structure of type [PublicKeyBlob](../../../../docs/framework/unmanaged-api/strong-naming/publickeyblob-structure.md) that contains the public portion of the key pair used to generate the strong name signature.  
  
 `cbPublicKeyBlob`  
 [in] The size, in bytes, of `pbPublicKeyBlob`.  
  
 `pcbSize`  
 [in] The number of bytes required to store the strong name signature.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](https://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
