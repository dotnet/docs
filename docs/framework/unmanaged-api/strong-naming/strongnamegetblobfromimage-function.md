---
title: "StrongNameGetBlobFromImage Function"
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
  - "StrongNameGetBlobFromImage"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "StrongNameGetBlobFromImage"
helpviewer_keywords: 
  - "StrongNameGetBlobFromImage function [.NET Framework strong naming]"
ms.assetid: 1de658e6-da32-4d01-9097-6f43c92222e1
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# StrongNameGetBlobFromImage Function
Gets a binary representation of the assembly image at the specified memory address.  
  
 This function has been deprecated. Use the [ICLRStrongName::StrongNameGetBlobFromImage](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblobfromimage-method.md) method instead.  
  
## Syntax  
  
```  
BOOLEAN StrongNameGetBlobFromImage (  
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
 `true` on successful completion; otherwise, `false`.  
  
## Remarks  
 If the `StrongNameGetBlobFromImage` function does not complete successfully, call the [StrongNameErrorInfo](../../../../docs/framework/unmanaged-api/strong-naming/strongnameerrorinfo-function.md) function to retrieve the last generated error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** StrongName.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [StrongNameGetBlobFromImage Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblobfromimage-method.md)  
 [StrongNameGetBlob Method](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-strongnamegetblob-method.md)  
 [ICLRStrongName Interface](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md)
