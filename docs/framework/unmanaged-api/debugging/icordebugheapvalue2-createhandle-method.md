---
title: "ICorDebugHeapValue2::CreateHandle Method"
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
  - "ICorDebugHeapValue2.CreateHandle"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugHeapValue2::CreateHandle"
helpviewer_keywords: 
  - "CreateHandle method [.NET Framework debugging]"
  - "ICorDebugHeapValue2::CreateHandle method [.NET Framework debugging]"
ms.assetid: fbc418e8-fa22-420d-84ec-e0e1800db041
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugHeapValue2::CreateHandle Method
Creates a handle of the specified type for the heap value represented by this ICorDebugHeapValue2 object.  
  
## Syntax  
  
```  
HRESULT CreateHandle (  
    [in] CorDebugHandleType      type,   
    [out] ICorDebugHandleValue   **ppHandle  
);  
```  
  
#### Parameters  
 `type`  
 [in] A value of the CorDebugHandleType enumeration that specifies the type of handle to be created.  
  
 `ppHandle`  
 [out] A pointer to the address of an ICorDebugHandleValue object that represents the new handle for this heap value.  
  
## Remarks  
 The handle will be created in the application domain that is associated with the heap value, and will become invalid if the application domain gets unloaded.  
  
 Multiple calls to this function for the same heap value will create multiple handles. Because handles affect the performance of the garbage collector, the debugger should limit itself to a relatively small number of handles (about 256) that are active at a time.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
