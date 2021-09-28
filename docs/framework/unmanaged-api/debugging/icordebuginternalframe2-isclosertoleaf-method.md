---
description: "Learn more about: ICorDebugInternalFrame2::IsCloserToLeaf Method"
title: "ICorDebugInternalFrame2::IsCloserToLeaf Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugInternalFrame2.IsCloserToLeaf Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugInternalFrame2::IsCloserToLeaf"
helpviewer_keywords: 
  - "ICorDebugInternalFrame2::IsCloserToLeaf method [.NET Framework debugging]"
  - "IsCloserToLeaf method [.NET Framework debugging]"
ms.assetid: c1d3d1eb-8370-4f25-8297-3bd262b4740a
topic_type: 
  - "apiref"
---
# ICorDebugInternalFrame2::IsCloserToLeaf Method

Checks whether the `this` internal frame is closer to the leaf than the specified ICorDebugFrame object.  
  
## Syntax  
  
```cpp  
HRESULT IsCloserToLeaf([in] ICorDebugFrame * pFrameToCompare,  
                       [out] BOOL * pIsCloser);  
```  
  
## Parameters  

 `pFrameToCompare`  
 [in] A pointer to the comparison `ICorDebugFrame` object.  
  
 `pIsCloser`  
 [out] `true` if the `this` internal frame is closer to the leaf than the frame specified by `pFrameToCompare`; otherwise, `false`.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The comparison was successfully performed.|  
|E_FAIL|The comparison could not be performed.|  
|E_INVALIDARG|`pFrameToCompare` or `pIsCloser` is null.|  
  
## Remarks  

 `IsCloserToLeaf` can be used to implement a policy for interleaving internal frames with other frames on the stack.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorDebugInternalFrame2 Interface](icordebuginternalframe2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
