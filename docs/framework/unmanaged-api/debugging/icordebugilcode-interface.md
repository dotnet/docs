---
title: "ICorDebugILCode Interface"
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
  - "ICorDebugILCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: 51c4de0c-3813-4142-be25-a85bb84efb90
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILCode Interface
[Supported in the .NET Framework 4.5.2 and later versions]  
  
 Represents a segment of intermediate language (IL) code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetEHClauses Method](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode-getehclauses-method.md)|Returns a pointer to a list of exception handling (EH) clauses that are defined for this IL.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
