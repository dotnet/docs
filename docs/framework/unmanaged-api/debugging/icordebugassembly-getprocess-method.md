---
title: "ICorDebugAssembly::GetProcess Method"
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
  - "ICorDebugAssembly.GetProcess"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAssembly::GetProcess"
helpviewer_keywords: 
  - "ICorDebugAssembly::GetProcess method [.NET Framework debugging]"
  - "GetProcess method, ICorDebugAssembly interface [.NET Framework debugging]"
ms.assetid: ea52be06-0a16-4f57-afca-4287d72e76c4
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugAssembly::GetProcess Method
Gets an interface pointer to the process in which this ICorDebugAssembly instance is running.  
  
## Syntax  
  
```  
HRESULT GetProcess (  
    [out] ICorDebugProcess **ppProcess  
);  
```  
  
#### Parameters  
 `ppProcess`  
 [out] A pointer to an ICorDebugProcess interface that represents the process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
