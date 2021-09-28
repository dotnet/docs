---
description: "Learn more about: ICorDebugClass::GetStaticFieldValue Method"
title: "ICorDebugClass::GetStaticFieldValue Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugClass.GetStaticFieldValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass::GetStaticFieldValue"
helpviewer_keywords: 
  - "GetStaticFieldValue method, ICorDebugClass interface [.NET Framework debugging]"
  - "ICorDebugClass::GetStaticFieldValue method [.NET Framework debugging]"
ms.assetid: 56e718b4-fabd-418b-a5b3-3cc33c745683
topic_type: 
  - "apiref"
---
# ICorDebugClass::GetStaticFieldValue Method

Gets the value of the specified static field.  
  
## Syntax  
  
```cpp  
HRESULT GetStaticFieldValue (  
    [in]  mdFieldDef         fieldDef,  
    [in]  ICorDebugFrame     *pFrame,  
    [out] ICorDebugValue     **ppValue  
);  
```  
  
## Parameters  

 `fieldDef`  
 [in] A field `Def` token that references the field to be retrieved.  
  
 `pFrame`  
 [in] A pointer to an ICorDebugFrame object that represents the frame to be used to disambiguate among thread, context, or application domain statics.  
  
 If the static field is relative to a thread, a context, or an application domain, the frame will determine the proper value.  
  
 `ppValue`  
 [out] A pointer to the address of an ICorDebugValue object that represents the value of the static field.  
  
## Remarks  

 For parameterized types, the value of a static field is relative to the particular instantiation. Therefore, if the class constructor takes parameters of type <xref:System.Type>, call [ICorDebugType::GetStaticFieldValue](icordebugtype-getstaticfieldvalue-method.md) instead of `ICorDebugClass::GetStaticFieldValue`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
