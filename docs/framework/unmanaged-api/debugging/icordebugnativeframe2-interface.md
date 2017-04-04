---
title: "ICorDebugNativeFrame2 Interface | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorDebugNativeFrame2"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugNativeFrame2"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugNativeFrame2 interface [.NET Framework debugging]"
ms.assetid: 52a80838-af36-4399-bc97-d8a4c6d76df2
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugNativeFrame2 Interface
Provides methods that test for child and parent frame relationships.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[IsChild Method](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-ischild-method.md)|Determines whether the current frame is a child frame.|  
|[IsMatchingParentFrame Method](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-ismatchingparentframe-method.md)|Determines whether the specified frame is the parent of the current frame.|  
|[GetStackParameterSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugnativeframe2-getstackparametersize-method.md)|Returns the cumulative size of the parameters on the stack on x86 operating systems.|  
  
## Remarks  
 This interface logically extends the "ICorDebugNativeFrame" interface.  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
    
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)   
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)