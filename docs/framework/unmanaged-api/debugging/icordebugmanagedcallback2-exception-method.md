---
title: "ICorDebugManagedCallback2::Exception Method"
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
  - "ICorDebugManagedCallback2.Exception"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback2::Exception"
helpviewer_keywords: 
  - "ICorDebugManagedCallback2::Exception method [.NET Framework debugging]"
  - "Exception method, ICorDebugManagedCallback2 interface [.NET Framework debugging]"
ms.assetid: 78b0f14f-2fae-4e63-8412-4df119ee8468
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback2::Exception Method
Notifies the debugger that a search for an exception handler has started.  
  
## Syntax  
  
```  
HRESULT Exception (  
    [in] ICorDebugAppDomain   *pAppDomain,  
    [in] ICorDebugThread      *pThread,  
    [in] ICorDebugFrame       *pFrame,  
    [in] ULONG32              nOffset,  
    [in] CorDebugExceptionCallbackType dwEventType,  
    [in] DWORD                dwFlags  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the thread on which the exception was thrown.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the thread on which the exception was thrown.  
  
 `pFrame`  
 [in] A pointer to an ICorDebugFrame object that represents a frame, as determined by the `dwEventType` parameter. For more information, see the table in the Remarks section.  
  
 `nOffset`  
 [in] An integer that specifies an offset, as determined by the `dwEventType` parameter. For more information, see the table in the Remarks section.  
  
 `dwEventType`  
 [in] A value of the CorDebugExceptionCallbackType enumeration that specifies the type of this exception callback.  
  
 `dwFlags`  
 [in] A value of the [CorDebugExceptionFlags](../../../../docs/framework/unmanaged-api/debugging/cordebugexceptionflags-enumeration.md) enumeration that specifies additional information about the exception  
  
## Remarks  
 The `Exception` callback is called at various points during the search phase of the exception-handling process. That is, it can be called more than once while unwinding an exception.  
  
 The exception being processed can be retrieved from the ICorDebugThread object referenced by the `pThread` parameter.  
  
 The particular frame and offset are determined by the `dwEventType` parameter as follows:  
  
|Value of `dwEventType`|Value of `pFrame`|Value of `nOffset`|  
|----------------------------|-----------------------|------------------------|  
|DEBUG_EXCEPTION_FIRST_CHANCE|The frame that threw the exception.|The instruction pointer in the frame.|  
|DEBUG_EXCEPTION_USER_FIRST_CHANCE|The user-code frame closest to the point of the thrown exception.|The instruction pointer in the frame.|  
|DEBUG_EXCEPTION_CATCH_HANDLER_FOUND|The frame that contains the catch handler.|The Microsoft intermediate language (MSIL) offset of the beginning of the catch handler.|  
|DEBUG_EXCEPTION_UNHANDLED|NULL|Undefined.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback2-interface.md)  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
