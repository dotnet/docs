---
title: "StrongNameSignatureVerification Function"
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
  - "StrongNameSignatureVerification"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameSignatureVerification"
helpviewer_keywords: 
  - "StrongNameSignatureVerification function [.NET Framework strong naming]"
ms.assetid: 933758dd-231e-4382-8819-242c0a13a4b7
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameSignatureVerification Function
Gets a value indicating whether the assembly manifest at the supplied path contains a strong name signature, which is verified according to the specified flags.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameSignatureVerification](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverification-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameSignatureVerification (  
    [in]  LPCWSTR   wszFilePath,  
    [in]  DWORD     dwInFlags,  
    [out] DWORD     *pdwOutFlags  
);  
```  
  
#### Parameters  
 `wszFilePath`  
 [in] The path to the portable executable (.dll or .exe) file for the assembly to verify.  
  
 `dwInFlags`  
 [in] Flags to modify the verification behavior. The following values are supported:  
  
-   `SN_INFLAG_FORCE_VER` (0x00000001) - Forces verification even if it is necessary to override registry settings.  
  
-   `SN_INFLAG_INSTALL` (0x00000002) - Specifies that this is the first time the manifest is verified.  
  
-   `SN_INFLAG_ADMIN_ACCESS` (0x00000004) - Specifies that the cache will allow access only to users who have administrative privileges.  
  
-   `SN_INFLAG_USER_ACCESS` (0x00000008) - Specifies that the assembly will be accessible only to the current user.  
  
-   `SN_INFLAG_ALL_ACCESS` (0x00000010) - Specifies that the cache will provide no guarantees of access restriction.  
  
-   `SN_INFLAG_RUNTIME` (0x80000000) - Reserved for internal debugging.  
  
 `pdwOutFlags`  
 [out] Flags indicating whether the strong name signature was verified. The following value is supported:  
  
-   `SN_OUTFLAG_WAS_VERIFIED` (0x00000001) - This value is set to `false` to specify that the verification succeeded due to registry settings.  
  
## Return Value  
 `true` if the verification was successful; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameSignatureVerification Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverification-method.md)  
 [StrongNameSignatureVerificationEx Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamesignatureverificationex-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
