---
description: "Learn more about: ICLRStrongName::GetHashFromBlob Method"
title: "ICLRStrongName::GetHashFromBlob Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.GetHashFromBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::GetHashFromBlob"
helpviewer_keywords: 
  - "ICLRStrongName::GetHashFromBlob method [.NET Framework hosting]"
  - "GetHashFromBlob method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: f91d0f89-f356-49ac-aafb-50fad963c13d
topic_type: 
  - "apiref"
---
# ICLRStrongName::GetHashFromBlob Method

Gets a hash of the assembly at the specified memory address, using the specified hash algorithm.  
  
## Syntax  
  
```cpp  
HRESULT GetHashFromBlob (  
    [in]  BYTE    *pbBlob,  
    [in]  DWORD   cchBlob,  
    [in, out] unsigned int   *piHashAlg,  
    [out] BYTE    *pbHash,  
    [in]  DWORD   cchHash,  
    [out] DWORD   *pchHash  
);  
```  
  
## Parameters  

 `pbBlob`  
 [in] A pointer to the address of the memory block to be hashed.  
  
 `cchBlob`  
 [in] The length, in bytes, of the memory block.  
  
 `piHashAlg`  
 [in, out] A constant that specifies the hash algorithm. Use zero for the default algorithm.  
  
 `pbHash`  
 [out] The returned hash buffer.  
  
 `cchHash`  
 [in] The requested maximum size of `pbHash`.  
  
 `pchHash`  
 [out] The size, in bytes, of the returned `pbHash`.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRStrongName Interface](iclrstrongname-interface.md)
