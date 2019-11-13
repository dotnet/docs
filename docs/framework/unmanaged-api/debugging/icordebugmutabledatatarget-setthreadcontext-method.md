---
title: "ICorDebugMutableDataTarget::SetThreadContext Method"
ms.date: "03/30/2017"
ms.assetid: 8c0d01d5-67e5-4522-9ccf-c8f3a78cb4fd
---
# ICorDebugMutableDataTarget::SetThreadContext Method
Sets the context (register values) for a thread.  
  
## Syntax  
  
```cpp  
HRESULT SetThreadContext(  
   [in] DWORD dwThreadID,  
   [in] ULONG32 contextSize,   [in, size_is(contextSize)] const BYTE * pContext);  
```  
  
## Parameters  
 `dwThreadID`  
 [in] The operating system-defined thread identifier.  
  
 `contextSize`  
 [in] The size of the `pContext` buffer to be written.  
  
 `pContext`  
 [in] A pointer to the bytes to be written.  
  
## Remarks  
 The `SetThreadContext` method updates the current context for the thread specified by the operating system-defined `dwThreadID` argument. The format of the context record is determined by the platform indicated by the [ICorDebugDataTarget::GetPlatform](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getplatform-method.md) method. On Windows, this is a [CONTEXT](/windows/win32/api/winnt/ns-winnt-arm64_nt_context) structure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See also

- [ICorDebugMutableDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmutabledatatarget-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
