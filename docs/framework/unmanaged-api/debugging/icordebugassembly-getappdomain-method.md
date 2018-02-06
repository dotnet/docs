---
title: "ICorDebugAssembly::GetAppDomain Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugAssembly.GetAppDomain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetAppDomain"
helpviewer_keywords: 
  - "ICorDebugAssembly::GetAppDomain method [.NET Framework debugging]"
  - "GetAppDomain method, ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: 14e18510-23ac-4cba-9f96-c86147a2df9d
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly::GetAppDomain Method
Gets an interface pointer to the application domain that contains this `ICorDebugAssembly` instance.  
  
## Syntax  
  
```  
HRESULT GetAppDomain (  
    [out] ICorDebugAppDomain  **ppAppDomain  
);  
```  
  
#### Parameters  
 `ppAppDomain`  
 [out] A pointer to the address of an ICorDebugAppDomain interface that represents the application domain.  
  
## Remarks  
 If this assembly is the system assembly, `GetAppDomain` returns null.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
