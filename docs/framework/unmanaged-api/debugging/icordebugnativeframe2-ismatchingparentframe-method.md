---
title: "ICorDebugNativeFrame2::IsMatchingParentFrame Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugNativeFrame2.IsMatchingParentFrame Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame2::IsMatchingParentFrame"
helpviewer_keywords: 
  - "IsMatchingParentFrame method [.NET Framework debugging]"
  - "ICorDebugNativeFrame2::IsMatchingParentFrame method [.NET Framework debugging]"
ms.assetid: d2ca20db-df22-4528-a0dd-a09ea62c8998
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugNativeFrame2::IsMatchingParentFrame Method
Determines whether the specified frame is the parent of the current frame.  
  
## Syntax  
  
```  
HRESULT IsMatchingParentFrame([in] ICorDebugNativeFrame2  
                                      *pPotentialParentFrame,  
                              [out] BOOL *pIsParent);  
```  
  
#### Parameters  
 `pPotentialParentFrame`  
 [in] A pointer to the frame object that you want to evaluate for parent status.  
  
 `pIsParent`  
 [out] `true` if `pPotentialParentFrame` is the current frame’s parent; otherwise, `false`.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The parent status was successfully returned.|  
|E_FAIL|The parent status could not be returned.|  
|E_INVALIDARG|`pPotentialParentFrame` or `pIsParent` is null.|  
  
## Exceptions  
  
## Remarks  
 `IsMatchingParentFrame` returns `true` if the frame object you pass to the method is the parent of the frame object on which the method was called. If you call the method on a frame that is not a child of the specified frame, it returns an error.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugNativeFrame2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
