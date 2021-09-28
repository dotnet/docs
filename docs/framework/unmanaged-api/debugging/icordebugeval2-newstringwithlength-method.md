---
description: "Learn more about: ICorDebugEval2::NewStringWithLength Method"
title: "ICorDebugEval2::NewStringWithLength Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval2.NewStringWithLength"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval2::NewStringWithLength"
helpviewer_keywords: 
  - "NewStringWithLength method [.NET Framework debugging]"
  - "ICorDebugEval2::NewStringWithLength method [.NET Framework debugging]"
ms.assetid: d5f54a34-6335-4708-b407-a756ec70fab4
topic_type: 
  - "apiref"
---
# ICorDebugEval2::NewStringWithLength Method

Creates a string of the specified length, with the specified contents.  
  
## Syntax  
  
```cpp  
HRESULT NewStringWithLength (  
    [in] LPCWSTR               string,  
    [in] UINT                  uiLength  
);  
```  
  
## Parameters  

 `string`  
 [in] A pointer to the string value.  
  
 `uiLength`  
 [in] Length of the string.  
  
## Remarks  

 If the string's trailing null character is expected to be in the managed string, the caller of the `NewStringWithLength` method must ensure that the string length includes the trailing null character.  
  
 The string is always created in the application domain in which the thread is currently executing.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
