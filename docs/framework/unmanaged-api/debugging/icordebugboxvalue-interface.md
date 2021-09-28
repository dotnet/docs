---
description: "Learn more about: ICorDebugBoxValue Interface"
title: "ICorDebugBoxValue Interface"
ms.date: "03/30/2017"
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
---
# ICorDebugBoxValue Interface

A subclass of "ICorDebugHeapValue" that represents a boxed value class object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetObject Method](icordebugboxvalue-getobject-method.md)|Gets an interface pointer to the boxed "ICorDebugObjectValue" instance.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
