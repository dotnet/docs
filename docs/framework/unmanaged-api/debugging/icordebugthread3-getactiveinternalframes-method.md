---
description: "Learn more about: ICorDebugThread3::GetActiveInternalFrames Method"
title: "ICorDebugThread3::GetActiveInternalFrames Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread3.GetActiveInternalFrames Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread3::GetActiveInternalFrames"
helpviewer_keywords: 
  - "ICorDebugThread3::GetActiveInternalFrames method [.NET Framework debugging]"
  - "GetActiveInternalFrames method [.NET Framework debugging]"
ms.assetid: d69796b4-5b6d-457c-85f6-2cf42e8a8773
topic_type: 
  - "apiref"
---
# ICorDebugThread3::GetActiveInternalFrames Method

Returns an array of internal frames ([ICorDebugInternalFrame2](icordebuginternalframe2-interface.md) objects) on the stack.  
  
## Syntax  
  
```cpp
HRESULT GetActiveInternalFrames  
      (  
      [in] ULONG32 cInternalFrames,  
      [out] ULONG32 *pcInternalFrames,  
      [in, out,size_is(cInternalFrames), length_is(*pcInternalFrames)]  
            ICorDebugInternalFrame2 * ppInternalFrames[]  
      );  
```  
  
## Parameters  

 `cInternalFrames`  
 [in] The number of internal frames expected in `ppInternalFrames`.  
  
 `pcInternalFrames`  
 [out] A pointer to a `ULONG32` that contains the number of internal frames on the stack.  
  
 `ppInternalFrames`  
 [in, out] A pointer to the address of an array of internal frames on the stack.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The [ICorDebugInternalFrame2](icordebuginternalframe2-interface.md) object was successfully created.|  
|E_INVALIDARG|`cInternalFrames` is not zero and `ppInternalFrames` is `null`, or `pcInternalFrames` is `null`.|  
|HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)|`ppInternalFrames` is smaller than the count of internal frames.|  
  
## Exceptions  
  
## Remarks  

 Internal frames are data structures pushed onto the stack by the runtime to store temporary data.  
  
 When you first call `GetActiveInternalFrames`, you should set the `cInternalFrames` parameter to 0 (zero), and the `ppInternalFrames` parameter to null. When `GetActiveInternalFrames` first returns, `pcInternalFrames` contains the count of the internal frames on the stack.  
  
 `GetActiveInternalFrames` should then be called a second time. You should pass the proper count (`pcInternalFrames`) in the `cInternalFrames` parameter, and specify a pointer to an appropriately sized array in `ppInternalFrames`.  
  
 Use the [ICorDebugStackWalk::GetFrame](icordebugthread3-getactiveinternalframes-method.md) method to return actual stack frames.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
