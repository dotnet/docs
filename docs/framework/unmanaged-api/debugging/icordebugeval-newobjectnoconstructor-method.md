---
description: "Learn more about: ICorDebugEval::NewObjectNoConstructor Method"
title: "ICorDebugEval::NewObjectNoConstructor Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugEval.NewObjectNoConstructor"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::NewObjectNoConstructor"
helpviewer_keywords: 
  - "NewObjectNoConstructor method [.NET Framework debugging]"
  - "ICorDebugEval::NewObjectNoConstructor method [.NET Framework debugging]"
ms.assetid: 80d509ca-b5e3-4c46-9c14-800db73d9bf7
topic_type: 
  - "apiref"
---
# ICorDebugEval::NewObjectNoConstructor Method

Allocates a new object instance of the specified type, without attempting to call a constructor method.  
  
 This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::NewParameterizedObjectNoConstructor](icordebugeval2-newparameterizedobjectnoconstructor-method.md) instead.  
  
## Syntax  
  
```cpp  
HRESULT NewObjectNoConstructor (  
    [in] ICorDebugClass     *pClass  
);  
```  
  
## Parameters  

 `pClass`  
 [in] Pointer to an ICorDebugClass object that represents the type of object to be instantiated.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See also

- [NewParameterizedObjectNoConstructor Method](icordebugeval2-newparameterizedobjectnoconstructor-method.md)
