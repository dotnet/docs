---
description: "Learn more about: IcorDebugVariableHome::GetLiveRange Method"
title: "IcorDebugVariableHome::GetLiveRange Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugVariableHome.GetLiveRange"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetLiveRange"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetLiveRange method [.NET Framework debugging]"
  - "GetLiveRange method, ICorDebugVariableFrame interface [.NET Framework debugging]"
ms.assetid: 87277e1a-1595-4729-9e25-d1c3ac18ce5f
topic_type: 
  - "apiref"
---
# IcorDebugVariableHome::GetLiveRange Method

Gets the native range over which this variable is live.  
  
## Syntax  
  
```cpp  
HRESULT GetLiveRange(  
    [out] ULONG32* pStartOffset,  
    [out] ULONG32 *pEndOffset  
);  
```  
  
## Parameters  

 `pStartOffset`  
 [out] The logical offset at which the variable is first live.  
  
 `pEndOffset`  
 [out] The logical offset immediately after the point at which the variable is last live.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
