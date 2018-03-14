---
title: "ICorDebugBoxValue::GetObject Method"
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
  - "ICorDebugBoxValue.GetObject"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugBoxValue::GetObject"
helpviewer_keywords: 
  - "ICorDebugBoxValue::GetObject method [.NET Framework debugging]"
  - "GetObject method, ICorDebugBoxValue interface [.NET Framework debugging]"
ms.assetid: 3a867a5b-bf94-493f-a4f5-b28685cf5325
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugBoxValue::GetObject Method
Gets the boxed value.  
  
## Syntax  
  
```  
HRESULT GetObject (  
    [out] ICorDebugObjectValue **ppObject  
);  
```  
  
#### Parameters  
 `ppObject`  
 [out] A pointer to the address of an ICorDebugObjectValue object that represents the boxed value.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
