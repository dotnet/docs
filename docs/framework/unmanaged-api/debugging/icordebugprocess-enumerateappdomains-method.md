---
title: "ICorDebugProcess::EnumerateAppDomains Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebugProcess.EnumerateAppDomains"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugProcess::EnumerateAppDomains"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugProcess::EnumerateAppDomains method [.NET Framework debugging]"
  - "EnumerateAppDomains method [.NET Framework debugging]"
ms.assetid: d508981f-e2b2-445b-a649-69951c22702d
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugProcess::EnumerateAppDomains Method
Enumerates all the application domains in this process.  
  
## Syntax  
  
```  
HRESULT EnumerateAppDomains(  
    [out] ICorDebugAppDomainEnum **ppAppDomains);  
```  
  
#### Parameters  
 `ppAppDomains`  
 [out] A pointer to the address of an [ICorDebugAppDomainEnum](../../../../docs/framework/unmanaged-api/debugging/icordebugappdomainenum-interface.md) that is an enumerator for the application domains in this process.  
  
## Remarks  
 This method can be used before the [ICorDebugManagedCallback::CreateProcess](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-createprocess-method.md) callback.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]