---
description: "Learn more about: ICorDebugManagedCallback::LogSwitch Method"
title: "ICorDebugManagedCallback::LogSwitch Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugManagedCallback.LogSwitch"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::LogSwitch"
helpviewer_keywords: 
  - "LogSwitch method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::LogSwitch method [.NET Framework debugging]"
ms.assetid: 0ac59d27-783f-4a87-b7a8-baa3ccc54582
topic_type: 
  - "apiref"
---
# ICorDebugManagedCallback::LogSwitch Method

Notifies the debugger that a common language runtime (CLR) managed thread has called a method in the <xref:System.Diagnostics.Switch> class to create, modify, or delete a debugging/tracing switch.  
  
## Syntax  
  
```cpp  
HRESULT LogSwitch (  
    [in] ICorDebugAppDomain  *pAppDomain,  
    [in] ICorDebugThread     *pThread,  
    [in] LONG                 lLevel,  
    [in] ULONG                ulReason,  
    [in] WCHAR               *pLogSwitchName,  
    [in] WCHAR               *pParentName);  
```  
  
## Parameters  

 `PAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the managed thread that created, modified, or deleted a debugging/tracing switch.  
  
 `pThread`  
 [in] A pointer to an ICorDebugThread object that represents the managed thread.  
  
 `lLevel`  
 [in] A value that indicates the severity level of the descriptive message that was written to the event log.  
  
 `ulReason`  
 [in] A value of the [LogSwitchCallReason](logswitchcallreason-enumeration.md) enumeration that indicates the operation performed on the debugging/tracing switch.  
  
 `pLogSwitchName`  
 [in] A pointer to the name of the debugging/tracing switch.  
  
 `pParentName`  
 [in] A pointer to the name of the parent of the debugging/tracing switch.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
