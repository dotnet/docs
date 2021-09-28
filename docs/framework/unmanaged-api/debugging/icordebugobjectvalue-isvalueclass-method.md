---
description: "Learn more about: ICorDebugObjectValue::IsValueClass Method"
title: "ICorDebugObjectValue::IsValueClass Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugObjectValue.IsValueClass"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugObjectValue::IsValueClass"
helpviewer_keywords: 
  - "ICorDebugObjectValue::IsValueClass method [.NET Framework debugging]"
  - "IsValueClass method [.NET Framework debugging]"
ms.assetid: 13d89a4a-5d9d-4a79-9600-5e2a98c3d166
topic_type: 
  - "apiref"
---
# ICorDebugObjectValue::IsValueClass Method

Gets a value that indicates whether this object value is a value type.  
  
## Syntax  
  
```cpp  
HRESULT IsValueClass (  
    [out] BOOL               *pbIsValueClass  
);  
```  
  
## Parameters  

 `pbIsValueClass`  
 [out] A pointer to a Boolean value that is `true` if the object value, represented by this "ICorDebugObjectValue", is a value type rather than a reference type; otherwise, `pbIsValueClass` is `false`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
