---
title: "ICorDebugModuleBreakpoint Interface1"
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
  - "ICorDebugModuleBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModuleBreakpoint"
helpviewer_keywords: 
  - "ICorDebugModuleBreakpoint interface [.NET Framework debugging]"
ms.assetid: 34667162-f314-475f-ae1b-ce9cb0fcbb83
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugModuleBreakpoint Interface1
Provides access to specific modules. This interface is a subclass of the ICorDebugBreakpoint interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetModule Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmodulebreakpoint-getmodule-method.md)|Gets an interface pointer to an ICorDebugModule that references the module where this breakpoint is set.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
