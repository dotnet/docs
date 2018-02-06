---
title: "ICLRDataTarget::GetPointerSize Method"
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
  - "ICLRDataTarget.GetPointerSize"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetPointerSize"
helpviewer_keywords: 
  - "GetPointerSize method [.NET Framework debugging]"
  - "ICLRDataTarget::GetPointerSize method [.NET Framework debugging]"
ms.assetid: 51d9f4a4-81a7-4527-8537-5212bdb05c70
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::GetPointerSize Method
Gets the size, in bytes, of the pointer type that the target process uses. This method is called by the common language runtime data access services.  
  
## Syntax  
  
```  
HRESULT GetPointerSize (  
    [out] ULONG32     *pointerSize  
);  
```  
  
#### Parameters  
 `pointerSize`  
 [out] A pointer to an integer value that specifies the size, in bytes, of a pointer on the target process.  
  
## Remarks  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
