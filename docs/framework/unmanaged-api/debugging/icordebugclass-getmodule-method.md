---
title: "ICorDebugClass::GetModule Method"
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
  - "ICorDebugClass.GetModule"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass::GetModule"
helpviewer_keywords: 
  - "GetModule method, ICorDebugClass interface [.NET Framework debugging]"
  - "ICorDebugClass::GetModule method [.NET Framework debugging]"
ms.assetid: 87029cc4-e5e1-42d5-8b98-655bb7ece520
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugClass::GetModule Method
Gets the module that defines this class.  
  
## Syntax  
  
```  
HRESULT GetModule (  
    [out] ICorDebugModule    **pModule  
);  
```  
  
#### Parameters  
 `pModule`  
 [out] A pointer to the address of an ICorDebugModule object that represents the module in which this class is defined.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
