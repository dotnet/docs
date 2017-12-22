---
title: "ICLRStrongName::StrongNameSignatureVerificationFromImage Method"
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
  - "ICLRStrongName.StrongNameSignatureVerificationFromImage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameSignatureVerificationFromImage"
helpviewer_keywords: 
  - "ICLRStrongName::StrongNameSignatureVerificationFromImage method [.NET Framework hosting]"
  - "StrongNameSignatureVerificationFromImage method, ICLRStrongName interface [.NET Framework hosting]"
ms.assetid: da91c138-ee30-4fd4-a040-464d97d7e41a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameSignatureVerificationFromImage Method
Verifies that an assembly that has already been mapped to memory is valid for the associated public key.  
  
## Syntax  
  
```  
HRESULT StrongNameSignatureVerificationFromImage (  
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
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
