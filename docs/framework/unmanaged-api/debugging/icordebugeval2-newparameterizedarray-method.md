---
title: "ICorDebugEval2::NewParameterizedArray Method"
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
  - "ICorDebugEval2.NewParameterizedArray"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::NewParameterizedArray"
helpviewer_keywords: 
  - "ICorDebugEval2::NewParameterizedArray method [.NET Framework debugging]"
  - "NewParameterizedArray method [.NET Framework debugging]"
ms.assetid: 45efb8ba-c4de-4109-945f-e734d376b43c
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval2::NewParameterizedArray Method
Allocates a new array of the specified element type and dimensions.  
  
## Syntax  
  
```  
HRESULT NewParameterizedArray(  
    [in] ICorDebugType          *pElementType,  
    [in] ULONG32                rank,  
    [in, size_is(rank)] ULONG32 dims[],  
    [in, size_is(rank)] ULONG32 lowBounds[]  
);  
```  
  
#### Parameters  
 `pElementType`  
 [in] A pointer to an ICorDebugType object that represents the type of element stored in the array.  
  
 `rank`  
 [in] The number of dimensions of the array. In the .NET Framework version 2.0, this value must be 1.  
  
 `dims`  
 [in] The size, in bytes, of each dimension of the array.  
  
 `lowBounds`  
 [in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.  
  
## Remarks  
 The elements of the array may be instances of a generic type. The array is always created in the application domain in which the thread is currently running. In the .NET Framework 2.0, the value of `rank` must be 1.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
