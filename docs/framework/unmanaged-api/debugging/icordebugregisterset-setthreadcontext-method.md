---
description: "Learn more about: ICorDebugRegisterSet::SetThreadContext Method"
title: "ICorDebugRegisterSet::SetThreadContext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRegisterSet.SetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet::SetThreadContext"
helpviewer_keywords: 
  - "ICorDebugRegisterSet::SetThreadContext method [.NET Framework debugging]"
  - "SetThreadContext method, ICorDebugRegisterSet interface [.NET Framework debugging]"
ms.assetid: 73afa930-32cb-4c40-81f8-83e8e6fbe213
topic_type: 
  - "apiref"
---
# ICorDebugRegisterSet::SetThreadContext Method

`SetThreadContext` is not implemented in the .NET Framework version 2.0. Do not call this method.  
  
> [!NOTE]
> Use the higher-level operation [ICorDebugNativeFrame::SetIP](icordebugnativeframe-setip-method.md) to set the context of a thread.  
  
## Syntax  
  
```cpp  
HRESULT SetThreadContext (  
    [in] ULONG32 contextSize,  
    [in, length_is(contextSize),  
         size_is(contextSize)] BYTE context[]  
);  
```  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
