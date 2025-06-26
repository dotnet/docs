---
description: "Learn more about: ICLRTaskManager::GetCurrentTaskType Method"
title: "ICLRTaskManager::GetCurrentTaskType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRTaskManager.GetCurrentTaskType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRTaskManager::GetCurrentTaskType"
helpviewer_keywords: 
  - "GetCurrentTaskType method [.NET Framework hosting]"
  - "ICLRTaskManager::GetCurrentTaskType method [.NET Framework hosting]"
ms.assetid: 6b0d9259-dbe2-45bb-b34d-990f60c73424
topic_type: 
  - "apiref"
---
# ICLRTaskManager::GetCurrentTaskType Method

Gets the type of the task that is currently executing.  
  
## Syntax  
  
```cpp  
HRESULT GetCurrentTaskType(  
    [out] ETaskType *pTaskType  
);  
```  
  
## Parameters  

 `pTaskType`  
 [out] A pointer to a value of the [ETaskType](etasktype-enumeration.md) enumeration that indicates the type of task that is currently executing.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
