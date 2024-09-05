---
description: "Learn more about: IXCLRDataMethodInstance Interface"
title: "IXCLRDataMethodInstance Interface"
ms.date: "02/01/2019"
api.name:
  - "IXCLRDataMethodInstance Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance Interface"
helpviewer.keywords:
  - "IXCLRDataMethodInstance Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodInstance Interface

Provides methods for querying information about a method instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [GetILAddressMap](ixclrdatamethodinstance-getiladdressmap-method.md) | Gets the IL to address mapping information. |
| [GetRepresentativeEntryAddress](ixclrdatamethodinstance-getrepresentativeentryaddress-method.md) | Gets the most representative entry point address for the native compilation of all the possible entry points for a method. |
| [Request](ixclrdatamethodinstance-request-method.md) | Requests to populate the buffer given with the method instance's data. |
| [StartEnumExtents](ixclrdatamethodinstance-startenumextents-method.md) | Provides a handle for the enumeration of native code regions associated with the method. |
| [EnumExtent](ixclrdatamethodinstance-enumextent-method.md) | Enumerates the native code regions associated with the method. |
| [EndEnumExtents](ixclrdatamethodinstance-endenumextents-method.md) | Releases the resources used by internal iterators used during native code range enumeration. |
| [GetTokenAndScope](ixclrdatamethodinstance-gettokenandscope-method.md) | Gets the metadata token and scope of the method. |
| [GetILOffsetsByAddress](ixclrdatamethodinstance-getiloffsetsbyaddress-method.md) | Gets the IL offset(s) corresponding to the given address for the method.. |
| [GetAddressRangesByILOffset](ixclrdatamethodinstance-getaddressrangesbyiloffset-method.md) | Returns the native code address(es) which correspond to a given IL offset within the method. |
| [GetDefinition](ixclrdatamethodinstance-getdefinition.md) | Gets the method definition which matches this method instance. |
| [GetName](ixclrdatamethodinstance-getname.md) | Gets the fully qualified name for this method instance. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `ECD73800-22CA-4b0d-AB55-E9BA7E6318A5` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
