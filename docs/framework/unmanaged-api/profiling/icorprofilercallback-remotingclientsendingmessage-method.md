---
description: "Learn more about: ICorProfilerCallback::RemotingClientSendingMessage Method"
title: "ICorProfilerCallback::RemotingClientSendingMessage Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RemotingClientSendingMessage"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingClientSendingMessage"
helpviewer_keywords: 
  - "RemotingClientSendingMessage method [.NET Framework profiling]"
  - "ICorProfilerCallback::RemotingClientSendingMessage method [.NET Framework profiling]"
ms.assetid: 54d9a5a5-3877-49c1-a503-ce7c7943bc2a
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RemotingClientSendingMessage Method

Notifies the profiler that the client is sending a request to the server.  
  
## Syntax  
  
```cpp  
HRESULT RemotingClientSendingMessage(  
    [in] GUID *pCookie,  
    [in] BOOL fIsAsync);  
```  
  
## Parameters  

 `pCookie`  
 [in] A value that corresponds with the value provided in [ICorProfilerCallback::RemotingServerReceivingMessage](icorprofilercallback-remotingserverreceivingmessage-method.md) under these conditions:  
  
- Remoting GUID cookies are active.  
  
- The channel succeeds in transmitting the message.  
  
- GUID cookies are active on the server-side process.  
  
 This allows easy pairing of remoting calls and the creation of a logical call stack.  
  
 `fIsAsync`  
 [in] A value that is `true` if the call is asynchronous; otherwise, `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
