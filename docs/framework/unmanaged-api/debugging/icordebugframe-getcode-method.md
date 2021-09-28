---
description: "Learn more about: ICorDebugFrame::GetCode Method"
title: "ICorDebugFrame::GetCode Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFrame.GetCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFrame::GetCode"
helpviewer_keywords: 
  - "GetCode method, ICorDebugFrame interface [.NET Framework debugging]"
  - "ICorDebugFrame::GetCode method [.NET Framework debugging]"
ms.assetid: fbaa0794-a031-4015-8beb-2749e47ac340
topic_type: 
  - "apiref"
---
# ICorDebugFrame::GetCode Method

Gets a pointer to the code associated with this stack frame.  
  
## Syntax  
  
```cpp  
HRESULT GetCode (  
    [out] ICorDebugCode      **ppCode  
);  
```  
  
## Parameters  

 `ppCode`  
 [out] A pointer to the address of an ICorDebugCode object that represents the code associated with this frame.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
