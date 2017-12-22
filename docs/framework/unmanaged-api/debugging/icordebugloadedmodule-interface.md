---
title: "ICorDebugLoadedModule Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 34be6369-2e75-4a95-a538-3b29ac97cf6d
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugLoadedModule Interface
Provides information about a loaded module.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetBaseAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebugloadedmodule-getbaseaddress-method.md)|Gets the base address of the loaded module.|  
|[GetName Method](../../../../docs/framework/unmanaged-api/debugging/icordebugloadedmodule-getname-method.md)|Gets the name of the loaded module.|  
|[GetSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugloadedmodule-getsize-method.md)|Gets the size in bytes of the loaded module.|  
  
## Remarks  
 The `ICorDebugLoadedModule` interface is implemented by a debugger and is used by the CLR debugging interfaces to get information about the loaded module from the debugger.  
  
> [!NOTE]
>  This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
