---
title: "ICorDebugProcess2::GetThreadForTaskID Method"
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
  - "ICorDebugProcess2.GetThreadForTaskID"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::GetThreadForTaskID"
helpviewer_keywords: 
  - "ICorDebugProcess2::GetThreadForTaskId method [.NET Framework debugging]"
  - "GetThreadForTaskID method [.NET Framework debugging]"
ms.assetid: 32d54a5b-8ad3-405b-a1b9-0936a3b49d1e
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess2::GetThreadForTaskID Method
Gets the thread on which the task with the specified identifier is executing.  
  
## Syntax  
  
```  
HRESULT GetThreadForTaskID (  
    [in]  TASKID            taskid,  
    [out] ICorDebugThread2  **ppThread  
);  
```  
  
#### Parameters  
 `taskid`  
 [in] The identifier of the task.  
  
 `ppThread`  
 [out] A pointer to the address of an ICorDebugThread2 object that represents the thread to be retrieved.  
  
## Remarks  
 The host can set the task identifier by using the [ICLRTask::SetTaskIdentifier](../../../../docs/framework/unmanaged-api/hosting/iclrtask-settaskidentifier-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
