---
title: "ICorDebugModule2::SetJMCStatus Method"
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
  - "ICorDebugModule2.SetJMCStatus"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule2::SetJMCStatus"
helpviewer_keywords: 
  - "SetJMCStatus method, ICorDebugModule2 interface [.NET Framework debugging]"
  - "ICorDebugModule2::SetJMCStatus method [.NET Framework debugging]"
ms.assetid: 8c6d2089-4dbb-4715-b9e9-2a4491c8c9ce
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule2::SetJMCStatus Method
Sets the Just My Code (JMC) status of all methods of all the classes in this ICorDebugModule2 to the specified value, except those in the `pTokens` array, which it sets to the opposite value.  
  
## Syntax  
  
```  
HRESULT SetJMCStatus (  
    [in] BOOL                        bIsJustMyCode,  
    [in] ULONG32                     cTokens,  
    [in, size_is(cTokens)] mdToken   pTokens[]  
);  
```  
  
#### Parameters  
 `bIsJustMycode`  
 [in] Set to `true` if the code is to be debugged; otherwise, set to `false`.  
  
 `cTokens`  
 [in] The size of the `pTokens` array.  
  
 `pTokens`  
 [in] An array of `mdToken` values, each of which refers to a method that will have its JMC status set to !`bIsJustMycode`.  
  
## Remarks  
 The JMC status of each method that is specified in the `pTokens` array is set to the opposite of the `bIsJustMycode` value. The status of all other methods in this module is set to the `bIsJustMycode` value.  
  
 The `SetJMCStatus` method erases all previous JMC settings in this module.  
  
 The `SetJMCStatus` method returns an S_OK HRESULT if all functions were set successfully. It returns a CORDBG_E_FUNCTION_NOT_DEBUGGABLE HRESULT if some functions that are marked `true` are not debuggable.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
