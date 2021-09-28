---
description: "Learn more about: ICorProfilerCallback::RemotingClientInvocationFinished Method"
title: "ICorProfilerCallback::RemotingClientInvocationFinished Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RemotingClientInvocationFinished"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingClientInvocationFinished"
helpviewer_keywords: 
  - "RemotingClientInvocationFinished method [.NET Framework profiling]"
  - "ICorProfilerCallback::RemotingClientInvocationFinished method [.NET Framework profiling]"
ms.assetid: ea4b283b-1210-4f41-a7a2-c398b1adde4e
topic_type: 
  - "apiref"
---
# ICorProfilerCallback::RemotingClientInvocationFinished Method

Notifies the profiler that a remoting call has run to completion on the client.  
  
## Syntax  
  
```cpp  
HRESULT RemotingClientInvocationFinished();  
```  
  
## Remarks  

 If the remoting call was synchronous, it has also run to completion on the server. If the remoting call was asynchronous, a reply might still be expected when the call is handled. If a reply is expected, it will occur as a call to [ICorProfilerCallback::RemotingClientReceivingReply](icorprofilercallback-remotingclientreceivingreply-method.md) and an additional call to `RemotingClientInvocationFinished` to indicate the required secondary processing of an asynchronous call.  
  
 Each of the following pairs of callbacks will occur on the same thread:  
  
- `RemotingClientInvocationStarted` and [ICorProfilerCallback::RemotingClientSendingMessage](icorprofilercallback-remotingclientsendingmessage-method.md)  
  
- [ICorProfilerCallback::RemotingClientReceivingReply](icorprofilercallback-remotingclientreceivingreply-method.md) and [ICorProfilerCallback::RemotingClientInvocationFinished](icorprofilercallback-remotingclientinvocationfinished-method.md)  
  
- [ICorProfilerCallback::RemotingServerInvocationReturned](icorprofilercallback-remotingserverinvocationreturned-method.md) and [ICorProfilerCallback::RemotingServerSendingReply](icorprofilercallback-remotingserversendingreply-method.md)  
  
 You should be aware of the following issues with the remoting callbacks:  
  
- Execution of a remoting function is not reflected by the profiler API, so notifications for functions that are called from the client and executed on the server are not properly received. The actual invocation happens via a proxy object; to the profiler, it appears that certain functions are JIT-compiled but never used.  
  
- The profiler does not receive accurate notifications for asynchronous remoting events.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](icorprofilercallback-interface.md)
