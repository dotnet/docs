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
| [GetMethodDefinitionByToken](ixclrdatamodule-getmethoddefinitionbytoken-method.md) | Gets the method definition corresponding to a given metadata token. |
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
