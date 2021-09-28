---
description: "Learn more about: ICorDebugFunction::GetILCode Method"
title: "ICorDebugFunction::GetILCode Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugFunction.GetILCode"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetILCode"
helpviewer_keywords: 
  - "ICorDebugFunction::GetILCode method [.NET Framework debugging]"
  - "GetILCode method [.NET Framework debugging]"
ms.assetid: f794dd47-a7cd-47f6-96e9-a41a4dae8e72
topic_type: 
  - "apiref"
---
# ICorDebugFunction::GetILCode Method

Gets the ICorDebugCode instance that represents the Microsoft intermediate language (MSIL) code associated with this ICorDebugFunction object.  
  
## Syntax  
  
```cpp  
HRESULT GetILCode (  
    [out] ICorDebugCode **ppCode  
);  
```  
  
## Parameters  

 `ppCode`  
 [out] A pointer to the `ICorDebugCode` instance, or null, if the function was not compiled into MSIL.  
  
## Remarks  

 If Edit and Continue has been allowed on this function, the `GetILCode` method will get the MSIL code corresponding to this function's edited version of the code in the common language runtime (CLR).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
