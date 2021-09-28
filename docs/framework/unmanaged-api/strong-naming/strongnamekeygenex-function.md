---
description: "Learn more about: StrongNameKeyGenEx Function"
title: "StrongNameKeyGenEx Function"
ms.date: "03/30/2017"
api_name: 
  - "StrongNameKeyGenEx"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameKeyGenEx"
helpviewer_keywords: 
  - "StrongNameKeyGenEx function [.NET Framework strong naming]"
ms.assetid: 36bd10b9-9857-45f3-8d3b-0da091d6169e
topic_type: 
  - "apiref"
---
# StrongNameKeyGenEx Function

Generates a new public/private key pair with the specified key size, for strong name use.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameKeyGenEx](../hosting/iclrstrongname-strongnamekeygenex-method.md) method instead.  
  
## Syntax  
  
```cpp  
BOOLEAN StrongNameKeyGenEx (  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  DWORD     dwFlags,  
    [in]  DWORD     dwKeySize,  
    [out] BYTE      **ppbKeyBlob,  
    [out] ULONG     *pcbKeyBlob  
);  
```  
  
## Parameters  

 `wszKeyContainer`  
 [in] The requested key container name. `wszKeyContainer` must be a non-empty string, or null to generate a temporary name.  
  
 `dwFlags`  
 [in] Specifies whether to leave the key registered. The following values are supported:  
  
- 0x00000000 - Used when `wszKeyContainer` is null to generate a temporary key container name.  
  
- 0x00000001 (`SN_LEAVE_KEY`) - Specifies that the key should be left registered.  
  
 `dwKeySize`  
 [in] The requested size of the key, in bits.  
  
 `ppbKeyBlob`  
 [out] The returned public/private key pair.  
  
 `pcbKeyBlob`  
 [out] The size, in bytes, of `ppbKeyBlob`.  
  
## Return Value  

 `true` on successful completion; otherwise, `false`.  
  
## Remarks  

 The .NET Framework versions 1.0 and 1.1 require a `dwKeySize` of 1024 bits to sign an assembly with a strong name; version 2.0 adds supports for 2048-bit keys.  
  
 After the key is retrieved, you should call the [StrongNameFreeBuffer](strongnamefreebuffer-function.md) function to release the allocated memory.  
  
 If the `StrongNameKeyGenEx` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [StrongNameKeyGenEx Method](../hosting/iclrstrongname-strongnamekeygenex-method.md)
- [StrongNameKeyGen Method](../hosting/iclrstrongname-strongnamekeygen-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
