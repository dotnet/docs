---
title: "ICorDebugFrame::GetStackRange Method"
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
  - "ICorDebugFrame.GetStackRange"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetStackRange"
helpviewer_keywords: 
  - "GetStackRange method, ICorDebugFrame interface [.NET Framework debugging]"
  - "ICorDebugFrame::GetStackRange method [.NET Framework debugging]"
ms.assetid: fab037cb-fda6-40fb-9367-921e435dd5a0
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFrame::GetStackRange Method
Gets the absolute address range of this stack frame.  
  
## Syntax  
  
```  
HRESULT GetStackRange (  
    [out] CORDB_ADDRESS      *pStart,   
    [out] CORDB_ADDRESS      *pEnd  
);  
```  
  
#### Parameters  
 `pStart`  
 [out] A pointer to a `CORDB_ADDRESS` that specifies the starting address of the stack frame represented by this `ICorDebugFrame` object.  
  
 `pEnd`  
 [out] A pointer to a `CORDB_ADDRESS` that specifies the ending address of the stack frame represented by this `ICorDebugFrame` object.  
  
## Remarks  
 The address range of the stack is useful for piecing together interleaved stack traces gathered from multiple debugging engines. The numeric range provides no information about the contents of the stack frame. It is meaningful only for comparison of stack frame locations.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
