---
title: "ICorDebugProcess2::GetDesiredNGENCompilerFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess2.GetDesiredNGENCompilerFlags"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::GetDesiredNGENCompilerFlags"
helpviewer_keywords: 
  - "ICorDebugProcess2::GetDesiredNGENCompilerFlags method [.NET Framework debugging]"
  - "GetDesiredNGENCompilerFlags method [.NET Framework debugging]"
ms.assetid: fc834580-3a90-4315-95d2-349b6bb7d059
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugProcess2::GetDesiredNGENCompilerFlags Method
Gets the current compiler flag settings that the common language runtime (CLR) uses to select the correct precompiled (that is, native) image to be loaded into this process.  
  
## Syntax  
  
```  
HRESULT GetDesiredNGENCompilerFlags (  
    [out] DWORD   *pdwFlags  
);  
```  
  
## Parameters  
 `pdwFlags`  
 [out] A pointer to a bitwise combination of the [CorDebugJITCompilerFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugjitcompilerflags-enumeration.md) enumeration values that are used to select the correct precompiled image to be loaded.  
  
## Remarks  
 Use the [ICorDebugProcess2::SetDesiredNGENCompilerFlags](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-setdesiredngencompilerflags-method.md) method to set the flags that the CLR will use to select the correct pre-compiled image to load.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
