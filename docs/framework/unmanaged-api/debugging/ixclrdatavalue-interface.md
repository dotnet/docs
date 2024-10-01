---
description: "Learn more about: IXCLRDataValue Interface"
title: "IXCLRDataValue Interface"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue Interface"
helpviewer.keywords:
  - "IXCLRDataValue Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue Interface

Provides methods for querying information about a data value.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [GetAssociatedValue](ixclrdatavalue-getassociatedvalue-method.md) | Gets the value implicitly associated with this value. |
| [GetArrayElement](ixclrdatavalue-getarrayelement-method.md) | Gets the value representing a given element in the array. |
| [StartEnumFieldsByName](ixclrdatavalue-startenumfieldsbyname-method.md) | Provides a handle to enumerate the fields of this value by name. |
| [EnumFieldByName](ixclrdatavalue-enumfieldbyname-method.md) | Enumerates the fields of this value by name. |
| [EndEnumFieldsByName](ixclrdatavalue-endenumfieldsbyname-method.md) | Releases the resources used by internal iterators used during field enumeration. |
| [GetFlags](ixclrdatavalue-getflags-method.md) | Gets state flags of this value. |
| [GetNumFields2](ixclrdatavalue-getnumfields2-method.md) | Gets the number of fields in the value. |
| [GetArrayProperties](ixclrdatavalue-getarrayproperties-method.md) | Gets the definition of an array value. |
| [StartEnumFields](ixclrdatavalue-startenumfields-method.md) | Provides a handle to enumerate the fields of this value. |
| [EnumField](ixclrdatavalue-enumfield-method.md) | Enumerates the fields of this value. |
| [EndEnumFields](ixclrdatavalue-endenumfields-method.md) | Releases the resources used by internal iterators used during field enumeration. |
| [GetString](ixclrdatavalue-getstring-method.md) | Gets the length and contents of a string value. |
| [GetBytes](ixclrdatavalue-getbytes-method.md) | Copy between an object and a buffer. |
| [Request](ixclrdatavalue-request-method.md) | Requests to populate the buffer given with the value's data. |
| [GetType](ixclrdatavalue-gettype-method.md) | Gets the type of the value. |
| [GetSize](ixclrdatavalue-getsize-method.md) | Gets the size (in bytes) of the value. |
| [GetAddress](ixclrdatavalue-getaddress-method.md) | Gets the address of the object if the object is a single continuous piece of data in memory. |
| [GetNumLocations](ixclrdatavalue-getnumlocations-method.md) | Gets the number of locations the value's data is spread across. |
| [GetAssociatedType](ixclrdatavalue-getassociatedtype-method.md) | Gets the type of the value implicitly associated with this value. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `96EC93C7-1000-4e93-8991-98D8766E6666` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
