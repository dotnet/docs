---
title: "ICorDebugCode Interface1"
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
  - "ICorDebugCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode"
helpviewer_keywords: 
  - "ICorDebugCode interface [.NET Framework debugging]"
ms.assetid: 7bd14fb6-8b54-4484-a891-e3c21859c019
topic_type: 
  - "apiref"
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugCode Interface1
Represents a segment of either Microsoft intermediate language (MSIL) code or native code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CreateBreakpoint Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-createbreakpoint-method.md)|Creates a breakpoint at the specified offset.|  
|[GetAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getaddress-method.md)|Gets the relative virtual address (RVA) of the code segment that this `ICorDebugCode` represents.|  
|[GetCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getcode-method.md)|Gets all the code for the specified function, formatted for disassembly. This method has been deprecated; use [ICorDebugCode2::GetCodeChunks](../../../../docs/framework/unmanaged-api/debugging/icordebugcode2-getcodechunks-method.md) instead.|  
|[GetEnCRemapSequencePoints Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getencremapsequencepoints-method.md)|Not implemented.|  
|[GetFunction Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getfunction-method.md)|Gets the "ICorDebugFunction" associated with this `ICorDebugCode`.|  
|[GetILToNativeMapping Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getiltonativemapping-method.md)|Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from MSIL offsets to native offsets.|  
|[GetSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getsize-method.md)|Gets the size, in bytes, of the binary code represented by this `ICorDebugCode`.|  
|[GetVersionNumber Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getversionnumber-method.md)|Gets the one-based number that identifies the version of the code that this `ICorDebugCode` represents.|  
|[IsIL Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-isil-method.md)|Gets a value that indicates whether this `ICorDebugCode` is compiled in MSIL.|  
  
## Remarks  
 `ICorDebugCode` can represent either MSIL or native code. An "ICorDebugFunction" object that represents MSIL code can have either zero or one `ICorDebugCode` objects associated with it. An "ICorDebugFunction" object that represents native code can have any number of `ICorDebugCode` objects associated with it.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
 [ICorDebugCode3 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugcode3-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
