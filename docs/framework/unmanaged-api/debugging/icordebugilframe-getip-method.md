---
title: "ICorDebugILFrame::GetIP Method"
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
  - "ICorDebugILFrame.GetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::GetIP"
helpviewer_keywords: 
  - "GetIP method, ICorDebugILFrame interface [.NET Framework debugging]"
  - "ICorDebugILFrame::GetIP method [.NET Framework debugging]"
ms.assetid: 18217ba1-1776-4297-a3b9-f77e64b0fead
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::GetIP Method
Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.  
  
## Syntax  
  
```  
HRESULT GetIP (  
    [out] ULONG32               *pnOffset,   
    [out] CorDebugMappingResult *pMappingResult  
);  
```  
  
#### Parameters  
 `pnOffset`  
 [out] The value of the instruction pointer.  
  
 `pMappingResult`  
 [out] A pointer to a bitwise combination of the CorDebugMappingResult enumeration values that describe how the value of the instruction pointer was obtained.  
  
## Remarks  
 The value of the instruction pointer is the stack frame's offset into the function's Microsoft intermediate language (MSIL) code. If the stack frame is active, this address is the next instruction to execute. If the stack frame is not active, this address is the next instruction to execute when the stack frame is reactivated.  
  
 If this frame is a just-in-time (JIT) compiled frame, the value of the instruction pointer will be determined by mapping backwards from the actual native instruction pointer, so the value may be only approximate.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
