---
description: "Learn more about: IXCLRDataMethodDefinition Interface"
title: "IXCLRDataMethodDefinition Interface"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataMethodDefinition Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition Interface"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodDefinition Interface

Provides methods for querying information about a method definition.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

The following methods are some of the methods available in the interface.

| Method                                                                                                                          | Description                                                                                 |
| ------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| [StartEnumInstances](ixclrdatamethoddefinition-startenuminstances-method.md) | Provides a handle for the enumeration of method instances for a given `IXCLRDataAppDomain`. |
| [EnumInstance](ixclrdatamethoddefinition-enuminstance-method.md)             | Enumerates the instances of this method definition.                                         |
| [EndEnumInstances](ixclrdatamethoddefinition-endenuminstances-method.md)     | Releases the resources used by internal iterators used during instance enumeration.         |
| [Request](ixclrdatamethoddefinition-request-method.md)                       | Requests to populate the buffer given with the method's data. |
| [GetRepresentativeEntryAddress](ixclrdatamethoddefinition-getrepresentativeentryaddress-method.md)     | Gets the most representative start address of the native code for this method. |
| [GetTokenAndScope](ixclrdatamethoddefinition-gettokenandscope-method.md)     | Gets the metadata token and scope of the method. |
| [StartEnumExtents Method](ixclrdatamethoddefinition-startenumextents.md)     | Provides a handle for the enumeration of IL code regions associated with the method. |
| [EnumExtent](ixclrdatamethoddefinition-enumextent-method.md)                 | Enumerates the IL code regions associated with this method. |
| [EndEnumExtents](ixclrdatamethoddefinition-endenumextents-method.md)         | Releases the resources used by internal iterators used during IL code region enumeration. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `AAF60008-FB2C-420b-8FB1-42D244A54A97` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
