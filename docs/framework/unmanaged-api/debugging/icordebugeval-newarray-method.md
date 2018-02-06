---
title: "ICorDebugEval::NewArray Method"
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
  - "ICorDebugEval.NewArray"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::NewArray"
helpviewer_keywords: 
  - "NewArray method [.NET Framework debugging]"
  - "ICorDebugEval::NewArray method [.NET Framework debugging]"
ms.assetid: cc79a67d-5368-434d-a943-209db90491b9
topic_type: 
  - "apiref"
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::NewArray Method
Allocates a new array of the specified element type and dimensions.  
  
 This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::NewParameterizedArray](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-newparameterizedarray-method.md) instead.  
  
## Syntax  
  
```  
HRESULT NewArray (  
    [in] CorElementType     elementType,  
    [in] ICorDebugClass     *pElementClass,  
    [in] ULONG32            rank,  
    [in, size_is(rank)] ULONG32 dims[],  
    [in, size_is(rank)] ULONG32 lowBounds[]  
);  
```  
  
#### Parameters  
 `elementType`  
 [in] A value of the CorElementType enumeration that specifies the element type of the array.  
  
 `pElementClass`  
 [in] A pointer to a ICorDebugClass object that specifies the class of the element. This value may be null if the element type is a primitive type.  
  
 `rank`  
 [in] The number of dimensions of the array. In the .NET Framework 2.0, this value must be 1.  
  
 `dims`  
 [in] The size, in bytes, of each dimension of the array.  
  
 `lowBounds`  
 [in] Optional. The lower bound of each dimension of the array. If this value is omitted, a lower bound of zero is assumed for each dimension.  
  
## Remarks  
 The array is always created in the application domain in which the thread is currently executing.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0
