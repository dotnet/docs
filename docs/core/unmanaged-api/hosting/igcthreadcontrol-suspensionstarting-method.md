---
description: "Learn more about: IGCThreadControl::SuspensionStarting Method"
title: "IGCThreadControl::SuspensionStarting Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCThreadControl.SuspensionStarting"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SuspensionStarting"
helpviewer_keywords: 
  - "IGCThreadControl::SuspensionStarting method [.NET Framework hosting]"
  - "SuspensionStarting method, IGCThreadControl interface [.NET Framework hosting]"
ms.assetid: 0af312af-98e9-415e-b182-42e80a1aee51
topic_type: 
  - "apiref"
---
# IGCThreadControl::SuspensionStarting Method

Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.  
  
## Syntax  
  
```cpp  
HRESULT SuspensionStarting ( );  
```  
  
## Remarks  

 Do not reschedule any threads during the `SuspensionStarting` callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCThreadControl Interface](igcthreadcontrol-interface.md)
