---
description: "Learn more about: ICorDebugClass2::GetParameterizedType Method"
title: "ICorDebugClass2::GetParameterizedType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugClass2.GetParameterizedType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugClass2::GetParameterizedType"
helpviewer_keywords:
  - "GetParameterizedType method [.NET debugging]"
  - "ICorDebugClass2::GetParameterizedType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugClass2::GetParameterizedType Method

Gets the type declaration for this class.

## Syntax

```cpp
HRESULT GetParameterizedType (
    [in] CorElementType                      elementType,
    [in] ULONG32                             nTypeArgs,
    [in, size_is(nTypeArgs)] ICorDebugType  *ppTypeArgs[],
    [out] ICorDebugType                    **ppType
);
```

## Parameters

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

.NET Framework version 2.0 introduced the `ICorDebugType` interface. For a generic type, an `ICorDebugClass` or `ICorDebugClass2` object represents the uninstantiated type (`SortedList<K,V>`), and an `ICorDebugType` object represents the various instantiated types. Given an `ICorDebugClass` or `ICorDebugClass2` object, you can create an `ICorDebugType` object for any instantiation by calling the `ICorDebugClass2::GetParameterizedType` method. You can also create an `ICorDebugType` object for a simple type, such as Int32, or for a non-generic type.

The introduction of the `ICorDebugType` object to represent the run-time notion of a type has a ripple effect throughout the API. Functions that previously took an `ICorDebugClass` or `ICorDebugClass2` object or even a `CorElementType` value are generalized to take an `ICorDebugType` object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
