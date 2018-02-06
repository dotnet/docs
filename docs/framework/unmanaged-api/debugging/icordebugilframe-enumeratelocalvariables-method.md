---
title: "ICorDebugILFrame::EnumerateLocalVariables Method"
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
  - "ICorDebugILFrame.EnumerateLocalVariables"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::EnumerateLocalVariables"
helpviewer_keywords: 
  - "EnumerateLocalVariables method [.NET Framework debugging]"
  - "ICorDebugILFrame::EnumerateLocalVariables method [.NET Framework debugging]"
ms.assetid: 1a67fa1b-2419-4cd0-aad4-6f46a0719b4b
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::EnumerateLocalVariables Method
Gets an enumerator for the local variables in this frame.  
  
## Syntax  
  
```  
HRESULT EnumerateLocalVariables(   
    [out] ICorDebugValueEnum    **ppValueEnum  
);  
```  
  
#### Parameters  
 `ppValueEnum`  
 [out] A pointer to the address of an ICorDebugValueEnum object that is the enumerator for the local variables in this frame.  
  
## Remarks  
 `EnumerateLocalVariables` gets an enumerator that can list the local variables available in the call frame that is represented by this ICorDebugILFrame object. The list may not include all of the local variables in the running function, because some of them may not be active.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
