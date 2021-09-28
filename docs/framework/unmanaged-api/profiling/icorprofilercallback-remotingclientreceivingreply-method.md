---
description: "Learn more about: ICorProfilerCallback::RemotingClientReceivingReply Method"
title: "ICorProfilerCallback::RemotingClientReceivingReply Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RemotingClientReceivingReply"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingClientReceivingReply"
helpviewer_keywords: 
  - "ICorProfilerCallback::RemotingClientReceivingReply method [.NET Framework profiling]"
  - "RemotingClientReceivingReply method [.NET Framework profiling]"
ms.assetid: 15cfc300-8231-4ecb-9a04-19851c3eb484
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RemotingClientReceivingReply Method

Notifies the profiler that the server-side portion of a remoting call has completed and the client is now receiving and about to process the reply.  
  
## Syntax  
  
```cpp  
HRESULT RemotingClientReceivingReply(  
    [in] GUID *pCookie,  
    [in] BOOL fIsAsync);
```  
  
## Parameters  

 `pCookie`  
 [in] A value that will correspond with the value provided in [ICorProfilerCallback::RemotingServerSendingReply](icorprofilercallback-remotingserversendingreply-method.md) under these conditions:  
  
- Remoting GUID cookies are active.  
  
- The channel succeeds in transmitting the message.  
  
- GUID cookies are active on the server-side process.  
  
 This allows easy pairing of remoting calls.  
  
 `fIsAsync`  
 [in] A value that is `true` if the call is asynchronous; otherwise, `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
