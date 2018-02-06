---
title: "ICLRStrongName::StrongNameGetBlobFromImage Method"
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
  - "ICLRStrongName.StrongNameGetBlobFromImage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRStrongName::StrongNameGetBlobFromImage"
helpviewer_keywords: 
  - "StrongNameGetBlobFromImage method, ICLRStrongName interface [.NET Framework hosting]"
  - "ICLRStrongName::StrongNameGetBlobFromImage method [.NET Framework hosting]"
ms.assetid: 0f5a2ec8-e776-4fd8-bda6-937b6834575a
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRStrongName::StrongNameGetBlobFromImage Method
Gets a binary representation of the assembly image at the specified memory address.  
  
## Syntax  
  
```  
HRESULT StrongNameGetBlobFromImage (  
    [in]  BYTE        *pbBase,  
    [in]  DWORD       dwLength,  
    [in]  BYTE        *pbBlob,  
    [in, out] DWORD   *pcbBlob  
);  
```  
  
#### Parameters  
 `pbBase`  
 [in] The memory address of the mapped assembly manifest.  
  
 `dwLength`  
 [in] The size, in bytes, of the image at `pbBase`.  
  
 `pbBlob`  
 [in] A buffer to contain the binary representation of the image.  
  
 `pcbBlob`  
 [in, out] The requested maximum size, in bytes, of `pbBlob`. Upon return, the actual size, in bytes, of `pbBlob`.  
  
## Return Value  
 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](http://go.microsoft.com/fwlink/?LinkId=213878) for a list).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [StrongNameGetBlob Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblob-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
