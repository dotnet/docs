---
description: "Learn more about: ICorPublishProcess::EnumAppDomains Method"
title: "ICorPublishProcess::EnumAppDomains Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishProcess.EnumAppDomains"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishProcess::EnumAppDomains"
helpviewer_keywords: 
  - "EnumAppDomains method [.NET Framework debugging]"
  - "ICorPublishProcess::EnumAppDomains method [.NET Framework debugging]"
ms.assetid: 7da621fc-e7d0-4c00-9439-5c93619d7414
topic_type: 
  - "apiref"
---
# ICorPublishProcess::EnumAppDomains Method

Gets an enumerator for the application domains in the process that is referenced by this [ICorPublishProcess](icorpublishprocess-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT EnumAppDomains (  
    [out] ICorPublishAppDomainEnum   **ppEnum  
);  
```  
  
## Parameters  

 `ppEnum`  
 [out] A pointer to the address of an [ICorPublishAppDomainEnum](icorpublishappdomainenum-interface.md) instance that allows iteration through the collection of application domains in this process.  
  
## Remarks  

 The list of application domains is based on a snapshot of the application domains that exist when the `EnumAppDomains` method is called. This method may be called more than once to create a new up-to-date list. Existing lists will not be affected by subsequent calls of this method.  
  
 If the process has been terminated, `EnumAppDomains` will fail with an HRESULT value of CORDBG_E_PROCESS_TERMINATED.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishProcess Interface](icorpublishprocess-interface.md)
