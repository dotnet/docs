---
description: "Learn more about: ICorDebugComObjectValue Interface"
title: "ICorDebugComObjectValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugComObjectValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugComObjectValue"
helpviewer_keywords: 
  - "ICorDebugComObjectValue interface [.NET Framework debugging]"
ms.assetid: 505a7f6c-d92b-42b4-b539-433f5102ea9b
topic_type: 
  - "apiref"
---
# ICorDebugComObjectValue Interface

Provides methods to retrieve information associated with a runtime callable wrapper (RCW).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCachedInterfacePointers Method](icordebugcomobjectvalue-getcachedinterfacepointers-method.md)|Gets the raw interface pointers cached on the current RCW.|  
|[GetCachedInterfaceTypes Method](icordebugcomobjectvalue-getcachedinterfacetypes-method.md)|Provides an enumerator for the interface types that the current object has been cased to or used as.|  
  
## Remarks  

 To check whether an instance of an "ICorDebugValue" interface represents an RCW, a debugger calls `QueryInterface` on "ICorDebugValue" with `IID_ICorDebugComObjectValue`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
