---
title: "IXCLRDataProcess Interface"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess Interface"
api.location:
  - "mscordaccore.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess Interface"
helpviewer.keywords:
  - "IXCLRDataProcess Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess Interface

Provides methods for querying information about a process.

## Methods

|Method                           |Description                                                         |
|---------------------------------|--------------------------------------------------------------------|
|GetAppDomainByUniqueId           |Get the AppDomain by its unique id.                                 |
|StartEnumModules                 |Start enumerate modules of this process.                            |
|EnumModule                       |Enumerate modules of this process.                                  |
|EndEnumModules                   |End enumerate modules of this process.                              |
|StartEnumMethodInstancesByAddress|Start enumerate method instances of this process by an address.     |
|EnumMethodInstanceByAddress      |Enumerate method instances of this process by an address.           |
|EndEnumMethodInstancesByAddress  |End enumerate method instances of this process by an address.       |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `5c552ab6-fc09-4cb3-8e36-22fa03c798b7` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See Also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)