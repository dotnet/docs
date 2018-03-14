---
title: "ICorProfilerCallback::RemotingServerSendingReply Method"
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
  - "ICorProfilerCallback.RemotingServerSendingReply"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerCallback::RemotingServerSendingReply"
helpviewer_keywords: 
  - "RemotingServerSendingReply method [.NET Framework profiling]"
  - "ICorProfilerCallback::RemotingServerSendingReply method [.NET Framework profiling]"
ms.assetid: dfe84a19-2e03-4be2-8b25-f02bad38e4a9
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerCallback::RemotingServerSendingReply Method
Notifies the profiler that the process has finished processing a remote method invocation request and is about to transmit the reply through a channel.  
  
## Syntax  
  
```  
HRESULT RemotingServerSendingReply(  
    [in] GUID *pCookie,  
    [in] BOOL fIsAsync);  
```  
  
#### Parameters  
 `pCookie`  
 [in] A pointer to a GUID that will correspond with the value provided in [ICorProfilerCallback::RemotingClientReceivingReply](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-remotingclientreceivingreply-method.md) under these conditions:  
  
-   Remoting GUID cookies are active.  
  
-   The channel succeeds in transmitting the message.  
  
-   GUID cookies are active on the client-side process.  
  
 This allows easy pairing of remoting calls and the creation of a logical call stack.  
  
 `fIsAsync`  
 [in] A value that is `true` if the call is asynchronous; otherwise, `false`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerCallback Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilercallback-interface.md)
