---
description: "Learn more about: ICorDebugArrayValue Interface"
title: "ICorDebugArrayValue Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue interface"
helpviewer_keywords: 
  - "ICorDebugArrayValue interface [.NET Framework debugging]"
ms.assetid: dc437751-7093-44e2-bfdc-191d9ce3c192
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue Interface

A subclass of ICorDebugHeapValue that represents a single-dimensional or multi-dimensional array.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetBaseIndicies Method](icordebugarrayvalue-getbaseindicies-method.md)|Gets the base index of each dimension in the array.|  
|[GetCount Method](icordebugarrayvalue-getcount-method.md)|Gets the total number of elements in the array.|  
|[GetDimensions Method](icordebugarrayvalue-getdimensions-method.md)|Gets the dimensions of the array.|  
|[GetElement Method](icordebugarrayvalue-getelement-method.md)|Gets a value representing the given element in the array.|  
|[GetElementAtPosition Method](icordebugarrayvalue-getelementatposition-method.md)|Gets the element at the given position, treating the array as a zero-based, single-dimensional array.|  
|[GetElementType Method](icordebugarrayvalue-getelementtype-method.md)|Gets the simple type of the elements in the array.|  
|[GetRank Method](icordebugarrayvalue-getrank-method.md)|Gets the number of dimensions in the array.|  
|[HasBaseIndicies Method](icordebugarrayvalue-hasbaseindicies-method.md)|Determines whether the array has base indexes.|  
  
## Remarks  

 `ICorDebugArrayValue` supports both single-dimensional and multi-dimensional arrays.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
