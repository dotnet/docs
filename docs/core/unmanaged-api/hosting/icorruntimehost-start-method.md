---
description: "Learn more about: ICorRuntimeHost::Start Method"
title: "ICorRuntimeHost::Start Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorRuntimeHost.Start"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorRuntimeHost::Start"
helpviewer_keywords: 
  - "Start method, ICorRuntimeHost interface [.NET Framework hosting]"
  - "ICorRuntimeHost::Start method [.NET Framework hosting]"
ms.assetid: c66f3ac5-6489-484a-9bed-c31b711cee01
topic_type: 
  - "apiref"
---
# ICorRuntimeHost::Start Method

Starts the common language runtime (CLR).  
  
## Syntax  
  
```cpp  
HRESULT Start ();  
```  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The operation was successful.|  
|S_FALSE|The operation failed to complete.|  
|E_FAIL|An unknown, catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable in the process. Subsequent calls to any hosting APIs return HOST_E_CLRNOTAVAILABLE.|  
|HOST_E_CLRNOTAVAILABLE|The CLR has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
  
## Remarks  

 It is typically not necessary to call the `Start` method, because the CLR starts automatically upon the first request to run managed code.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** 1.0, 1.1  
  
## See also

- [ICorRuntimeHost Interface](icorruntimehost-interface.md)
