---
title: "ICorDebugNativeFrame::GetIP Method"
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
  - "ICorDebugNativeFrame.GetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame::GetIP"
helpviewer_keywords: 
  - "GetIP method, ICorDebugNativeFrame interface [.NET Framework debugging]"
  - "ICorDebugNativeFrame::GetIP method [.NET Framework debugging]"
ms.assetid: 99f693f3-d3b9-4fd8-9d09-b8efd03f7b67
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame::GetIP Method
Gets the native code offset location to which the instruction pointer is currently set.  
  
## Syntax  
  
```  
HRESULT GetIP (  
    [out] ULONG32           *pnOffset  
);  
```  
  
#### Parameters  
 `pnOffset`  
 [out] A pointer to the offset location in the native code.  
  
## Remarks  
 If the stack frame that is represented by this "ICorDebugNativeFrame" is active, the offset is the address of the next instruction to be executed. If this stack frame is not active, the offset is the address of the next instruction to be executed when the stack frame is reactivated.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 
