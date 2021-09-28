---
description: "Learn more about: ICorDebugVariableHomeEnum::Next Method"
title: "ICorDebugVariableHomeEnum::Next Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugVariableHomeEnum.Next"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHomeEnum::Next"
helpviewer_keywords: 
  - "ICorDebugVariableHomeEnum::Next method [.NET Framework debugging]"
  - "Next method, ICorDebugVariableHomeEnum interface [.NET Framework debugging]"
ms.assetid: eb9ea96c-5b58-4655-8104-094fc8b393b8
topic_type: 
  - "apiref"
---
# ICorDebugVariableHomeEnum::Next Method

Gets the specified number of [ICorDebugVariableHome](icordebugvariablehome-interface.md) instances that contain information about the local variables and arguments in a function.  
  
## Syntax  
  
```cpp  
HRESULT Next(  
    [in] ULONG celt,  
    [out, size_is(celt), length_is(*pceltFetched)] ICorDebugVariableHome *homes[],  
    [out] ULONG *pceltFetched  
);  
```  
  
## Parameters  

 `celt`  
 [in] The number of objects to be retrieved.  
  
 `homes`  
 An array of pointers, each of which points to a [ICorDebugVariableHome](icordebugvariablehome-interface.md) object that provides information about  a local variable or argument of a function.  
  
 `pceltFetched`  
 [out] The number of instances actually returned in objects.  
  
## Return Value  

 The method returns the following values.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|The method completed successfully.|  
|`S_FALSE`|The actual number of instances retrieved, as reflected in `pceltFetched`, is less than the number of instances requested.|  
  
## Remarks  

 The [ICorDebugVariableHomeEnum::Next](icordebugvariablehomeenum-next-method.md) method retrieves a maximum of  `celt` objects starting at the current position of the enumerator. When the method returns, `pceltFetched` contains the actual number of objects retrieved.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugVariableHomeEnum Interface](icordebugvariablehomeenum-interface.md)
- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
