---
title: "ICorDebugILFrame::EnumerateArguments Method"
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
  - "ICorDebugILFrame.EnumerateArguments"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::EnumerateArguments"
helpviewer_keywords: 
  - "ICorDebugILFrame::EnumerateArguments method [.NET Framework debugging]"
  - "EnumerateArguments method [.NET Framework debugging]"
ms.assetid: 00ac81e2-a774-422a-bd88-54a4b3c99f73
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::EnumerateArguments Method
Gets an enumerator for the arguments in this frame.  
  
## Syntax  
  
```  
HRESULT EnumerateArguments (  
    [out] ICorDebugValueEnum    **ppValueEnum  
);  
```  
  
#### Parameters  
 `ppValueEnum`  
 [out] A pointer to the address of an ICorDebugValueEnum object that is the enumerator for the arguments in this frame.  
  
## Remarks  
 `EnumerateArguments` gets an enumerator that can list the arguments available in the call frame that is represented by this ICorDebugILFrame object. The list will include arguments that are [vararg](/cpp/windows/vararg) (that is, a variable number of arguments) as well as arguments that are not `vararg`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
