---
description: "Learn more about: ICorDebugCode::GetILToNativeMapping Method"
title: "ICorDebugCode::GetILToNativeMapping Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.GetILToNativeMapping"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetILToNativeMapping"
helpviewer_keywords: 
  - "GetILToNativeMapping method, ICorDebugCode interface [.NET Framework debugging]"
  - "ICorDebugCode::GetILToNativeMapping method [.NET Framework debugging]"
ms.assetid: a8ecd8c8-9627-4356-9c6f-bd05e24637c0
topic_type: 
  - "apiref"
---
# ICorDebugCode::GetILToNativeMapping Method

Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from Microsoft intermediate language (MSIL) offsets to native offsets.  
  
## Syntax  
  
```cpp  
HRESULT GetILToNativeMapping (  
    [in]  ULONG32    cMap,  
    [out] ULONG32    *pcMap,  
    [out, size_is(cMap), length_is(*pcMap)]  
        COR_DEBUG_IL_TO_NATIVE_MAP map[]  
);  
```  
  
## Parameters  

 `cMap`  
 [in] The size of the `map` array.  
  
 `pcMap`  
 [out] A pointer to the actual number of elements returned in the `map` array.  
  
 `map`  
 [out] An array of `COR_DEBUG_IL_TO_NATIVE_MAP` structures, each of which represents a mapping from an MSIL offset to a native offset.  
  
 There is no ordering to the array of elements returned.  
  
## Remarks  

 The `GetILToNativeMapping` method returns meaningful results only if this "ICorDebugCode" instance represents native code that was just-in-time (JIT) compiled from MSIL code.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugCode Interface](icordebugcode-interface1.md)
