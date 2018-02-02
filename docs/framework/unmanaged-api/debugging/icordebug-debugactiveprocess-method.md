---
title: "ICorDebug::DebugActiveProcess Method"
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
  - "ICorDebug.DebugActiveProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebug::DebugActiveProcess"
helpviewer_keywords: 
  - "DebugActiveProcess method [.NET Framework debugging]"
  - "ICorDebug::DebugActiveProcess method [.NET Framework debugging]"
ms.assetid: fdab0ade-7f56-4fa2-b3ef-f7a1d2852bba
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebug::DebugActiveProcess Method
Attaches the debugger to an existing process.  
  
## Syntax  
  
```  
HRESULT DebugActiveProcess (  
    [in]  DWORD               id,  
    [in]  BOOL                win32Attach,  
    [out] ICorDebugProcess    **ppProcess  
);  
```  
  
#### Parameters  
 `id`  
 [in] The ID of the process to which the debugger is to be attached.  
  
 `win32Attach`  
 [in] Boolean value that is set to `true` if the debugger should behave as the Win32 debugger for the process and dispatch the unmanaged callbacks; otherwise, `false`.  
  
 `ppProcess`  
 [out] A pointer to the address of an "ICorDebugProcess" object that represents the process to which the debugger has been attached.  
  
## Remarks  
 Interop debugging is not supported on Win9x and non-x86 platforms, such as IA-64-based and AMD64-based platforms.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
