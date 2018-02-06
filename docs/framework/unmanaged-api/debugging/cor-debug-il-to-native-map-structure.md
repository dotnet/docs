---
title: "COR_DEBUG_IL_TO_NATIVE_MAP Structure"
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
  - "COR_DEBUG_IL_TO_NATIVE_MAP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_DEBUG_IL_TO_NATIVE_MAP"
helpviewer_keywords: 
  - "COR_DEBUG_IL_TO_NATIVE_MAP structure [.NET Framework debugging]"
ms.assetid: 06f3b504-085f-4142-934a-25381fe23d4c
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_DEBUG_IL_TO_NATIVE_MAP Structure
Contains the offsets that are used to map Microsoft intermediate language (MSIL) code to native code.  
  
## Syntax  
  
```  
typedef struct COR_DEBUG_IL_TO_NATIVE_MAP {  
    ULONG32  ilOffset;  
    ULONG32  nativeStartOffset;  
    ULONG32  nativeEndOffset;  
} COR_DEBUG_IL_TO_NATIVE_MAP;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ilOffset`|The offset of the MSIL code.|  
|`nativeStartOffset`|The offset of the start of the native code.|  
|`nativeEndOffset`|The offset of the end of the native code.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [GetILToNativeMapping Method](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-getiltonativemapping-method.md)  
 [GetILToNativeMapping Method](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getiltonativemapping-method.md)  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
