---
description: "Learn more about: ICorDebugController::Terminate Method"
title: "ICorDebugController::Terminate Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugController.Terminate"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugController::Terminate"
helpviewer_keywords: 
  - "Terminate method, ICorDebugController interface [.NET Framework debugging]"
  - "ICorDebugController::Terminate method [.NET Framework debugging]"
ms.assetid: 4275af0c-b5a7-4e4c-97c9-7e41f36b2dd8
topic_type: 
  - "apiref"
---
# ICorDebugController::Terminate Method

Terminates the process with the specified exit code.  
  
> [!NOTE]
> This method is a wrapper for the Win32 `TerminateProcess` function. Thus, `Terminate` uses the exit code in the same way that the Win32 `TerminateProcess` function uses it.  
  
## Syntax  
  
```cpp  
HRESULT Terminate (  
    [in] UINT exitCode  
);  
```  
  
## Parameters  

 `exitCode`  
 [in] A numeric value that is the exit code. The valid numeric values are defined in Winbase.h.  
  
## Remarks  

 If the process is stopped when `Terminate` is called, the process should be continued by using the [ICorDebugController::Continue](icordebugcontroller-continue-method.md) method so that the debugger receives confirmation of the termination through the [ICorDebugManagedCallback::ExitProcess](icordebugmanagedcallback-exitprocess-method.md) or [ICorDebugManagedCallback::ExitAppDomain](icordebugmanagedcallback-exitappdomain-method.md) callback.  
  
> [!NOTE]
> This method is not implemented by an application domain. That is, it is not implemented at the <xref:System.AppDomain> level.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
