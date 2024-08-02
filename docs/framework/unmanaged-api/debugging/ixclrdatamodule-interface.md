---
description: "Learn more about: IXCLRDataModule Interface"
title: "IXCLRDataModule Interface"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataModule Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule Interface"
helpviewer.keywords:
  - "IXCLRDataModule Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataModule Interface

Provides methods for querying information about a loaded module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                | Description                                                         |
| ------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------- |
| [StartEnumTypeDefinitions](ixclrdatamodule-startenumtypedefinitions-method.md)     | Provides a handle to enumerate the type definitions associated with the module. |
| [EnumTypeDefinition](ixclrdatamodule-enumtypedefinition-method.md)                 | Enumerates the type definitions associated with the module. |
| [EndEnumTypeDefinitions](ixclrdatamodule-endenumtypedefinitions-method.md)         | Releases the resources used by internal iterators used during type definition enumeration. |
| [StartEnumMethodInstancesByName](ixclrdatamodule-startenummethodinstancesbyname-method.md) | Provides a handle to enumerate method instances of a given name and AppDomain associated with the module. |
| [EnumMethodInstanceByName](ixclrdatamodule-enummethodinstancebyname-method.md)     | Enumerates method instances of a given name and AppDomain associated with the module. |
| [EndEnumMethodInstancesByName](ixclrdatamodule-endenummethodinstancesbyname-method.md)     | Releases the resources used by internal iterators used during method instance enumeration. |
| [GetMethodDefinitionByToken](ixclrdatamodule-getmethoddefinitionbytoken-method.md) | Gets the method definition corresponding to a given metadata token. |
| [GetFileName](ixclrdatamodule-getfilename-method.md)                               | Gets the full path and filename for the module, if there is one. |
| [StartEnumExtents](ixclrdatamodule-startenumextents-method.md)                     | Provides a handle to enumerate memory regions associated with the module. |
| [EnumExtent](ixclrdatamodule-enumextent-method.md)                                 | Enumerates memory regions associated with the module. |
| [EndEnumExtents](ixclrdatamodule-endenumextents-method.md)                         | Releases the resources used by internal iterators used during memory range enumeration. |
| [Request](ixclrdatamodule-request-method.md)                                       | Requests to populate the buffer given with the module's data.       |
| [GetVersionId](ixclrdatamodule-getversionid-method.md)                             | Gets the module's version ID.                                       |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `88E32849-0A0A-4cb0-9022-7CD2E9E139E2` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
