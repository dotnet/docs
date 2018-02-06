---
title: "ICorDebugILFrame::GetArgument Method"
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
  - "ICorDebugILFrame.GetArgument"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::GetArgument"
helpviewer_keywords: 
  - "GetArgument method [.NET Framework debugging]"
  - "ICorDebugILFrame::GetArgument method [.NET Framework debugging]"
ms.assetid: 4e2fd423-f643-4c27-ba5f-41b5ebc3b416
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::GetArgument Method
Gets the value of the specified argument in this Microsoft intermediate language (MSIL) stack frame.  
  
## Syntax  
  
```  
HRESULT GetArgument (  
    [in] DWORD                  dwIndex,  
    [out] ICorDebugValue        **ppValue  
);  
```  
  
#### Parameters  
 `dwIndex`  
 [in] The index of the argument in this MSIL stack frame.  
  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue object that represents the retrieved value.  
  
## Remarks  
 The `GetArgument` method can be used either in an MSIL stack frame or in a just-in-time (JIT) compiled frame.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
