---
title: "ICorDebugExceptionObjectValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugExceptionObjectValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugExceptionObjectValue"
helpviewer_keywords: 
  - "ICorDebugExceptionObjectValue interface [.NET Framework debugging]"
ms.assetid: 43416dd5-8892-4106-9f59-f9143b19ddb4
topic_type: 
  - "apiref"
---
# ICorDebugExceptionObjectValue Interface
Extends the "ICorDebugObjectValue" interface to provide stack trace information from a managed exception object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateExceptionCallStack Method](../../../../docs/framework/unmanaged-api/debugging/icordebugexceptionobjectvalue-enumerateexceptioncallstack-method.md)|Gets an enumerator to the call stack embedded in an exception object.|  
  
## Remarks  
 The call to `QueryInterface` will succeed for managed objects that derive from <xref:System.Exception?displayProperty=nameWithType>.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
