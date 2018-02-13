---
title: "StrongNameSignatureVerificationFromImage Function"
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
  - "StrongNameSignatureVerificationFromImage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameSignatureVerificationFromImage"
helpviewer_keywords: 
  - "StrongnameSignatureVerificationFromImage function [.NET Framework strong naming]"
ms.assetid: 9fb144d2-07e0-4a0e-8e05-907bbb6c9e03
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameSignatureVerificationFromImage Function
Verifies that an assembly that has already been mapped to memory is valid for the associated public key.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameVerificationFromImage](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationfromimage-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameSignatureVerificationFromImage (  
    [in]  BYTE    *pbBase,  
    [in]  DWORD   dwLength,  
    [in]  DWORD   dwInFlags,  
    [out] DWORD   *pdwOutFlags  
);  
```  
  
#### Parameters  
 `pbBase`  
 [in] The relative virtual address of the mapped assembly manifest.  
  
 `dwLength`  
 [in] The size, in bytes, of the mapped image.  
  
 `dwInFlags`  
 [in] Flags that influence verification behavior. The following values are supported:  
  
-   `SN_INFLAG_FORCE_VER` (0x00000001) - Forces verification even if it is necessary to override registry settings.  
  
-   `SN_INFLAG_INSTALL` (0x00000002) - Specifies that this is the first verification performed on this image.  
  
-   `SN_INFLAG_ADMIN_ACCESS` (0x00000004) - Specifies that the cache will allow access only to users who have administrative privileges.  
  
-   `SN_INFLAG_USER_ACCESS` (0x00000008) - Specifies that the assembly will be accessible only to the current user.  
  
-   `SN_INFLAG_ALL_ACCESS` (0x00000010) - Specifies that the cache will provide no guarantees of access restriction.  
  
-   `SN_INFLAG_RUNTIME` (0x80000000) - Reserved for internal debugging.  
  
 `pdwOutFlags`  
 [out] A flag for additional output information. The following value is supported:  
  
-   `SN_OUTFLAG_WAS_VERIFIED` (0x00000001) - This value is set to `false` to specify that the verification succeeded due to registry settings.  
  
## Return Value  
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 If the `StrongNameSignatureVerificationFromImage` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in mscoree.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameSignatureVerificationFromImage Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationfromimage-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
