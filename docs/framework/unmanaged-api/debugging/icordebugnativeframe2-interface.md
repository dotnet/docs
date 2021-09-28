---
description: "Learn more about: ICorDebugNativeFrame2 Interface"
title: "ICorDebugNativeFrame2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugNativeFrame2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugNativeFrame2"
helpviewer_keywords: 
  - "ICorDebugNativeFrame2 interface [.NET Framework debugging]"
ms.assetid: 52a80838-af36-4399-bc97-d8a4c6d76df2
topic_type: 
  - "apiref"
---
# ICorDebugNativeFrame2 Interface

Provides methods that test for child and parent frame relationships.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[IsChild Method](icordebugnativeframe2-ischild-method.md)|Determines whether the current frame is a child frame.|  
|[IsMatchingParentFrame Method](icordebugnativeframe2-ismatchingparentframe-method.md)|Determines whether the specified frame is the parent of the current frame.|  
|[GetStackParameterSize Method](icordebugnativeframe2-getstackparametersize-method.md)|Returns the cumulative size of the parameters on the stack on x86 operating systems.|  
  
## Remarks  

 This interface logically extends the "ICorDebugNativeFrame" interface.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
