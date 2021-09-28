---
description: "Learn more about: ICorDebugProcess::EnumerateAppDomains Method"
title: "ICorDebugProcess::EnumerateAppDomains Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugProcess.EnumerateAppDomains"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::EnumerateAppDomains"
helpviewer_keywords: 
  - "ICorDebugProcess::EnumerateAppDomains method [.NET Framework debugging]"
  - "EnumerateAppDomains method [.NET Framework debugging]"
ms.assetid: d508981f-e2b2-445b-a649-69951c22702d
topic_type: 
  - "apiref"
---
# ICorDebugProcess::EnumerateAppDomains Method

Enumerates all the application domains in this process.  
  
## Syntax  
  
``` cpp
HRESULT EnumerateAppDomains(  
    [out] ICorDebugAppDomainEnum **ppAppDomains);  
```  
  
## Parameters  

 `ppAppDomains`  
 [out] A pointer to the address of an [ICorDebugAppDomainEnum](icordebugappdomainenum-interface.md) that is an enumerator for the application domains in this process.  
  
## Remarks  

 This method can be used before the [ICorDebugManagedCallback::CreateProcess](icordebugmanagedcallback-createprocess-method.md) callback.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
