---
description: "Learn more about: ICorDebugEval::NewObject Method"
title: "ICorDebugEval::NewObject Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval.NewObject"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::NewObject"
helpviewer_keywords: 
  - "NewObject method [.NET Framework debugging]"
  - "ICorDebugEval::NewObject method [.NET Framework debugging]"
ms.assetid: ce3025e8-defa-4c5e-8298-f49d71fa5736
topic_type: 
  - "apiref"
---
# ICorDebugEval::NewObject Method

Allocates a new object instance and calls the specified constructor method.  
  
 This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::NewParameterizedObject](icordebugeval2-newparameterizedobject-method.md) instead.  
  
## Syntax  
  
```cpp  
HRESULT NewObject (  
    [in] ICorDebugFunction  *pConstructor,  
    [in] ULONG32            nArgs,  
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]  
);  
```  
  
## Parameters  

 `pConstructor`  
 [in] The constructor to be called.  
  
 `nArgs`  
 [in] The size of the `ppArgs` array.  
  
 `ppArgs`  
 [in] An array of ICorDebugValue objects, each of which represents an argument to be passed to the constructor.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [NewParameterizedObject Method](icordebugeval2-newparameterizedobject-method.md)
