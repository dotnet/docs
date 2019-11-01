---
title: "ICorDebugFunction3 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: b22717b9-ead5-4eea-887e-789b52d613dc
topic_type: 
  - "apiref"
---
# ICorDebugFunction3 Interface
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Logically extends the ICorDebugFunction interface to provide access to code from a ReJIT request.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetActiveReJitRequestILCode Method](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction3-getactiverejitrequestilcode-method.md)|Gets an interface pointer to an [ICorDebugILCode](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-interface.md) that contains the IL from an active ReJIT request.|  
  
## Remarks  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [ReJIT: A How-To Guide](https://blogs.msdn.microsoft.com/davbr/2011/10/12/rejit-a-how-to-guide/)
