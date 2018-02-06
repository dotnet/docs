---
title: "CloseCLREnumeration Function"
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
  - "CloseCLREnumeration"
api_location: 
  - "dbgshim.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CloseCLREnumeration"
helpviewer_keywords: 
  - "debugging API [Silverlight]"
  - "Silverlight, debugging"
  - "CloseCLR Enumeration function"
ms.assetid: 5e3c3958-80bb-43b1-a96b-dd3e6dbd9cd7
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CloseCLREnumeration Function
Closes any valid common language runtime (CLR) continue-startup events located in an array of handles returned by the [EnumerateCLRs function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md), and frees the memory for the handle and string path arrays.  
  
## Syntax  
  
```  
HRESULT CloseCLREnumeration (  
    [in]  DWORD      pHandleArray,  
    [in]  LPWSTR**   pStringArray,  
    [in]  DWORD*     dwArrayLength  
);  
```  
  
#### Parameters  
 `pHandleArray`  
 [in] Pointer to the array of event handles returned from the [EnumerateCLRs function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md).  
  
 `pStringArray`  
 [in] Pointer to the array of CLR string paths returned from the [EnumerateCLRs function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md).  
  
 `dwArrayLength`  
 [in] DWORD that contains the size (length) of either `pHandleArray` or `pStringArray` (they are the same).  
  
## Return Value  
 S_OK  
 Handles opened by the [EnumerateCLRs function](../../../../docs/framework/unmanaged-api/debugging/enumerateclrs-function.md) are closed, and memory allocated for the handle and string arrays is freed.  
  
 E_INVALIDARG  
 The length of `pHandleArray` does not match the length that is passed in `dwArrayLength`.  
  
 E_FAIL (or other E_ return codes)  
 The function is unable to free the memory for `pHandleArray` and `pStringArray`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** dbgshim.h  
  
 **Library:** dbgshim.dll  
  
 **.NET Framework Versions:** 3.5 SP1
