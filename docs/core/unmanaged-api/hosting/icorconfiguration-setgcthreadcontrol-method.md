---
description: "Learn more about: ICorConfiguration::SetGCThreadControl Method"
title: "ICorConfiguration::SetGCThreadControl Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorConfiguration.SetGCThreadControl"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetGCThreadControl"
helpviewer_keywords: 
  - "ICorConfiguration::SetGCThreadControl method [.NET Framework hosting]"
  - "SetGCThreadControl method [.NET Framework hosting]"
ms.assetid: 72e38e61-3d56-4ae3-b8f6-0ab7922aaf11
topic_type: 
  - "apiref"
---
# ICorConfiguration::SetGCThreadControl Method

Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.  
  
## Syntax  
  
```cpp  
HRESULT SetGCThreadControl (  
    [in] IGCThreadControl* pGCThreadControl  
);  
```  
  
## Parameters  

 `pGCThreadControl`  
 [in] A pointer to an [IGCThreadControl](igcthreadcontrol-interface.md) object that notifies the host about the suspension of threads for non-runtime tasks.  
  
## Remarks  

 The host may choose within the [IGCThreadControl::ThreadIsBlockingForSuspension](igcthreadcontrol-threadisblockingforsuspension-method.md) callback whether to reschedule a thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorConfiguration Interface](icorconfiguration-interface.md)
