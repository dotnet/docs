---
description: "Learn more about: ICorDebugInternalFrame::GetFrameType Method"
title: "ICorDebugInternalFrame::GetFrameType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugInternalFrame.GetFrameType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugInternalFrame::GetFrameType"
helpviewer_keywords: 
  - "GetFrameType method [.NET Framework debugging]"
  - "ICorDebugInternalFrame::GetFrameType method [.NET Framework debugging]"
ms.assetid: da278a29-dc2e-4bf7-96ce-801bdc4d7025
topic_type: 
  - "apiref"
---
# ICorDebugInternalFrame::GetFrameType Method

Gets the type of this internal frame.  
  
## Syntax  
  
```cpp  
HRESULT GetFrameType (  
    [out] CorDebugInternalFrameType  *pType  
);  
```  
  
## Parameters  

 `pType`  
 [out] A pointer to a value of the CorDebugInternalFrameType enumeration that indicates the type of internal frame represented by this `ICorDebugInternalFrame` object.  
  
## Remarks  

 The internal frame type will never be STUBFRAME_NONE. Debuggers should gracefully ignore unrecognized internal frame types.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
