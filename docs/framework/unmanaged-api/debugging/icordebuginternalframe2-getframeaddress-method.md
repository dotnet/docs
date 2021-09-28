---
description: "Learn more about: ICorDebugInternalFrame2::GetFrameAddress Method"
title: "ICorDebugInternalFrame2::GetFrameAddress Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugInternalFrame2.GetFrameAddress Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugInternalFrame2::GetFrameAddress"
helpviewer_keywords: 
  - "GetFrameAddress method [.NET Framework debugging]"
  - "ICorDebugInternalFrame2::GetFrameAddress method [.NET Framework debugging]"
ms.assetid: 4ee8d058-ffc8-4967-9133-a5adfef4e518
topic_type: 
  - "apiref"
---
# ICorDebugInternalFrame2::GetFrameAddress Method

Returns the stack address of the internal frame.  
  
## Syntax  
  
```cpp  
HRESULT GetFrameAddress([out] CORDB_ADDRESS *pAddress);  
```  
  
## Parameters  

 `pAddress`  
 [out] Pointer to the `CORDB_ADDRESS` for the internal frame.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The address of the internal frame was successfully returned.|  
|E_FAIL|The address of the internal frame could not be returned.|  
|E_INVALIDARG|`pAddress` is `null`.|  
  
## Remarks  

 The value returned in `pAddress` can be used to determine the location of the internal frame relative to other frames on the stack. Even on IA-64-based computers, the internal frame lives on the stack only, and there is no corresponding pointer to a backing store.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorDebugInternalFrame2 Interface](icordebuginternalframe2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
