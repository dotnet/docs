---
description: "Learn more about: ICLRStrongName::StrongNameHashSize Method"
title: "ICLRStrongName::StrongNameHashSize Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameHashSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameHashSize"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameHashSize method [.NET Framework hosting]"
  - "StrongNameHashSize method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: 4a05ee56-08e4-4f3a-86a9-9b52083d5c0f
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameHashSize Method

Gets the buffer size required for a hash, using the specified hash algorithm.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameHashSize (  
    [in]  ULONG   ulHashAlg,  
    [out] DWORD   *pcbSize  
);  
```  
  
## Parameters  

 `ulHashAlg`  
 [in] The hash algorithm used to compute the buffer size.  
  
 `pcbSize`  
 [out] The returned buffer size, in bytes.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../../../framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRStrongName Interface](iclrstrongname-interface.md)
