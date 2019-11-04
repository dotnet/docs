---
title: "ICorDebugArrayValue::GetDimensions Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugArrayValue.GetDimensions"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugArrayValue::GetDimensions"
helpviewer_keywords: 
  - "ICorDebugArrayValue::GetDimensions method [.NET Framework debugging]"
  - "GetDimensions method [.NET Framework debugging]"
ms.assetid: 6c116592-134b-4ef2-a319-680e92d013aa
topic_type: 
  - "apiref"
---
# ICorDebugArrayValue::GetDimensions Method
Gets the number of elements in each dimension of this array.  
  
## Syntax  
  
```cpp  
HRESULT GetDimensions (  
    [in] ULONG32         cdim,  
    [out, size_is(cdim), length_is(cdim)]   
        ULONG32          dims[]  
);  
```  
  
## Parameters  
 `cdim`  
 [in] The number of dimensions of this ICorDebugArrayValue object.  
  
 This value is also the size of the `dims` array because its size is equal to the number of dimensions of the `ICorDebugArrayValue` object.  
  
 `dims`  
 [out] An array of integers, each of which specifies the number of elements in a dimension in this `ICorDebugArrayValue` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
