---
title: "ICorDebugEval::CreateValue Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugEval.CreateValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugEval::CreateValue"
helpviewer_keywords: 
  - "ICorDebugEval::CreateValue method [.NET Framework debugging]"
  - "CreateValue method [.NET Framework debugging]"
ms.assetid: 9a1c0b47-6f10-4fcb-844a-4ab2d7990140
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugEval::CreateValue Method
Creates a value of the specified type, with an initial value of zero or null.  
  
 This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::CreateValueForType](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-createvaluefortype-method.md) instead.  
  
## Syntax  
  
```  
HRESULT CreateValue (  
    [in] CorElementType     elementType,  
    [in] ICorDebugClass     *pElementClass,  
    [out] ICorDebugValue    **ppValue  
);  
```  
  
#### Parameters  
 `elementType`  
 [in] A value of the [CorElementType](../../../../docs/framework/unmanaged-api/metadata/corelementtype-enumeration.md) enumeration that specifies the type of the value.  
  
 `pElementClass`  
 [in] Pointer to an [ICorDebugClass](../../../../docs/framework/unmanaged-api/debugging/icordebugclass-interface.md) object that specifies the class of the value, if the type is not a primitive type.  
  
 `ppValue`  
 [out] Pointer to the address of an "ICorDebugValue" object that represents the value.  
  
## Remarks  
 `CreateValue` creates an `ICorDebugValue` object of the given type for the sole purpose of using it in a function evaluation. This value object can be used to pass user constants as parameters.  
  
 If the type of the value is a primitive type, its initial value is zero or null. Use [ICorDebugGenericValue::SetValue](../../../../docs/framework/unmanaged-api/debugging/icordebuggenericvalue-setvalue-method.md) to set the value of a primitive type.  
  
 If the value of `elementType` is ELEMENT_TYPE_CLASS, you get an "ICorDebugReferenceValue" (returned in `ppValue`) representing the null object reference. You can use this object to pass null to a function evaluation that has object reference parameters. You cannot set the `ICorDebugValue` to anything; it always remains null.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 1.1, 1.0  
  
## See Also  
    
 [CreateValueForType Method](../../../../docs/framework/unmanaged-api/debugging/icordebugeval2-createvaluefortype-method.md)  
 ICorDebugValue
