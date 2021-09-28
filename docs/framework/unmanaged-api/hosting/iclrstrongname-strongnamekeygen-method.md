---
description: "Learn more about: ICLRStrongName::StrongNameKeyGen Method"
title: "ICLRStrongName::StrongNameKeyGen Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRStrongName.StrongNameKeyGen"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameKeyGen"
helpviewer_keywords: 
  - "StrongNameKeyGen method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameKeyGen method [.NET Framework hosting]"
ms.assetid: ac5c1245-9acf-4271-9c08-3d9b7c670df3
topic_type: 
  - "apiref"
---
# ICLRStrongName::StrongNameKeyGen Method

Creates a new public/private key pair for strong name use.  
  
## Syntax  
  
```cpp  
HRESULT StrongNameKeyGen (  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  DWORD     dwFlags,  
    [out] BYTE      **ppbKeyBlob,  
    [out] ULONG     *pcbKeyBlob  
);  
```  
  
## Parameters  

 `wszKeyContainer`  
 [in] The requested key container name. `wszKeyContainer` must either be a non-empty string or null to generate a temporary name.  
  
 `dwFlags`  
 [in] A value that specifies whether to leave the key registered. The following values are supported:  
  
- 0x00000000 - Used when `wszKeyContainer` is null to generate a temporary key container name.  
  
- 0x00000001 (`SN_LEAVE_KEY`) - Specifies that the key should be left registered.  
  
 `ppbKeyBlob`  
 [out] The returned public/private key pair.  
  
 `pcbKeyBlob`  
 [out] The size, in bytes, of `ppbKeyBlob`.  
  
## Return Value  

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).  
  
## Remarks  

 The [ICLRStrongName::StrongNameKeyGen](iclrstrongname-strongnamekeygen-method.md) method creates a 1024-bit key. After the key is retrieved, you should call the [ICLRStrongName::StrongNameFreeBuffer](iclrstrongname-strongnamefreebuffer-method.md) method to release the allocated memory.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [StrongNameKeyGenEx Method](iclrstrongname-strongnamekeygenex-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
