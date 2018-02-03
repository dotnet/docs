---
title: "ICorDebugDataTarget::GetPlatform Method"
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
  - "ICorDebugDataTarget.GetPlatform Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugDataTarget::GetPlatform"
helpviewer_keywords: 
  - "GetPlatform method [.NET Framework debugging]"
  - "ICorDebugDataTarget::GetPlatform method [.NET Framework debugging]"
ms.assetid: 9ee96c9d-7a3d-4129-a6cc-7675c7f2dda4
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugDataTarget::GetPlatform Method
Provides information about the platform, including processor architecture and operating system, on which the target process is running.  
  
## Syntax  
  
```  
HRESULT GetPlatform([out] CorDebugPlatform * pTargetPlatform);  
```  
  
#### Parameters  
 `pTargetPlatform`  
 [out] A pointer to a [CorDebugPlatformEnum](../../../../docs/framework/unmanaged-api/debugging/cordebugplatform-enumeration.md) enumeration that describes the target platform.  
  
## Remarks  
 The `CorDebugPlatformEnum` enumeration return value is used by the [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) interface to determine details of the target process such as its pointer size, address space layout, register set, instruction format, context layout, and calling conventions.  
  
 The `pTargetPlatform` value may refer to a platform that is being emulated for the target instead of specifying the actual hardware in use. For example, a process that is running in the Windows on Windows (WOW) environment on a 64-bit edition of the Windows operating system should use the `CORDB_PLATFORM_WINDOWS_X86` value of the [CorDebugPlatformEnum](../../../../docs/framework/unmanaged-api/debugging/cordebugplatform-enumeration.md) enumeration.  
  
 This method must succeed. If it fails, the target platform is unusable. The method may fail for the following reasons:  
  
-   The platform that is being emulated for the target is unusable.  
  
-   The actual hardware on the target platform is unusable.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
