---
description: "Learn more about: ICorProfilerCallback::RemotingServerReceivingMessage Method"
title: "ICorProfilerCallback::RemotingServerReceivingMessage Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RemotingServerReceivingMessage"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingServerReceivingMessage"
helpviewer_keywords: 
  - "ICorProfilerCallback::RemotingServerReceivingMessage method [.NET Framework profiling]"
  - "RemotingServerReceivingMessage method [.NET Framework profiling]"
ms.assetid: 5604d21f-e6b7-490e-b469-42122a7568e1
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RemotingServerReceivingMessage Method

Notifies the profiler that the process has received a remote method invocation or activation request.  
  
## Syntax  
  
```cpp  
HRESULT RemotingClientSendingMessage(  
    [in] GUID *pCookie,  
    [in] BOOL fIsAsync);  
```  
  
## Parameters  

 `pCookie`  
 [in] A value that will correspond with the value provided in [ICorProfilerCallback::RemotingClientSendingMessage](icorprofilercallback-remotingclientsendingmessage-method.md) under these conditions:  
  
- Remoting GUID cookies are active.  
  
- The channel succeeds in transmitting the message.  
  
- GUID cookies are active on the client-side process.  
  
 This allows easy pairing of remoting calls and the creation of a logical call stack.  
  
 `fIsAsync`  
 [in] A value that is `true` if the call is asynchronous; otherwise, `false`.  
  
## Remarks  

 If the message request is asynchronous, the request can be serviced by any arbitrary thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
