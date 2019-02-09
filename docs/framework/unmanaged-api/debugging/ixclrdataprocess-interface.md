---
title: "IXCLRDataProcess Interface"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess Interface"
api.location:
  - "mscordacwks.dll"
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

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                                               | Description                                                                                     |
| ---------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------- |
| [GetAppDomainByUniqueId](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-getappdomainbyuniqueid-method.md)                       | Gets an `AppDomain` in a process by its unique id.                                              |
| [StartEnumModules](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-startenummodules-method.md)                                   | Provides a handle to enumerate the modules of a process.                                        |
| [EnumModule](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-enummodule-method.md)                                               | Enumerates the modules of this process.                                                         |
| [EndEnumModules](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-endenummodules-method.md)                                       | Releases the resources used by internal iterators used during module enumeration.               |
| [StartEnumMethodInstancesByAddress](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-startenummethodinstancesbyaddress-method.md) | Provides a handle to enumerate the method instances of `AppDomain` starting at a given address. |
| [EnumMethodInstanceByAddress](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-enummethodinstancebyaddress-method.md)             | Enumerates the method instances of this process starting at an address offset.                  |
| [EndEnumMethodInstancesByAddress](../../../../docs/framework/unmanaged-api/debugging/ixclrdataprocess-endenummethodinstancesbyaddress-method.md)     | Releases the resources used by internal iterators used during instance enumeration.             |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `5c552ab6-fc09-4cb3-8e36-22fa03c798b7` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).   
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
