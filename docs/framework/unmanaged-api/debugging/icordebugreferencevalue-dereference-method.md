---
description: "Learn more about: ICorDebugReferenceValue::Dereference Method"
title: "ICorDebugReferenceValue::Dereference Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugReferenceValue.Dereference"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugReferenceValue::Dereference"
helpviewer_keywords: 
  - "ICorDebugReferenceValue::Dereference method [.NET Framework debugging]"
  - "Dereference method [.NET Framework debugging]"
ms.assetid: 5ec8cf76-3deb-4ce6-9a49-77a4c35d80b9
topic_type: 
  - "apiref"
---
# ICorDebugReferenceValue::Dereference Method

Gets the object that is referenced.  
  
## Syntax  
  
```cpp  
HRESULT Dereference (  
    [out] ICorDebugValue  **ppValue  
);  
```  
  
## Parameters  

 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue that represents the object to which this ICorDebugReferenceValue object points.  
  
## Remarks  

 The `ICorDebugValue` object is valid only while its reference has not yet been disabled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
