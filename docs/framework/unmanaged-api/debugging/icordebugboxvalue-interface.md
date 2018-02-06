---
title: "ICorDebugBoxValue Interface1"
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
  - "ICorDebugBoxValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBoxValue"
helpviewer_keywords: 
  - "ICorDebugBoxValue interface [.NET Framework debugging]"
ms.assetid: 3d3ae7e2-97d4-46de-a2c3-cb78f3490f9d
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugBoxValue Interface1
A subclass of "ICorDebugHeapValue" that represents a boxed value class object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetObject Method](../../../../docs/framework/unmanaged-api/debugging/icordebugboxvalue-getobject-method.md)|Gets an interface pointer to the boxed "ICorDebugObjectValue" instance.|  
  
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
