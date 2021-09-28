---
description: "Learn more about: ICorDebugManagedCallback2::ExceptionUnwind Method"
title: "ICorDebugManagedCallback2::ExceptionUnwind Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback2.ExceptionUnwind"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::ExceptionUnwind"
helpviewer_keywords: 
  - "ICorDebugManagedCallback2::ExceptionUnwind method [.NET Framework debugging]"
  - "ExceptionUnwind method [.NET Framework debugging]"
ms.assetid: aaf5938d-179c-4eaa-8d35-8523a4fadded
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback2::ExceptionUnwind Method

Provides a status notification during the exception unwinding process.  
  
## Syntax  
  
```cpp  
HRESULT ExceptionUnwind (  
    [in] ICorDebugAppDomain                  *pAppDomain,  
    [in] ICorDebugThread                     *pThread,  
    [in] CorDebugExceptionUnwindCallbackType  dwEventType,  
    [in] DWORD                                dwFlags  
);  
```  
  
## Parameters  

 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the thread on which the exception was thrown.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread on which the exception was thrown.  
  
 `dwEventType`  
 [in] A value of the CorDebugExceptionUnwindCallbackType enumeration that specifies the event that is being signaled by the callback during the unwind phase.  
  
 `dwFlags`  
 [in] A value of the [CorDebugExceptionFlags](cordebugexceptionflags-enumeration.md) enumeration that specifies additional information about the exception.  
  
## Remarks  

 `ExceptionUnwind` is called at various points during the unwind phase of the exception-handling process. `ExceptionUnwind` can be called more than once while unwinding a single exception.  
  
 If `dwEventType` = DEBUG_EXCEPTION_INTERCEPTED, the instruction pointer will be in the leaf frame of the thread, at the sequence point before (this may be several instructions before) the instruction that led to the exception.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback2 Interface](icordebugmanagedcallback2-interface.md)
- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
