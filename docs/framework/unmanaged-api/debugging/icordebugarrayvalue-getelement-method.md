---
title: "ICorDebugArrayValue::GetElement Method"
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
  - "ICorDebugArrayValue.GetElement"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetElement"
helpviewer_keywords: 
  - "GetElement method [.NET Framework debugging]"
  - "ICorDebugArrayValue::GetElement method [.NET Framework debugging]"
ms.assetid: 7ac3cba5-c282-402e-b7ef-b46634f5176b
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugArrayValue::GetElement Method
Gets the value of the given array element.  
  
## Syntax  
  
```  
HRESULT GetElement (  
    [in]  ULONG32          cdim,  
    [in, size_is(cdim), length_is(cdim)]   
         ULONG32           indices[],  
    [out] ICorDebugValue   **ppValue  
);  
```  
  
#### Parameters  
 `cdim`  
 [in] The number of dimensions of this `ICorDebugArrayValue` object.  
  
 This value is also the size of the `indices` array because its size is equal to the number of dimensions of the `ICorDebugArrayValue` object.  
  
 `indices`  
 [in] An array of index values, each of which specifies a position within a dimension of the `ICorDebugArrayValue` object.  
  
 This value must not be null.  
  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue object that represents the value of the specified element.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
