---
title: "ICorDebugClass2::GetParameterizedType Method"
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
  - "ICorDebugClass2.GetParameterizedType"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugClass2::GetParameterizedType"
helpviewer_keywords: 
  - "GetParameterizedType method [.NET Framework debugging]"
  - "ICorDebugClass2::GetParameterizedType method [.NET Framework debugging]"
ms.assetid: 94b591c4-9302-4af2-a510-089496afb036
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugClass2::GetParameterizedType Method
Gets the type declaration for this class.  
  
## Syntax  
  
```  
HRESULT GetParameterizedType (  
    [in] CorElementType                      elementType,  
    [in] ULONG32                             nTypeArgs,  
    [in, size_is(nTypeArgs)] ICorDebugType  *ppTypeArgs[],  
    [out] ICorDebugType                    **ppType  
);  
```  
  
#### Parameters  
 `elementType`  
 [in] A value of the CorElementType enumeration that specifies the element type for this class: Set this value to ELEMENT_TYPE_VALUETYPE if this ICorDebugClass2 represents a value type. Set this value to ELEMENT_TYPE_CLASS if this `ICorDebugClass2` represents a complex type.  
  
 `nTypeArgs`  
 [in] The number of type parameters, if the type is generic. The number of type parameters (if any) must match the number required by the class.  
  
 `ppTypeArgs`  
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a type parameter. If the class is non-generic, this value is null.  
  
 `ppType`  
 [out] A pointer to the address of an `ICorDebugType` object that represents the type declaration. This object is equivalent to a <xref:System.Type> object in managed code.  
  
## Remarks  
 If the class is non-generic, that is, if it has no type parameters, `GetParameterizedType` simply gets the runtime type object corresponding to the class. The `elementType` parameter should be set to the correct element type for the class: ELEMENT_TYPE_VALUETYPE if the class is a value type; otherwise, ELEMENT_TYPE_CLASS.  
  
 If the class accepts type parameters (for example, `ArrayList<T>`), you can use `GetParameterizedType` to construct a type object for an instantiated type such as `ArrayList<int>`.  
  
## Background Information  
 In the .NET Framework versions 1.0 and 1.1, every type in the metadata could be directly mapped to a type in the running process. Thus, a metadata type and a runtime type had a single representation in the running process. However, one generic type in metadata can be mapped to many different instantiations of the type in the running process. For example, the metadata type `SortedList<K,V>` can map to `SortedList<String, EmployeeRecord>`, `SortedList<Int32, String>`, `SortedList<String,Array<Int32>>`, and so on. Thus, you need a way to handle type instantiation.  
  
 The .NET Framework version 2.0 introduces the `ICorDebugType` interface. For a generic type, an `ICorDebugClass` or `ICorDebugClass2` object represents the uninstantiated type (`SortedList<K,V>`), and an `ICorDebugType` object represents the various instantiated types. Given an `ICorDebugClass` or `ICorDebugClass2` object, you can create an `ICorDebugType` object for any instantiation by calling the `ICorDebugClass2::GetParameterizedType` method. You can also create an `ICorDebugType` object for a simple type, such as Int32, or for a non-generic type.  
  
 The introduction of the `ICorDebugType` object to represent the run-time notion of a type has a ripple effect throughout the API. Functions that previously took an `ICorDebugClass` or `ICorDebugClass2` object or even a `CorElementType` value are generalized to take an `ICorDebugType` object.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
