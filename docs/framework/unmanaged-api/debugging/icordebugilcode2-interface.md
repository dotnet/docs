---
title: "ICorDebugILCode2 Interface"
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
  - "ICorDebugILCode2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: f9dc2afd-df8a-464d-bdbf-5af0a1d4bf85
topic_type: 
  - "apiref"
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILCode2 Interface
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Logically extends the [ICorDebugILCode](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-interface.md) interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetInstrumentedILMap Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-getinstrumentedilmap-method.md)|Returns a map from profiler instrumented IL offsets to original method IL offsets for this instance.|  
|[GetLocalVarSigToken Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-getlocalvarsigtoken-method.md)|Gets the metadata token for the local variable signature for the function that is represented by this instance.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [ICorDebugILCode Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
