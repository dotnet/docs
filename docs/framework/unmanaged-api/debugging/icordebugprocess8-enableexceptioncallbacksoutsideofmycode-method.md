---
title: "ICorDebugProcess8::EnableExceptionCallbacksOutsideOfMyCode Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
dev_langs: 
  - "cpp"
ms.assetid: b3af44ec-7d41-425b-aed9-0c4379e5cbe9
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess8::EnableExceptionCallbacksOutsideOfMyCode Method
[Supported in the [!INCLUDE[net_v46](../../../../includes/net-v46-md.md)] and later versions]  
  
 Enables or disables certain types of [ICorDebugManagedCallback2](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md) exception callbacks.  
  
## Syntax  
  
```cpp
HRESULT EnableExceptionCallbacksOutsideOfMyCode(  
   [in] BOOL enableExceptionsOutsideOfJMC  
);  
```  
  
#### Parameters  
 `enableExceptionsOutsideOfJMC`  
 [in]  
  
## Remarks  
 If the value of `enableExceptionsOutsideOfJMC` is `false`:  
  
-   A DEBUG_EXCEPTION_FIRST_CHANCE exception will not result in a callback to the debugger.  
  
-   A DEBUG_EXCEPTION_CATCH_HANDLER_FOUND exception will not result in a callback to the debugger if the exception never escapes into user code (that is, the path from an exception origin to an exception handler has no methods marked as JustMyCode, or JMC).  
  
 The default value of `enableExceptionsOutsideOfJMC` is `true`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See Also  
 [ICorDebugProcess8 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess8-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
