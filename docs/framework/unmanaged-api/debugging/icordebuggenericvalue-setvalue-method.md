---
description: "Learn more about: ICorDebugGenericValue::SetValue Method"
title: "ICorDebugGenericValue::SetValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugGenericValue.SetValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugGenericValue::SetValue"
helpviewer_keywords: 
  - "ICorDebugGenericValue::SetValue method [.NET Framework debugging]"
  - "SetValue method, ICorDebugGenericValue interface [.NET Framework debugging]"
ms.assetid: ed4c6458-0435-44fc-8e78-8ba00be362f2
topic_type: 
  - "apiref"
---
# ICorDebugGenericValue::SetValue Method

Copies a new value from the specified buffer.  
  
## Syntax  
  
```cpp  
HRESULT SetValue (  
    [in] void      *pFrom  
);  
```  
  
## Parameters  

 `pFrom`  
 [in] A pointer to the buffer from which to copy the value.  
  
## Remarks  

 For reference types, the value is the reference, not the content.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
