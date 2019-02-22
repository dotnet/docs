---
title: "ICorDebugNativeFrame2::IsChild Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugNativeFrame2.IsChild Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame2::IsChild"
helpviewer_keywords: 
  - "IsChild method [.NET Framework debugging]"
  - "ICorDebugNativeFrame2::IsChild method [.NET Framework debugging]"
ms.assetid: 9e2aae09-49cb-4fbd-81e5-e29cd864a88b
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ICorDebugNativeFrame2::IsChild Method
Determines whether the current frame is a child frame.  
  
## Syntax  
  
```  
HRESULT IsChild([out] BOOL * pIsChild);  
```  
  
#### Parameters  
 `pIsChild`  
 [out] A Boolean value that specifies whether the current frame is a child frame.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The child status was successfully returned.|  
|E_FAIL|The child status could not be returned.|  
|E_INVALIDARG|`pIsChild` is null.|  
  
## Exceptions  
  
## Remarks  
 The `IsChild` method returns `true` if the frame object on which you call the method is a child of another frame. If this is the case, use the [IsMatchingParentFrame](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-ismatchingparentframe-method.md) method to check whether a frame is its parent.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also
- [ICorDebugNativeFrame2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-interface.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
