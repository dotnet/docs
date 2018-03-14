---
title: "ICLRDataTarget::GetImageBase Method"
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
  - "ICLRDataTarget.GetImageBase"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetImageBase"
helpviewer_keywords: 
  - "ICLRDataTarget::GetImageBase method [.NET Framework debugging]"
  - "GetImageBase method [.NET Framework debugging]"
ms.assetid: 091c5f32-c160-49e3-a75f-4692e084c8e4
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::GetImageBase Method
Gets the base memory address of the specified image.  
  
## Syntax  
  
```  
HRESULT GetImageBase (  
    [in, string] LPCWSTR    imagePath,  
    [out] CLRDATA_ADDRESS   *baseAddress  
);  
```  
  
#### Parameters  
 `imagePath`  
 [in] The file name of the image, including its path.  
  
 `baseAddress`  
 [out] A pointer to a CLRDATA_ADDRESS that stores the base address of the image.  
  
## Remarks  
 The image file name may or may not have a path. If a path is specified, matching is done on the whole path; otherwise, matching is done only on the file name.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
