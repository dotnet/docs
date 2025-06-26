---
description: "Learn more about: ICorRuntimeHost::Stop Method"
title: "ICorRuntimeHost::Stop Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.Stop"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::Stop"
helpviewer_keywords: 
  - "Stop method, ICorRuntimeHost interface [.NET Framework hosting]"
  - "ICorRuntimeHost::Stop method [.NET Framework hosting]"
ms.assetid: 46a0d450-b516-4bef-8b71-8d3bf265cbed
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::Stop Method

Stops the execution of code in the runtime for the current process.  
  
## Syntax  
  
```cpp  
HRESULT Stop ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the common language runtime (CLR) is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Remarks  

 It is typically unnecessary to call the `Stop` method, because the code stops executing when the process exits.  
  
> [!NOTE]
> After a call to `Stop`, the CLR cannot be reinitialized into the same process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
