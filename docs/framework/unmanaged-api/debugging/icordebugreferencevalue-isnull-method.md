---
description: "Learn more about: ICorDebugReferenceValue::IsNull Method"
title: "ICorDebugReferenceValue::IsNull Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugReferenceValue.IsNull"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue::IsNull"
helpviewer_keywords: 
  - "IsNull method, ICorDebugReferenceValue interface [.NET Framework debugging]"
  - "ICorDebugReferenceValue::IsNull method [.NET Framework debugging]"
ms.assetid: 99e8c8d7-a1c0-47c8-9dbd-03e0b2bcb4d5
topic_type: 
  - "apiref"
---
# ICorDebugReferenceValue::IsNull Method

Gets a value that indicates whether this ICorDebugReferenceValue is a null value, in which case the `ICorDebugReferenceValue` does not point to an object.  
  
## Syntax  
  
```cpp  
HRESULT IsNull (  
    [out] BOOL   *pbNull  
);  
```  
  
## Parameters  

 `pbNull`  
 [out] A pointer to a Boolean value that is `true` if this `ICorDebugReferenceValue` object is null; otherwise, `pbNull` is `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
