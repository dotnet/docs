---
title: "ICorDebugAssembly Interface1"
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
  - "ICorDebugAssembly"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly"
helpviewer_keywords: 
  - "ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: 9d657a28-6984-4c5e-8a54-89d20080baff
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly Interface1
Represents an assembly.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateModules Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-enumeratemodules-method.md)|Gets an enumerator for the modules contained in the assembly.|  
|[GetAppDomain Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-getappdomain-method.md)|Gets an interface pointer to the application domain that contains this `ICorDebugAssembly` instance.|  
|[GetCodeBase Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-getcodebase-method.md)|Not implemented in the current version of the .NET Framework.|  
|[GetName Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-getname-method.md)|Gets the name of the assembly.|  
|[GetProcess Method](../../../../docs/framework/unmanaged-api/debugging/icordebugassembly-getprocess-method.md)|Gets the ICorDebugProcess instance in which the assembly is running.|  
  
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
