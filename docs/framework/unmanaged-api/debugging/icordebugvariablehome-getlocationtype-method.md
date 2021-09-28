---
description: "Learn more about: ICorDebugVariableHome::GetLocationType Method"
title: "ICorDebugVariableHome::GetLocationType Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugVariableHome.GetLocationType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugVariableHome::GetLocationType"
helpviewer_keywords: 
  - "ICorDebugVariableHome::GetLocationType method [.NET Framework debugging]"
  - "GetLocationType method, ICorDebugVariableHome interface [.NET Framework debugging]"
ms.assetid: 88027c55-8ec6-4f1e-a55b-7eefdbbc3515
topic_type: 
  - "apiref"
---
# ICorDebugVariableHome::GetLocationType Method

Gets the type of the variable's native location.  
  
## Syntax  
  
```cpp  
HRESULT GetLocationType(  
    [out] VariableLocationType *pLocationType  
);  
```  
  
## Parameters  

 `pLocationType`  
 [out] A pointer to the type of the variable's native location.  See the [VariableLocationType](variablelocationtype-enumeration.md) enumeration for more information.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v462plus](../../../../includes/net-current-v462plus-md.md)]  
  
## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
- [VariableLocationType Enumeration](variablelocationtype-enumeration.md)
