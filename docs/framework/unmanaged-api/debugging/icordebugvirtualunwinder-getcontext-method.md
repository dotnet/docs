---
description: "Learn more about: ICorDebugVirtualUnwinder::GetContext Method"
title: "ICorDebugVirtualUnwinder::GetContext Method"
ms.date: "03/30/2017"
ms.assetid: fe502a76-3068-47e5-a0a0-85ccb72dfac3
---
# ICorDebugVirtualUnwinder::GetContext Method

Gets the current context of this unwinder.  
  
## Syntax  
  
```cpp  
HRESULT GetContext(  
   [in] ULONG32 contextFlags,  
   [in] ULONG32 cbContextBuf,  
   [out] ULONG32* contextSize,  
   [out, size_is(cbContextBuf)] BYTE contextBuf[]  
);  
```  
  
## Parameters  

 `contextFlags`  
 [in] Flags that specify which parts of the context to return (defined in WinNT.h).  
  
 `cbContextBuf`  
 [in] The number of bytes in `contextBuf`.  
  
 `contextSize`  
 [out] A pointer to the number of bytes actually written to `contextBuf`.  
  
 `contextBuf`  
 [out] A byte array that contains the current context of this unwinder.  
  
## Return Value  

 Any failing HRESULT value received by mscordbi is considered fatal and will cause ICorDebug APIs to return `CORDBG_E_DATA_TARGET_ERROR`.  
  
## Remarks  

 You set the initial value of the `contextBuf` argument to the context buffer returned by calling the [ICorDebugStackWalk::GetContext](icordebugstackwalk-getcontext-method.md) method.  
  
> [!NOTE]
> This method is available with .NET Native only.  
  
 Because unwinding may only restore a subset of the registers, such as the non-volatile registers only, the context may not exactly match the register state at the time of the actual method call.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
