---
title: "ICLRStrongName::StrongNameGetBlob Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameGetBlob"
  - "ICLRStrongName.StrongNameGetBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameGetBlob"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameGetBlob method [.NET Framework hosting]"
  - "StrongNameGetBlob method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: a24218f8-7196-44be-b7a2-ee9cdd7a85c4
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICLRStrongName::StrongNameGetBlob Method
Fills the specified buffer with the binary representation of the executable file at the specified address.  
  
## Syntax  
  
```  
HRESULT StrongNameGetBlob (  
    [in]  LPCWSTR    wszFilePath,  
    [in]  BYTE       *pbBlob,  
    [in, out] DWORD  *pcbBlob  
);  
```  
  
#### Parameters  
 `wszFilePath`  
 [in] A valid path to the executable file to be loaded.  
  
 `pbBlob`  
 [in] The buffer into which to load the executable file.  
  
 `pcbBlob`  
 [in, out] The requested maximum size, in bytes, of `pbBlob`. Upon return, the actual size, in bytes, of `pbBlob`.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](https://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also
- [StrongNameGetBlobFromImage Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblobfromimage-method.md)
- [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
