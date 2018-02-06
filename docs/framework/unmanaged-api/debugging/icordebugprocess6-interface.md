---
title: "ICorDebugProcess6 Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 34a10ac2-882c-4797-8369-f120e8e640c7
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess6 Interface
Logically extends the ICorDebugProcess interface to enable features such as decoding managed debug events that are encoded in native exception debug events and virtual module splitting.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[DecodeEvent Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-decodeevent-method.md)|Decodes managed debug events that have been encapsulated in the payload of specially crafted native exception debug events.|  
|[EnableVirtualModuleSplitting Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-enablevirtualmodulesplitting-method.md)|Enables or disables virtual module splitting.|  
|[GetCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-getcode-method.md)|Gets information about the managed code at a particular code address.|  
|[GetExportStepInfo Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-getexportstepinfo-method.md)|Provides information on runtime exported functions to help step through managed code.|  
|[MarkDebuggerAttached Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-markdebuggerattached-method.md)|Changes the internal state of the debugee so that the <xref:System.Diagnostics.Debugger.IsAttached%2A?displayProperty=nameWithType> method in the .NET Framework Class Library returns `true`.|  
|[ProcessStateChanged Method](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess6-processstatechanged-method.md)|Notifies [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) that the process is running.|  
  
## Remarks  
  
> [!NOTE]
>  The interface is available with .NET Native only. Attempting to call `QueryInterface` to retrieve an interface pointer returns `E_NOINTERFACE` for ICorDebug scenarios outside of .NET Native.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
