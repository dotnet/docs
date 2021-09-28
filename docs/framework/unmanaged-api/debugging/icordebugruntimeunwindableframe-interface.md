---
description: "Learn more about: ICorDebugRuntimeUnwindableFrame Interface"
title: "ICorDebugRuntimeUnwindableFrame Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugUnwindableFrame"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugUnwindableFrame"
helpviewer_keywords: 
  - "ICorDebugUnwindableFrame interface [.NET Framework debugging]"
ms.assetid: cd6a3982-6ed3-4909-808d-a66055e813e0
topic_type: 
  - "apiref"
---
# ICorDebugRuntimeUnwindableFrame Interface

Provides support for unmanaged methods that require the common language runtime (CLR) to unwind a frame.  
  
## Remarks  

 `ICorDebugRuntimeUnwindableFrame` is a specialized version of the ICorDebugFrame interface. It is used by unmanaged methods that require the runtime to unwind a frame on the current stack. Existing unwinding conventions do not work, because they do not use JIT-compiled code. When the debugger sees an unwindable frame, it should use the [ICorDebugStackWalk::Next](icordebugstackwalk-next-method.md) method to unwind it, but it should perform inspection itself. When the debugger receives an `ICorDebugRuntimeUnwindableFrame`, it can call the [ICorDebugStackWalk::GetContext](icordebugstackwalk-getcontext-method.md) method to retrieve the context of the frame.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
