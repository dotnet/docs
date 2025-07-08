---
description: "Learn more about: IXCLRDataTypeInstance Interface"
title: "IXCLRDataTypeInstance Interface"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeInstance Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeInstance Interface"
helpviewer.keywords:
  - "IXCLRDataTypeInstance Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeInstance Interface

Provides methods for querying information about a type instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [GetNumStaticFields](ixclrdatatypeinstance-getnumstaticfields-method.md) | Gets the number of static fields in the type. |
| [GetStaticFieldByIndex](ixclrdatatypeinstance-getstaticfieldbyindex-method.md) | Get one static field of the type. |
| [GetDefinition](ixclrdatatypeinstance-getdefinition-method.md) | Gets the type definition matching this instance. |
| [StartEnumMethodInstances](ixclrdatatypeinstance-startenummethodinstances-method.md) | Provides a handle to enumerate the method instances of the type. |
| [EnumMethodInstance](ixclrdatatypeinstance-enummethodinstance-method.md) | Enumerates the method instances of the type. |
| [EndEnumMethodInstances](ixclrdatatypeinstance-endenummethodinstances-method.md) | Releases the resources used by internal iterators used during method instance enumeration. |
| [GetName](ixclrdatatypeinstance-getname-method.md) | Gets the fully qualified name of this type instance. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `4D078D91-9CB3-4b0d-97AC-28C8A5A82597` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
