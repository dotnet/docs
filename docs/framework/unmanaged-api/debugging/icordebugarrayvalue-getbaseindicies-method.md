---
description: "Learn more about: ICorDebugArrayValue::GetBaseIndicies Method"
title: "ICorDebugArrayValue::GetBaseIndicies Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue.GetBaseIndicies"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetBaseIndicies"
helpviewer_keywords: 
  - "ICorDebugArrayValue::GetBaseIndicies method [.NET Framework debugging]"
  - "GetBaseIndicies method [.NET Framework debugging]"
ms.assetid: 868b339b-acdb-4fe0-91c7-b85f4fba99eb
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue::GetBaseIndicies Method

Gets the base index of each dimension in the array.  
  
## Syntax  
  
```cpp  
HRESULT GetBaseIndicies (  
    [in] ULONG32          cdim,  
    [out, size_is(cdim), length_is(cdim)]
        ULONG32           indicies[]  
);  
```  
  
## Parameters  

 `cdim`  
 [in] The number of dimensions of this `ICorDebugArrayValue` object. This value is also the size of the `indicies` array because its size is equal to the number of dimensions of the `ICorDebugArrayValue` object.  
  
 `indicies`  
 [out] An array of integers, each of which is the base index (that is, the starting index) of a dimension of this `ICorDebugArrayValue` object.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
