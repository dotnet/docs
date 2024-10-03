---
description: "Learn more about: IXCLRDataTypeDefinition Interface"
title: "IXCLRDataTypeDefinition Interface"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeDefinition Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeDefinition Interface"
helpviewer.keywords:
  - "IXCLRDataTypeDefinition Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeDefinition Interface

Provides methods for querying information about a type definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [StartEnumMethodDefinitions](ixclrdatatypedefinition-startenummethoddefinitions-method.md) | Provides a handle to enumerate the method definitions of the type. |
| [EnumMethodDefinition](ixclrdatatypedefinition-enummethoddefinition-method.md) | Enumerates the method definitions of the type. |
| [EndEnumMethodDefinitions](ixclrdatatypedefinition-endenummethoddefinitions-method.md) | Releases the resources used by internal iterators used during method definition enumeration. |
| [GetName](ixclrdatatypedefinition-getname-method.md) | Gets the fully qualified name for this type definition. |
| [GetCorElementType](ixclrdatatypedefinition-getcorelementtype-method.md) | Gets the standard element type of this type definition. |
| [GetTokenAndScope](ixclrdatatypedefinition-gettokenandscope-method.md) | Gets the metadata token and scope for this type definition. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `4675666C-C275-45b8-9F6C-AB165D5C1E09` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
