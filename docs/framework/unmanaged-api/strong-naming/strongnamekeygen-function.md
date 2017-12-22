---
title: "StrongNameKeyGen Function"
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
  - "StrongNameKeyGen"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameKeyGen"
helpviewer_keywords: 
  - "StrongNameKeyGen function [.NET Framework strong naming]"
ms.assetid: 883e413a-ad2f-4f7f-b1b9-aeb8fe5b65f8
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameKeyGen Function
Creates a new public/private key pair for strong name use.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameKeyGen](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygen-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameKeyGen (  
    [in]  LPCWSTR   wszKeyContainer,  
    [in]  DWORD     dwFlags,  
    [out] BYTE      **ppbKeyBlob,  
    [out] ULONG     *pcbKeyBlob  
);  
```  
  
#### Parameters  
 `wszKeyContainer`  
 [in] The requested key container name. `wszKeyContainer` must be a non-empty string, or null to generate a temporary name.  
  
 `dwFlags`  
 [in] Specifies whether to leave the key registered. The following values are supported:  
  
-   0x00000000 - Used when `wszKeyContainer` is null to generate a temporary key container name.  
  
-   0x00000001 (`SN_LEAVE_KEY`) - Specifies that the key should be left registered.  
  
 `ppbKeyBlob`  
 [out] The returned public/private key pair.  
  
 `pcbKeyBlob`  
 [out] The size, in bytes, of `ppbKeyBlob`.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 The `StrongNameKeyGen` function creates a 1024-bit key. After the key is retrieved, you should call the [StrongNameFreeBuffer](../../../../docs/framework/unmanaged-api/strong-naming/strongnamefreebuffer-function.md) function to release the allocated memory.  
  
 If the `StrongNameKeyGen` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameKeyGen Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygen-method.md)  
 [StrongNameKeyGenEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamekeygenex-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
