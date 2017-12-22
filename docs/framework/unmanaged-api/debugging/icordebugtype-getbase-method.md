---
title: "ICorDebugType::GetBase Method"
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
  - "ICorDebugType.GetBase"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugType::GetBase"
helpviewer_keywords: 
  - "ICorDebugType::GetBase method [.NET Framework debugging]"
  - "GetBase method [.NET Framework debugging]"
ms.assetid: f24e1af9-c220-4f79-ae62-4153ec17ea81
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugType::GetBase Method
Gets an interface pointer to an ICorDebugType that represents the base type, if one exists, of the type represented by this `ICorDebugType`.  
  
## Syntax  
  
```  
HRESULT GetBase (  
    [out] ICorDebugType   **pBase  
);  
```  
  
#### Parameters  
 `pBase`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the base type.  
  
## Remarks  
 Looking up the base type for a type is useful to implement common debugger functionality, such as printing out all the fields of an object or its parent classes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
