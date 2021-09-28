---
description: "Learn more about: IGCThreadControl::ThreadIsBlockingForSuspension Method"
title: "IGCThreadControl::ThreadIsBlockingForSuspension Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCThreadControl.ThreadIsBlockingForSuspension"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ThreadIsBlockingForSuspension"
helpviewer_keywords: 
  - "IGCThreadControl::ThreadIsBlockingForSuspension method [.NET Framework hosting]"
  - "ThreadIsBlockingForSuspension method [.NET Framework hosting]"
ms.assetid: ed5b5b58-7db7-46b5-9e2c-278db7159cee
topic_type: 
  - "apiref"
---
# IGCThreadControl::ThreadIsBlockingForSuspension Method

Notifies the host that the thread that is making the call is about to block, perhaps for a garbage collection or other suspension.  
  
## Syntax  
  
```cpp  
HRESULT ThreadIsBlockingForSuspension ( );  
```  
  
## Remarks  

 The host may choose within the `ThreadIsBlockingForSuspension` callback whether to reschedule a thread.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCThreadControl Interface](igcthreadcontrol-interface.md)
