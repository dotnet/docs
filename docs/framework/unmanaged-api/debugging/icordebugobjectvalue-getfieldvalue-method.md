---
title: "ICorDebugObjectValue::GetFieldValue Method"
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
  - "ICorDebugObjectValue.GetFieldValue"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugObjectValue::GetFieldValue"
helpviewer_keywords: 
  - "ICorDebugObjectValue::GetFieldValue method [.NET Framework debugging]"
  - "GetFieldValue method [.NET Framework debugging]"
ms.assetid: c96770b0-3e09-47bb-bd29-20353b043459
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugObjectValue::GetFieldValue Method
Gets the value of the specified field of the specified class for this object value.  
  
## Syntax  
  
```  
HRESULT GetFieldValue (  
    [in]  ICorDebugClass     *pClass,  
    [in]  mdFieldDef         fieldDef,  
    [out] ICorDebugValue     **ppValue  
);  
```  
  
#### Parameters  
 `pClass`  
 [in] A pointer to an "ICorDebugClass" object that represents the class for which to get the field value.  
  
 `fieldDef`  
 [in] An `mdFieldDef` token that references the metadata describing the field.  
  
 `ppValue`  
 [out] A pointer to an "ICorDebugValue" object that represents the value of the specified field.  
  
## Remarks  
 The class, specified in the `pClass` parameter, must be in the hierarchy of the object value's class, and the field must be a field of that class.  
  
 The `GetFieldValue` method will still succeed for generic objects and generic classes. For example, if MyDictionary\<V> inherits from Dictionary\<string,V>, and the object value is of type MyDictionary\<int32>, passing the `ICorDebugClass` object for Dictionary\<K,V> will successfully get a field of Dictionary\<string,int32>.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
    
 
