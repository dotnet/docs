---
description: "Learn more about: IGCThreadControl::SuspensionEnding Method"
title: "IGCThreadControl::SuspensionEnding Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCThreadControl.SuspensionEnding"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SuspensionEnding"
helpviewer_keywords: 
  - "IGCThreadControl::SuspensionEnding method [.NET Framework hosting]"
  - "SuspensionEnding method, IGCThreadControl interface [.NET Framework hosting]"
ms.assetid: 70814265-c734-4ddc-9502-fe8b28d2b414
topic_type: 
  - "apiref"
---
# IGCThreadControl::SuspensionEnding Method

Notifies the host that the runtime is resuming threads after a garbage collection or other suspension.  
  
## Syntax  
  
```cpp  
HRESULT SuspensionEnding (  
    [in] DWORD Generation  
);  
```  
  
## Parameters  

 `Generation`  
 [in] The generation on which a garbage collection has been performed.  
  
## Remarks  

 Do not reschedule any threads during the `SuspensionEnding` callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCThreadControl Interface](igcthreadcontrol-interface.md)
