---
title: "ICorProfilerCallback::RemotingClientInvocationStarted Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerCallback.RemotingClientInvocationStarted"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingClientInvocationStarted"
helpviewer_keywords: 
  - "RemotingClientInvocationStarted method [.NET Framework profiling]"
  - "ICorProfilerCallback::RemotingClientInvocationStarted method [.NET Framework profiling]"
ms.assetid: 796b63f3-c809-47f1-89cc-b23ad8eb5e79
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ICorProfilerCallback::RemotingClientInvocationStarted Method
Notifies the profiler that a remoting call has started.  
  
## Syntax  
  
```  
HRESULT RemotingClientInvocationStarted();  
```  
  
## Remarks  
 This event is the same for synchronous and asynchronous calls.  
  
 Each of the following pairs of callbacks will occur on the same thread:  
  
-   `RemotingClientInvocationStarted` and [ICorProfilerCallback::RemotingClientSendingMessage](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingclientsendingmessage-method.md)  
  
-   [ICorProfilerCallback::RemotingClientReceivingReply](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingclientreceivingreply-method.md) and [ICorProfilerCallback::RemotingClientInvocationFinished](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingclientinvocationfinished-method.md)  
  
-   [ICorProfilerCallback::RemotingServerInvocationReturned](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingserverinvocationreturned-method.md) and [ICorProfilerCallback::RemotingServerSendingReply](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingserversendingreply-method.md)  
  
 You should be aware of the following issues with the remoting callbacks:  
  
-   Execution of a remoting function is not reflected by the profiler API, so notifications for functions that are called from the client and executed on the server are not properly received. The actual invocation happens via a proxy object; to the profiler, it appears that certain functions are JIT-compiled but never used.  
  
-   The profiler does not receive accurate notifications for asynchronous remoting events.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
