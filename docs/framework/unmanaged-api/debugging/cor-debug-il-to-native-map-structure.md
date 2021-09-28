---
description: "Learn more about: COR_DEBUG_IL_TO_NATIVE_MAP Structure"
title: "COR_DEBUG_IL_TO_NATIVE_MAP Structure"
ms.date: "03/30/2017"
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
---
# COR_DEBUG_IL_TO_NATIVE_MAP Structure

Contains the offsets that are used to map Microsoft intermediate language (MSIL) code to native code.  
  
## Syntax  
  
```cpp  
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [GetILToNativeMapping Method](../profiling/icorprofilerinfo-getiltonativemapping-method.md)
- [GetILToNativeMapping Method](icordebugcode-getiltonativemapping-method.md)
- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
