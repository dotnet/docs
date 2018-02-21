---
title: "ICorDebugModule::EnableJITDebugging Method"
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
  - "ICorDebugModule.EnableJITDebugging"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule::EnableJITDebugging"
helpviewer_keywords: 
  - "ICorDebugModule::EnableJITDebugging method [.NET Framework debugging]"
  - "EnableJITDebugging method [.NET Framework debugging]"
ms.assetid: 0a65e2a4-5bb6-496c-ae6f-40474426b5a6
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModule::EnableJITDebugging Method
Controls whether the just-in-time (JIT) compiler preserves debugging information for methods within this module.  
  
## Syntax  
  
```  
HRESULT EnableJITDebugging(  
    [in] BOOL bTrackJITInfo,  
    [in] BOOL bAllowJitOpts  
);  
```  
  
#### Parameters  
 `bTrackJITInfo`  
 [in] Set this value to `true` to enable the JIT compiler to preserve mapping information between the Microsoft intermediate language (MSIL) version and the JIT-compiled version of each method in this module.  
  
 `bAllowJitOpts`  
 [in] Set this value to `true` to enable the JIT compiler to generate code with certain JIT-specific optimizations for debugging.  
  
## Remarks  
 JIT debugging is enabled by default for all modules that are loaded when the debugger is active. Programmatically enabling or disabling the settings overrides global settings.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
