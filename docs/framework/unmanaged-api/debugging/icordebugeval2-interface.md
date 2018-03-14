---
title: "ICorDebugEval2 Interface1"
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
  - "ICorDebugEval2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2"
helpviewer_keywords: 
  - "ICorDebugEval2 interface [.NET Framework debugging]"
ms.assetid: fce34531-2687-406d-9131-d6ad94f2ce0e
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2 Interface1
Extends "ICorDebugEval" to provide support for generic types.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[CallParameterizedFunction Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-callparameterizedfunction-method.md)|Sets up a call to the specified "ICorDebugFunction", which can be nested inside a type whose constructor takes type parameters, or can itself take type parameters.|  
|[CreateValueForType Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-createvaluefortype-method.md)|Gets a pointer to a new "ICorDebugValue" of the specified type, with an initial value of null or zero.|  
|[NewParameterizedArray Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedarray-method.md)|Allocates a new array of the specified element type and dimensions.|  
|[NewParameterizedObject Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedobject-method.md)|Instantiates a new parameterized type object and calls the object's constructor method.|  
|[NewParameterizedObjectNoConstructor Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedobjectnoconstructor-method.md)|Instantiates a new parameterized type object of the specified class without attempting to call a constructor method|  
|[NewStringWithLength Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newstringwithlength-method.md)|Creates a new string of the specified length with the specified contents.|  
|[RudeAbort Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-rudeabort-method.md)|Aborts the computation that this `ICorDebugEval2` is currently performing.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
